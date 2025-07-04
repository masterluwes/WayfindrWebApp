using Microsoft.AspNetCore.Mvc;

namespace WayfindrWebApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("self-assessment")]
        public IActionResult SelfAssessment() => View();

        [Route("self-assessment/test-form")]
        public IActionResult TestForm() => View();

        [Route("self-assessment/test-form/result")]
        public IActionResult Results() => View();

        [Route("career-paths")]
        public IActionResult CareerPaths() => View();

        [Route("roadmap")]
        public IActionResult Roadmap() => View();
    }
}
