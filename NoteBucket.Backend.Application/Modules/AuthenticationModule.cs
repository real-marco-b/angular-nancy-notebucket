using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses;
using NoteBucket.Backend.Api.Contracts;
using NoteBucket.Backend.Application.DataTransferModels;
using NoteBucket.Backend.Application.Security;
using NoteBucket.Backend.Application.Security.Tokens;

namespace NoteBucket.Backend.Application.Modules
{
    public class AuthenticationModule : NancyModule
    {
        public AuthenticationModule(IAuthenticationService authService, ITokenGenerator tokenGenerator) 
            : base("/api/authentication")
        {
            Post["/"] = _ =>
            {
                Credentials credentials = null;
                try
                {
                    credentials = this.Bind<Credentials>();
                }
                catch (ModelBindingException)
                {
                    // Credential information was not even provided -> Deny.
                    return HttpStatusCode.Unauthorized;
                }

                // We got some credentials information. Do they match an e-mail / password combination?
                var user = authService.ValidateCredentials(credentials.Username, credentials.Password);
                if (user == null)
                {
                    // No -> Deny.
                    return HttpStatusCode.Unauthorized;
                }

                // User is authenticated. Fetch rights for later authorization.
                var claims = authService.GetClaimsByUser(credentials.Username);
                var identity = new UserIdentity
                {
                    UserName = credentials.Username,
                    Claims = claims
                };

                var token = tokenGenerator.FromIdentity(identity);
                return new JsonResponse(new
                {
                    Token = token,
                    UserId = user.Id
                }, new DefaultJsonSerializer());
            };
        }
    }
}
