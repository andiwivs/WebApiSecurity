using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using WindowsAuthentication.Middleware;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(WindowsAuthentication.Startup))]

namespace WindowsAuthentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWindowsAuthentication();                         // set to support non-IIS host
            app.UseClaimsTransformation(TransformClaimsPrincipal);  // set when you want to transform or enrich the claims principal
            app.UseWebApi(WebApiConfig.Register());
        }

        private async Task<ClaimsPrincipal> TransformClaimsPrincipal(ClaimsPrincipal incoming)
        {
            if (!incoming.Identity.IsAuthenticated)
                return incoming;

            var name = incoming.Identity.Name;

            // TODO: implement custom user config load for claim enrichment
            var customRoleMembership1 = "TranslationManager.Admin";
            var customRoleMembership2 = "TranslationManager.Translator";
            var customAgentId = "ABC001";

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, name),
                new Claim(ClaimTypes.Role, customRoleMembership1),
                new Claim(ClaimTypes.Role, customRoleMembership2),
                new Claim("agentId", customAgentId)
            };

            var id = new ClaimsIdentity("Windows");
            id.AddClaims(claims);

            return new ClaimsPrincipal(id);
        }
    }
}
