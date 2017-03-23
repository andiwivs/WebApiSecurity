using System.Web.Http;

namespace SecurityPipeline.Pipeline
{
    [TestAuthenticationFilter]
    [TestAuthorizationFilter]
    public class TestController : ApiController
    {
        public IHttpActionResult Get()
        {
            Helper.Write("Controller", User);

            return Ok();
        }
    }
}
