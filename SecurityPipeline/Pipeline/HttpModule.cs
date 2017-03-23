using System;
using System.Web;

namespace SecurityPipeline
{
    public class HttpModule : IHttpModule
    {

        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;
        }

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            Helper.Write("HttpModule", HttpContext.Current.User);
        }

        public void Dispose()
        {}
    }
}
