using CompileCrew.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CompileCrew.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var response = RequestWithAI.Test();
            return View();
        }

    }
}
