using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Youtube.Api.Extensions
{
    public static class UserExtensions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            var claimsIdentity = user.Identity as ClaimsIdentity;
            return claimsIdentity.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
        }
    }
}
