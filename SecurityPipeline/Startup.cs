using Owin;
using SecurityPipeline.Pipeline;
using System.Web.Http;

namespace SecurityPipeline
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                "default",
                "api/{controller}"
            );

            app.Use(typeof(TestMiddleware)); // this one is ours :)

            app.UseWebApi(config);
        }
    }
}