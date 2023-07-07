using Microsoft.AspNetCore.Mvc;

namespace escolastico.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }
        public IActionResult InicioSesion()
        {
            return View();
        }
        public IActionResult Registro()
        {
            return View();
        }
    }
}
