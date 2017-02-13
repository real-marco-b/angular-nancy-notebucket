using NoteBucket.Backend.Base.Security;
using System;

namespace NoteBucket.Backend.Domain
{
    /// <summary>
    /// Represents a user of the NoteBucket system.
    /// The user
    /// * has a personal identity given by his or her E-Mail address and name.
    /// * is the creator and owner of notes and claims exclusive access to the notes he or she has created.
    /// * owns a password. Together with the e-mail address, it forms the authentication credentials.
    /// </summary>
    public class User : AbstractEntity<User>
    {
        /// <summary>
        /// Instantiates a new, transient user by the given e-mail address.
        /// </summary>
        /// <param name="email">The e-mail address as plain string.</param>
        public User(string email)
        {
            if (!isEMailValid(email))
            {
                throw new ArgumentException("email");
            }

            EMail = email;
            Salt = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Instantiates a new, transient user by the given e-mail address and name.
        /// </summary>
        /// <param name="email">The e-mail address as plain string.</param>
        /// <param name="forename">The forename.</param>
        /// <param name="surname">The surname.</param>
        public User(string email, string forename, string surname)
            : this(email)
        {
            Forename = forename;
            Surname = surname;
        }

        protected User() { }

        /// <summary>
        /// Gets the forename of the user.
        /// </summary>
        public virtual string Forename { get; set; }

        /// <summary>
        /// Gets the surname of the user.
        /// </summary>
        public virtual string Surname { get; set; }

        /// <summary>
        /// Gets the e-mail address of the user.
        /// </summary>
        public virtual string EMail { get; set; }

        /// <summary>
        /// Gets the hashed and salted password of the user.
        /// </summary>
        public virtual string Password { get; protected set; }

        /// <summary>
        /// Gets the user-specific salt used by password encryption.
        /// </summary>
        public virtual string Salt { get; }

        /// <summary>
        /// Sets the user password. The plain password will be hashed directly using the user-specific salt.
        /// The plain password is not stored by the entity.
        /// </summary>
        /// <param name="plainPassword">The plain password to use.</param>
        public virtual void SetPassword(string plainPassword)
        {
            Password = HashedPassword.Get(plainPassword, Salt);
        }

        /// <summary>
        /// Returns true iff the given e-mail address has an appropriate syntax.
        /// </summary>
        /// <param name="email">The e-mail address to check.</param>
        private bool isEMailValid(string email)
        {
            // TODO: Add some fancy regex validation here. E-Mail validation process would be needed anyway, though.
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            if (!email.Contains("@"))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Returns true iff the given password is hashed.
        /// </summary>
        /// <param name="password">The password to check.</param>
        private bool isPasswordEncrypted(string password)
        {
            // Passwords with the length of a SHA-256 hash are unlikely to be not encrypted.
            return password.Length == 64;
        }
    }
}
