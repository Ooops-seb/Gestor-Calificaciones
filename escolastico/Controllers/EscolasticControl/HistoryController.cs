using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace escolastico.Controllers.EscolasticControl
{
    [Authorize]
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
