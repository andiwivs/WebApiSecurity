using System;
using System.Web;

namespace SecurityPipeline
{
    public class HttpModule : IHttpModule
    {

        /*******************************************************************************************
         * Note: This will only work when hosting in IIS using traditional system.web reference.
         *       Consider this method deprecated as OWIN / Helios / Core streamline the web pipeline.
         *******************************************************************************************/
        
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
