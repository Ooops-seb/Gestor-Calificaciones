using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace escolastico.Controllers.EscolasticControl
{
    [Authorize]
    public class QueryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
