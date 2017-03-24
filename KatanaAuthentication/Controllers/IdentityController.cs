﻿using KatanaAuthentication.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace KatanaAuthentication.Controllers
{
    [Authorize]
    public class IdentityController : ApiController
    {
        public IEnumerable<ViewClaim> Get()
        {
            var principal = User as ClaimsPrincipal;

            return principal
                        .Claims
                        .Select(c => new ViewClaim { Type = c.Type, Value = c.Value });
        }
    }
}
