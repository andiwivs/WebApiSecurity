using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WindowsAuthentication.Middleware
{
    public class ClaimsTransformationOptions
    {
        public Func<ClaimsPrincipal, Task<ClaimsPrincipal>> ClaimsTransformation;
    }
}