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
            ClaimsPrincipal claimUser = HttpContext.User;
            string user_name = "";

            if (claimUser.Identity.IsAuthenticated)
            {
                user_name = claimUser.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
            }

            ViewData["user_name"] = user_name;

            return View();
        }

        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("LogOut","Account");
        }
    }
}