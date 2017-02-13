using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBucket.Backend.Application.Security.Tokens
{
    /// <summary>
    /// Represents the common interface for authorization token handler strategies.
    /// They operate upon the abstract Nancy user identity interface.
    /// 
    /// A handler validates tokens and extracts identity data from it (token parsing).
    /// </summary>
    public interface ITokenHandler
    {
        /// <summary>
        /// Validates the given token and constructs user identity information from it.
        /// </summary>
        /// <param name="token">The token to validate and parse.</param>
        /// <returns>The Nancy user identity extracted from the token.</returns>
        IUserIdentity ValidateAndParse(string token);
    }
}
