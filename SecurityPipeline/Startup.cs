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

            // we could assign auth filter globally this way, or add a [TestAuthenticationFilter] attribute to specific controllers and action methods
            //config.Filters.Add(new TestAuthenticationFilterAttribute());

            app.Use(typeof(TestMiddleware)); // this one is ours :)

            app.UseWebApi(config);
        }
    }
}