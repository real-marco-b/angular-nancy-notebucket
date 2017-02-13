using System;
using NoteBucket.Backend.Api.Contracts;
using NoteBucket.Backend.Persistence.Contracts;
using NoteBucket.Backend.Base.Security;
using NoteBucket.Backend.Base.Security.Claims;
using NoteBucket.Backend.Domain;

namespace NoteBucket.Backend.Api.Impl
{
    public class AuthenticationService : IAuthenticationService
    {
        private IRepositoryCatalog _catalog;

        public AuthenticationService(IRepositoryCatalog catalog)
        {
            _catalog = catalog;
        }

        public string[] GetClaimsByUser(string email)
        {
            var user = _catalog.Users.GetByEMail(email);
            return new[]
            {
                AccessClaim.Get(user.Id)
            };
        }

        public User ValidateCredentials(string email, string plainPassword)
        {
            var user = _catalog.Users.GetByEMail(email);

            if (user == null)
            {
                return null;
            }

            var hashedPassword = HashedPassword.Get(plainPassword, user.Salt);
            if (user.Password != hashedPassword)
            {
                return null;
            }

            return user;
        }
    }
}
