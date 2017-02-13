using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NoteBucket.Backend.Base.Security
{
    /// <summary>
    /// Provides static utility methods for generating SHA-256 hashed passwords.
    /// </summary>
    public static class HashedPassword
    {
        /// <summary>
        /// Generates a salted, SHA-256 hashed password. 
        /// </summary>
        /// <param name="password">The plain password to hash and salt.</param>
        /// <param name="salt">The salt to apply.</param>
        /// <returns>The salted and hashed password as string.</returns>
        public static string Get(string password, string salt)
        {
            var sha256 = new SHA256Managed();
            var input = string.Format("{0}:{1}", salt, password);
            var rawHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            var output = new StringBuilder();
            foreach (var b in rawHash)
            {
                output.Append(b.ToString("x2"));
            }
            return output.ToString();
        }

        /// <summary>
        /// Generates a salted, SHA-256 hashed password.
        /// </summary>
        /// <param name="password">The plain password to hash and salt.</param>
        /// <param name="salt">The salt to apply as Guid.</param>
        /// <returns>The salted and hashed password as string.</returns>
        public static string Get(string password, Guid salt)
        {
            return Get(password, salt.ToString());
        }
    }
}
