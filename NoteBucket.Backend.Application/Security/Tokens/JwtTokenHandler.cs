using JWT;
using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteBucket.Backend.Application.Security.Tokens
{
    class JwtTokenHandler : ITokenHandler
    {
        public IUserIdentity ValidateAndParse(string token)
        {
            try
            {
                var payload = JsonWebToken.DecodeToObject(token, JwtTokenGenerator.Key)
                    as Dictionary<string, object>;

                var subject = payload["sub"] as string;
                var defaultClaims = new[] {
                    JwtTokenGenerator.ClaimDefault_Subject,
                    JwtTokenGenerator.ClaimDefault_Issue,
                    JwtTokenGenerator.ClaimDefault_IssuedAt,
                    JwtTokenGenerator.ClaimDefault_Expires
                };
                var userClaims = payload.Where(p => !defaultClaims.Contains(p.Key))
                    .Select(c => string.Format("{0}:{1}", c.Key, c.Value.ToString()));

                return new UserIdentity
                {
                    UserName = subject,
                    Claims = userClaims
                };
            }
            catch (Exception)
            {
                // TODO logging
                return null;
            }
        }
    }
}
