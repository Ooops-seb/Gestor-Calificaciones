using escolastico.Models;
using escolastico.Resources;
using escolastico.Services.Contract;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace escolastico.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAdministradorService _administradorService;
        private readonly IAlumnoService _alumnoService;
        private readonly IProfesorService _profesorService;

        public AccountController
            (IUsuarioService usuarioService,
            IAlumnoService alumnoService,
            IProfesorService profesorService,
            IAdministradorService administradorService)
        {
            _usuarioService = usuarioService;
            _alumnoService = alumnoService;
            _profesorService = profesorService;
            _administradorService = administradorService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string userName, string password)
        {
            Usuario user_match = await _usuarioService.GetUser(userName, Utilities.EncryptKey(password));
            Administrador administrador = await _administradorService.GetInfo(userName);
            Profesor profesor = await _profesorService.GetInfo(userName);
            Alumno alumno = await _alumnoService.GetInfo(userName);

            string actor = "";
            string name = "";
            string surname = "";
            string role = "";

            if (user_match == null)
            {
                ViewData["login-msg"] = "No se encuentraron credenciales";
                return View();
            }
            if (administrador != null)
            {
                if (administrador.IdAdm.Substring(0,1) == "A")
                {
                    actor = administrador.UsuarioUsr;
                    name = administrador.NombreAdm;
                    surname = administrador.ApellidoAdm;
                    role = administrador.GetType().Name;
                }
            }
            else if(profesor != null)
            {
                if (profesor.IdPro.Substring(0, 1) == "P")
                {
                    actor = profesor.UsuarioUsr;
                    name = profesor.NombrePro;
                    surname = profesor.ApellidoPro;
                    role = profesor.GetType().Name;
                }
            }
            else if(alumno != null)
            {
                if (alumno.IdAlu.Substring(0, 1) == "S")
                {
                    actor = alumno.UsuarioUsr;
                    name = alumno.NombreAlu;
                    surname = alumno.ApellidoAlu;
                    role = alumno.GetType().Name;
                }
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Actor, actor),
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Surname, surname),
                new Claim(ClaimTypes.Role, role),
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
        public async Task<ActionResult> SingUp(string idUser, string userName, string password)
        {
            password = Utilities.EncryptKey(password);

            Usuario user = new Usuario { UsuarioUsr = userName, PasswordUsr = password };

            Usuario user_creator = await _usuarioService.SaveUser(idUser, user);

            if (user_creator != null)
            {
                return RedirectToAction("RequestSent", "Account");
            }

            ViewData["singup-msg"] = "No se pudo crear el usuario";
            return View();
        }
        public IActionResult SearchUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> SearchUser(string idUser)
        {
            if (idUser.Substring(0, 1) == "A")
            {
                Administrador user_match = await _administradorService.FindUser(idUser);
                if(user_match != null)
                {
                    TempData["idUser"] = idUser;
                    TempData["name_user"] = user_match.NombreAdm;
                    TempData["surname"] = user_match.ApellidoAdm;
                    TempData["rol"] = "Administrador";
                    return RedirectToAction("SingUp", "Account");
                }
            }
            else if (idUser.Substring(0, 1) == "P")
            {
                Profesor user_match = await _profesorService.FindUser(idUser);
                if (user_match != null)
                {
                    TempData["idUser"] = idUser;
                    TempData["name_user"] = user_match.NombrePro;
                    TempData["surname"] = user_match.ApellidoPro;
                    TempData["rol"] = "Profesor";
                    return RedirectToAction("SingUp", "Account");
                }
            }
            else if (idUser.Substring(0, 1) == "S")
            {
                Alumno user_match = await _alumnoService.FindUser(idUser);
                if (user_match != null)
                {
                    TempData["idUser"] = idUser;
                    TempData["name_user"] = user_match.NombreAlu;
                    TempData["surname"] = user_match.ApellidoAlu;
                    TempData["rol"] = "Alumno";
                    return RedirectToAction("SingUp", "Account");
                }
            }

            ViewData["search-msg"] = "No se encontraron registros en nuestro sistema o ya te encuentras registrado";
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