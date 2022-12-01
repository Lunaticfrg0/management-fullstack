using Microsoft.AspNetCore.Mvc;

namespace Management.Api.Controllers
{
    [Route("/")]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok($"ManagerApp.API");
        }
    }
}
