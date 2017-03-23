using System.Web.Http;
using System.Web.Http.Controllers;

namespace SecurityPipeline.Pipeline
{
    public class TestAuthorizationFilterAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {

            Helper.Write("AuthorizationFilter", actionContext.RequestContext.Principal);

            // TODO: implement custom authorization policy here

            return true;
        }
    }
}