using NoteBucket.Backend.Domain;

namespace NoteBucket.Backend.Api.Contracts
{
    /// <summary>
    /// Specifies the API authentication services of the system.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Validates the credentials of a user.
        /// </summary>
        /// <param name="email">The e-mail address of the user.</param>
        /// <param name="plainPassword">The plain password of the user.</param>
        /// <returns>The user the valid credentials belong to or null if invalid credentials have been passed.</returns>
        User ValidateCredentials(string email, string plainPassword);

        /// <summary>
        /// Returns the set of claims for a specific user.
        /// Claims are literals used by authorization. A claim expresses ownership or access right for a specific 
        /// object or feature.
        /// </summary>
        /// <param name="email">The e-mail address of the user.</param>
        /// <returns>A string array containing the complete set of claims.</returns>
        string[] GetClaimsByUser(string email);
    }
}
