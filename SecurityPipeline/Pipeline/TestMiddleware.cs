using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SecurityPipeline.Pipeline
{
    public class TestMiddleware
    {

        private Func<IDictionary<string, object>, Task> _next;

        public TestMiddleware(Func<IDictionary<string, object>, Task> next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            var context = new OwinContext(env); // fancy wrapper around the dictionary, useful for working with preset keys for things like user context

            // TODO: implement proper authenticate logic / plumbing here
            context.Request.User = new GenericPrincipal(new GenericIdentity("anders"), new string[0]);

            Helper.Write("Middleware", context.Request.User);

            await _next(env);
        }
    }
}