using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace SecurityPipeline.Pipeline
{
    public class TestAuthenticationFilterAttribute : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple => false;

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            Helper.Write("AuthenticationFilter", context.ActionContext.RequestContext.Principal);
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
        }
    }
}