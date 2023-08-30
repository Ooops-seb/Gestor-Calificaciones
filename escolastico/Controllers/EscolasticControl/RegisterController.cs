using escolastico.Models;
using escolastico.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using escolastico.Services.Contract;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using Microsoft.Extensions.Primitives;

namespace escolastico.Controllers.EscolasticControl
{
    [Authorize]
    public class RegisterController : Controller
    {
        private readonly IAdministradorService _administradorService;
        private readonly ICampusService _campusService;
        private readonly ITitulacionService _titulacionService;
        private readonly IAlumnoService _alumnoService;
        private readonly IProfesorService _profesorService;
        private readonly IAsignaturaService _asignaturaService;
        public RegisterController(
            IAdministradorService administradorService, 
            ICampusService campusService, 
            ITitulacionService titulacionService,
            IAlumnoService alumnoService,
            IProfesorService profesorService,
            IAsignaturaService asignaturaService)
        {
            _administradorService = administradorService;
            _campusService = campusService;
            _titulacionService = titulacionService;
            _alumnoService = alumnoService;
            _profesorService = profesorService;
            _asignaturaService = asignaturaService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(string actionSelected)
        {
            switch (actionSelected)
            {
                case "Alumno":
                    return RedirectToAction("Alumno");
                case "Profesor":
                    return RedirectToAction("Profesor");
                case "Administrador":
                    return RedirectToAction("Administrador");
                case "Asignatura":
                    return RedirectToAction("Asignatura");
                case "Paralelo":
                    return RedirectToAction("Paralelo");
                case "Acta":
                    return RedirectToAction("Acta");
                case "Matricula":
                    return RedirectToAction("Matricula");
                case "Titulacion":
                    return RedirectToAction("Titulacion");
                case "Campus":
                    return RedirectToAction("Campus");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Alumno()
        {
            var campusList = _campusService.GetCampusList().Result;
            var titulacionList = _titulacionService.GetTitulacionList().Result;

            ViewBag.CampusList = new SelectList(campusList, "IdCam", "NombreCam");
            ViewBag.TitulacionList = new SelectList(titulacionList, "IdTit", "NombreTit");

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Alumno(string cedula, string nombre, string apellido, string campus, string titulacion, DateTime fecha_nac, string direccion, string telefono, string correo, string genero, string observaciones)
        {
            var campusList = _campusService.GetCampusList().Result;
            var titulacionList = _titulacionService.GetTitulacionList().Result;

            ViewBag.CampusList = new SelectList(campusList, "IdCam", "NombreCam");
            ViewBag.TitulacionList = new SelectList(titulacionList, "IdTit", "NombreTit");

            var nuevoAlumno = new Alumno
            {
                IdAlu = await _alumnoService.GenerateNextId(),
                CedulaAlu = cedula,
                NombreAlu = nombre,
                ApellidoAlu = apellido,
                IdCam = campus,
                IdTit = titulacion,
                FechaNacimientoAlu = fecha_nac,
                DireccionAlu = direccion,
                TelefonoAlu = telefono,
                CorreoAlu = correo,
                GeneroAlu = genero,
                ObservacionesAlu = observaciones
            };

            var result = await _alumnoService.NewRegister(nuevoAlumno);

            if (result != null)
            {
                ViewData["MSG"] = "Registro realizado correctamente";
                return View();
            }

            ViewData["MSG"] = "Error de registro";
            return View();
        }
        public IActionResult Profesor()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Profesor(string cedula, string nombre, string apellido, DateTime fecha_nac, string direccion, string telefono, string correo, string genero)
        {
            var nuevoProfesor = new Profesor
            {
                IdPro = await _profesorService.GenerateNextId(),
                CedulaPro = cedula,
                NombrePro = nombre,
                ApellidoPro = apellido,
                FechaNacimientoPro = fecha_nac,
                DireccionPro = direccion,
                TelefonoPro = telefono,
                CorreoPro = correo,
                GeneroPro = genero
            };

            var result = await _profesorService.NewRegister(nuevoProfesor);

            if (result != null)
            {
                ViewData["MSG"] = "Registro realizado correctamente";
                return View();
            }

            ViewData["MSG"] = "Error de registro";
            return View();
        }
        public IActionResult Administrador()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Administrador(string cedula, string nombre, string apellido, DateTime fecha_nac, string direccion, string telefono, string correo, string genero)
        {
            var nuevoAdministrador = new Administrador
            {
                IdAdm = await _administradorService.GenerateNextId(),
                CedulaAdm = cedula,
                NombreAdm = nombre,
                ApellidoAdm = apellido,
                FechaNacimientoAdm = fecha_nac,
                DireccionAdm = direccion,
                TelefonoAdm = telefono,
                CorreoAdm = correo,
                GeneroAdm = genero
            };

            var result = await _administradorService.NewRegister(nuevoAdministrador);

            if(result != null)
            {
                ViewData["MSG"] = "Registro realizado correctamente";
                return View();
            }

            ViewData["MSG"] = "Error de registro";
            return View();
        }
        [HttpGet]
        public IActionResult Asignatura()
        {
            var profList = _profesorService.GetProfesorList().Result;

            ViewBag.ProfList = new SelectList(profList, "IdPro", "NombrePro");

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Asignatura(string nombre, string creditos, string profesor)
        {
            var profList = _profesorService.GetProfesorList().Result;

            ViewBag.ProfList = new SelectList(profList, "IdPro", "NombrePro");

            byte.TryParse(creditos, out byte creditosParam);

            var nuevaAsignatura = new Asignatura
            {
                IdAsi = await _asignaturaService.GenerateNextId(),
                NombreAsi = nombre,
                CreditosAsi = creditosParam,
                IdPro = profesor
            };

            var result = await _asignaturaService.NewRegister(nuevaAsignatura);

            if (result != null)
            {
                ViewData["MSG"] = "Registro realizado correctamente";
                return View();
            }

            ViewData["MSG"] = "Error de registro";
            return View();
        }
        public IActionResult Paralelo()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Paralelo()
        {
            return View();
        }
        public IActionResult Matricula()
        {
            return View();
        }
        public IActionResult Titulacion()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Titulacion(string nombre, string creditos)
        {
            short creditosParam;
            short.TryParse(creditos, out creditosParam);
            var nuevaTitulacion = new Titulacion
            {
                IdTit = await _titulacionService.GenerateNextId(),
                NombreTit = nombre,
                CreditosTotalesTit = creditosParam,
            };

            var result = await _titulacionService.NewRegister(nuevaTitulacion);

            if(result != null)
            {
                ViewData["MSG"] = "Registro realizado correctamente";
                return View();
            }

            ViewData["MSG"] = "Error de registro";
            return View();
        }
        public IActionResult Campus()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Campus(string nombre, string direccion)
        {
            var nuevoCampus = new Campus
            {
                IdCam = await _campusService.GenerateNextId(),
                NombreCam = nombre,
                DireccionCam = direccion,
            };

            var result = await _campusService.NewRegister(nuevoCampus);

            if (result != null)
            {
                ViewData["MSG"] = "Registro realizado correctamente";
                return View();
            }

            ViewData["MSG"] = "Error de registro";
            return View();
        }
    }
}
