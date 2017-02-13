using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBucket.Backend.Base.Security.Claims
{
    public static class AdminClaim
    {
        public static string Get()
        {
            return "is-admin";
        }
    }
}
