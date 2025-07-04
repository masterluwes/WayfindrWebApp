using Microsoft.AspNetCore.Mvc;

namespace ADET_Webapp.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("")] // Default route
        public IActionResult Index()
        {
            return View();
        }
    }
}
