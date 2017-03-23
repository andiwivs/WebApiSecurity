using System.Web.Http;

namespace SecurityPipeline.Pipeline
{
    public class TestController : ApiController
    {
        public IHttpActionResult Get()
        {
            Helper.Write("Controller", User);

            return Ok();
        }
    }
}
