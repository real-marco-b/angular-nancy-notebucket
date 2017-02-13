using Nancy;
using Nancy.Security;

namespace NoteBucket.Backend.Application.Security
{
    /// <summary>
    /// Represents a common interface for accessing information of the authentication process by a Nancy module.
    /// </summary>
    public interface IAuthenticationContext
    {
        /// <summary>
        /// Gets the Nancy user identity from authentication process information.
        /// </summary>
        /// <param name="context">The current Nancy context.</param>
        /// <returns>A Nancy user identity instance or null if no information could be resolved.</returns>
        IUserIdentity GetUser(NancyContext context);
    }
}
