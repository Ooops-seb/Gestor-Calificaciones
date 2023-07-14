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
            string actor = "";
            string name = "";
            string surname = "";
            string role = "";

            if (claimUser.Identity.IsAuthenticated)
            {
                actor = claimUser.Claims.Where(c => c.Type == ClaimTypes.Actor).Select(c => c.Value).SingleOrDefault();
                name = claimUser.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
                surname = claimUser.Claims.Where(c => c.Type == ClaimTypes.Surname).Select(c => c.Value).SingleOrDefault();
                role = claimUser.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).SingleOrDefault();
            }

            ViewData["actor"] = actor;
            ViewData["name"] = name;
            ViewData["surname"] = surname;
            ViewData["role"] = role;

            return View();
        }

        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("LogOut","Account");
        }
    }
}