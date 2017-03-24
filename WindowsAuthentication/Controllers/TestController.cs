using System.Collections.Generic;
using System.Web.Http;

namespace WindowsAuthentication.Controllers
{
    public class TestController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
