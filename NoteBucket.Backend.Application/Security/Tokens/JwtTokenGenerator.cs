using JWT;
using Nancy.Security;
using NoteBucket.Backend.Base.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteBucket.Backend.Application.Security.Tokens
{
    public class JwtTokenGenerator : ITokenGenerator
    {
        internal const string Key = "NzlGNjNEMEItQ0QwMi00RTJELUExMUItMUU0Qzc2NTYyNTVD";
        internal const string ClaimDefault_Issue = "iss";
        internal const string ClaimDefault_Subject = "sub";
        internal const string ClaimDefault_IssuedAt = "iat";
        internal const string ClaimDefault_Expires = "exp";

        public string FromIdentity(IUserIdentity identity)
        {
            var issuedAt = DateTime.Now;
            var expiringAt = issuedAt.AddHours(10);

            var payload = new Dictionary<string, object>()
            {
                { ClaimDefault_Issue, "Boarding" },
                { ClaimDefault_Subject, identity.UserName },
                { ClaimDefault_IssuedAt, UnixTime.FromDateTime(issuedAt) },
                { ClaimDefault_Expires, UnixTime.FromDateTime(expiringAt) },
            };
            EnhancePayloadByUserClaims(payload, identity);

            return JsonWebToken.Encode(payload, Key, JwtHashAlgorithm.HS256);
        }

        private void EnhancePayloadByUserClaims(Dictionary<string, object> payload, IUserIdentity identity)
        {
            foreach (var claim in identity.Claims)
            {
                if (!claim.Contains(":"))
                {
                    continue;
                }
                var claimKeyVal = claim.Split(':');
                payload.Add(claimKeyVal[0], claimKeyVal[1]);
            }
        }
    }
}
