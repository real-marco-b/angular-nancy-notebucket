using Nancy.Security;
using System;
using System.Collections.Generic;

namespace NoteBucket.Backend.Application.Security
{
    /// <summary>
    /// Basic user identity object implementing Nancy user identity interface.
    /// </summary>
    public class UserIdentity : IUserIdentity
    {
        public UserIdentity()
        {
            Claims = new List<string>();
        }

        public IEnumerable<string> Claims { get; set; }

        public string UserName { get; set; }
    }
}
