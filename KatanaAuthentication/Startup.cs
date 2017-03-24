using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(KatanaAuthentication.Startup))]

namespace KatanaAuthentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseBasicAuthentication("Demo", ValidateBasicAuth);
            app.UseWebApi(WebApiConfig.Register());
        }

        private Task<IEnumerable<Claim>> ValidateBasicAuth(string id, string secret)
        {

            IEnumerable<Claim> claims = null;

            // TODO: implement auth check
            if (id == secret)
            {
                claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, id),
                    new Claim(ClaimTypes.Role, "TranslationManager.Admin"),
                    new Claim(ClaimTypes.Role, "TranslationManager.Translator")
                };
            }

            return Task.FromResult(claims);
        }
    }
}
