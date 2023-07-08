using Microsoft.AspNetCore.Mvc;

namespace escolastico.Controllers
{
    public class EscolasticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
