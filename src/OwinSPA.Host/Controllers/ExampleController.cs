using System.Web.Http;

namespace OwinSPA.Host.Controllers
{
    public class ExampleController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return "I'm Alive";
        }
    }
}
