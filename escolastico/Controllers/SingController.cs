using Microsoft.AspNetCore.Mvc;

namespace escolastico.Controllers
{
    public class SingController : Controller
    {
        private readonly ILogger<SingController> _logger;

        public SingController(ILogger<SingController> logger)
        {
            _logger = logger;
        }
        public IActionResult In()
        {
            return View();
        }
        public IActionResult Up()
        {
            return View();
        }
        public IActionResult Apply()
        {
            return View();
        }
    }
}