using escolastico.Models;
using escolastico.Resources;
using escolastico.Services.Contract;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace escolastico.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public AccountController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string userName, string password)
        {
            Usuario user_march = await _usuarioService.GetUser(userName, Utilities.EncryptKey(password));

            if (user_march == null)
            {
                ViewData["MSG"] = "No se encuentraron credenciales";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user_march.UsuarioUsr)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync
            (
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
            );

            return RedirectToAction("Index","Escolastic");
        }
        public IActionResult SingUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> SingUp(Usuario user)
        {
            user.PasswordUsr = Utilities.EncryptKey(user.PasswordUsr);

            Usuario user_creator = await _usuarioService.SaveUser(user);

            if (user_creator.IdUsr > 0)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewData["MSG"] = "No se pudo crear el usuario";

            return View();
        }
        public IActionResult RequestSent()
        {
            return View();
        }
        public IActionResult LogOut()
        {
            return View();
        }
    }
}