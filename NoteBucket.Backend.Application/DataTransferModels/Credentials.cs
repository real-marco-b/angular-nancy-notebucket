using System;

namespace NoteBucket.Backend.Application.DataTransferModels
{
    /// <summary>
    /// Plain class for binding login information from REST request.
    /// </summary>
    public class Credentials
    {
        /// <summary>
        /// The username (e-mail) to authenticate.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The plain password to authenticate.
        /// </summary>
        public string Password { get; set; }
    }
}
