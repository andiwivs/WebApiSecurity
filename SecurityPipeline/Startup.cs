using Owin;
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

            app.UseWebApi(config);
        }
    }
}