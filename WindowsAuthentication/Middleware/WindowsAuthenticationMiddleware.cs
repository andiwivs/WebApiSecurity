using Owin;
using System.Net;

namespace WindowsAuthentication.Middleware
{
    public static class WindowsAuthenticationMiddleware
    {

        /*******************************************************************************
         * use this middleware if you intend to host outside of IIS
         *******************************************************************************/

        public static IAppBuilder UseWindowsAuthentication(this IAppBuilder app)
        {
            object value;

            if (app.Properties.TryGetValue("System.Net.HttpListener", out value))
            {
                var listener = value as HttpListener;

                if (listener != null)
                {
                    listener.AuthenticationSchemes = AuthenticationSchemes.IntegratedWindowsAuthentication;
                }
            }

            return app;
        }
    }
}