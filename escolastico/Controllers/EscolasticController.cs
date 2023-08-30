using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using escolastico.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace escolastico.Controllers
{
    [Authorize]
    public class EscolasticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("LogOut","Account");
        }
    }
}