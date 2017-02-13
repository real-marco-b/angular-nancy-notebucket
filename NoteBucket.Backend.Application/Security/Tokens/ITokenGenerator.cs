using Nancy.Security;
using System;

namespace NoteBucket.Backend.Application.Security.Tokens
{
    /// <summary>
    /// Represents the common interface for authorization token generation strategies. 
    /// They operate upon the abstract Nancy user identity interface.
    /// </summary>
    public interface ITokenGenerator
    {
        /// <summary>
        /// Creates a token by the given user identity.
        /// </summary>
        /// <param name="identity">The abstract Nancy user identity.</param>
        /// <returns>A string representing the authorization token.</returns>
        string FromIdentity(IUserIdentity identity);
    }
}
