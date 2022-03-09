using Microsoft.AspNetCore.Mvc;

namespace TovutiAPI.Controllers
{
    [ApiController]   
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("/")]
        public ContentResult Index()
        {
            return Content(" This is a default landing page for Tovuti interview Web Api, use /api/{controllername}/ for specific endpoints");
        }

    }
}
