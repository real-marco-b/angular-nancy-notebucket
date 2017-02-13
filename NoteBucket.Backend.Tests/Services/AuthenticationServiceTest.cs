using Moq;
using NoteBucket.Backend.Api.Impl;
using NoteBucket.Backend.Base;
using NoteBucket.Backend.Base.Security.Claims;
using NoteBucket.Backend.Domain;
using NoteBucket.Backend.Persistence.Contracts;
using System.Linq;
using Xunit;

namespace NoteBucket.Backend.Tests.Services
{
    public class AuthenticationServiceTest
    {
        [Fact]
        public void GetClaimsByUser_Includes_Access_Claim()
        {
            var user = new User("john.doe@note-bucket.io", "John", "Doe");
            ObjectUtils.SetPrivateProperty(user, "Id", 1);

            var catalog = new Mock<IRepositoryCatalog>();
            var repo = new Mock<IUserRepository>();
            repo.Setup(x => x.GetByEMail(It.IsAny<string>())).Returns(() => user);
            catalog.Setup(x => x.Users).Returns(repo.Object);

            var service = new AuthenticationService(catalog.Object);
            var claims = service.GetClaimsByUser("john.doe@note-bucket.io");

            Assert.True(claims.FirstOrDefault(c => c == AccessClaim.Get(1)) != null);
        }
    }
}
