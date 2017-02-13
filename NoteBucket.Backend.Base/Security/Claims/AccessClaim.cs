using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBucket.Backend.Base.Security.Claims
{
    public static class AccessClaim
    {
        public static string Get(int ownerId)
        {
            return string.Format("may-acccess-objects-from:{0}", ownerId);
        }
    }
}
