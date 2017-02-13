using Nancy;
using Nancy.Security;
using NoteBucket.Backend.Application.Security.Tokens;

namespace NoteBucket.Backend.Application.Security
{
    internal class AuthenticationContext : IAuthenticationContext
    {
        private ITokenHandler _handler;

        public AuthenticationContext(ITokenHandler handler)
        {
            _handler = handler;
        }

        public IUserIdentity GetUser(NancyContext context)
        {
            var givenAuthorization = context.Request.Headers.Authorization;
            var authorizationElements = givenAuthorization.Split(' ');
            if (authorizationElements[0] != "Bearer")
            {
                return null;
            }

            var token = authorizationElements[1].Trim();
            var identity = _handler.ValidateAndParse(token);

            return identity;
        }
    }
}
