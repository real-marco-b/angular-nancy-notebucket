using NoteBucket.Backend.Domain;

namespace NoteBucket.Backend.Persistence.Contracts
{
    /// <summary>
    /// Specifies the interface for repositories handling users.
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Gets a specific user by his or her e-mail address.
        /// </summary>
        /// <param name="email">The e-mail address to query.</param>
        /// <returns>An instance representing the user or null in case no user with the given e-mail was found.</returns>
        User GetByEMail(string email);
    }
}
