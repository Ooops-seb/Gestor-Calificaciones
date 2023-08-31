using escolastico.Models;
using escolastico.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using escolastico.Services.Contract;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
        private readonly IParaleloService _paraleloService;
        private readonly IMatriculaService _matriculaService;
        private readonly IActaService _actaService;
        private readonly ICalificacionesService _calificacionesService;
        public RegisterController(
            IAdministradorService administradorService, 
            ICampusService campusService, 
            ITitulacionService titulacionService,
            IAlumnoService alumnoService,
            IProfesorService profesorService,
            IAsignaturaService asignaturaService,
            IParaleloService paraleloService,
            IMatriculaService matriculaService,
            IActaService actaService,
            ICalificacionesService calificacionesService)
        {
            _administradorService = administradorService;
            _campusService = campusService;
            _titulacionService = titulacionService;
            _alumnoService = alumnoService;
            _profesorService = profesorService;
            _asignaturaService = asignaturaService;
            _paraleloService = paraleloService;
            _matriculaService = matriculaService;
            _actaService = actaService;
            _calificacionesService = calificacionesService;
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
                case "Calificaciones":
                    return RedirectToAction("Calificaciones");
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

            var userName = User.FindFirst(ClaimTypes.Name)?.Value;

            var result = await _alumnoService.NewRegister(nuevoAlumno, userName);

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

            var userName = User.FindFirst(ClaimTypes.Name)?.Value;

            var result = await _profesorService.NewRegister(nuevoProfesor, userName);

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

            var userName = User.FindFirst(ClaimTypes.Name)?.Value;

            var result = await _administradorService.NewRegister(nuevoAdministrador, userName);

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

            var userName = User.FindFirst(ClaimTypes.Name)?.Value;

            var nuevaAsignatura = new Asignatura
            {
                IdAsi = await _asignaturaService.GenerateNextId(),
                NombreAsi = nombre,
                CreditosAsi = creditosParam,
                IdPro = profesor
            };

            var result = await _asignaturaService.NewRegister(nuevaAsignatura, userName);

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
        public async Task<ActionResult> Paralelo(string nombre, string horario)
        {
            var userName = User.FindFirst(ClaimTypes.Name)?.Value;

            var nuevoParalelo = new Paralelo
            {
                IdPar = await _paraleloService.GenerateNextId(),
                NombrePar = nombre,
                HorarioPar = horario,
            };

            var result = await _paraleloService.NewRegister(nuevoParalelo, userName);

            if (result != null)
            {
                ViewData["MSG"] = "Registro realizado correctamente";
                return View();
            }

            ViewData["MSG"] = "Error de registro";
            return View();
        }
        public IActionResult Matricula()
        {
            var asigList = _asignaturaService.GetAsignaturaList().Result;

            ViewBag.AsigList = new SelectList(asigList, "IdAsi", "NombreAsi");

            var aluList = _alumnoService.GetAlumnoList().Result;

            ViewBag.AluList = new SelectList(aluList, "IdAlu", "NombreAlu", "ApellidoAlu");

            var paraList = _paraleloService.GetParaleloList().Result;

            ViewBag.ParaList = new SelectList(paraList, "IdPar", "IdPar");

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Matricula(string alumno, string asignatura, string paralelo)
        {
            var asigList = _asignaturaService.GetAsignaturaList().Result;
            ViewBag.AsigList = new SelectList(asigList, "IdAsi", "NombreAsi");

            var aluList = _alumnoService.GetAlumnoList().Result;
            ViewBag.AluList = new SelectList(aluList, "IdAlu", "NombreAlu", "ApellidoAlu");

            var paraList = _paraleloService.GetParaleloList().Result;
            ViewBag.ParaList = new SelectList(paraList, "IdPar", "IdPar");

            var userName = User.FindFirst(ClaimTypes.Name)?.Value;

            var nuevaMatricula = new Matricula
            {
                IdMat = await _matriculaService.GenerateNextId(),
                IdAlu = alumno,
                IdAsi = asignatura,
                IdPar = paralelo
            };

            var result = await _matriculaService.NewRegister(nuevaMatricula, userName);

            if (result != null)
            {
                var nuevaCalificacion = new Calificacion
                {
                    IdCal = await _calificacionesService.GenerateNextId(),
                    IdMat = nuevaMatricula.IdMat
                };

                var calificacionResult = await _calificacionesService.NewRegister(nuevaCalificacion, userName);

                if (calificacionResult != null)
                {
                    ViewData["MSG"] = "Registro realizado correctamente";
                    return View();
                }
            }

            ViewData["MSG"] = "Error de registro";
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

            var userName = User.FindFirst(ClaimTypes.Name)?.Value;

            var result = await _titulacionService.NewRegister(nuevaTitulacion, userName);

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

            var userName = User.FindFirst(ClaimTypes.Name)?.Value;

            var result = await _campusService.NewRegister(nuevoCampus, userName);

            if (result != null)
            {
                ViewData["MSG"] = "Registro realizado correctamente";
                return View();
            }

            ViewData["MSG"] = "Error de registro";
            return View();
        }
        public IActionResult Acta()
        {
            var asigList = _asignaturaService.GetAsignaturaList().Result;
            ViewBag.AsigList = new SelectList(asigList, "IdAsi", "NombreAsi");

            var aluList = _alumnoService.GetAlumnoList().Result;
            ViewBag.AluList = new SelectList(aluList, "IdAlu", "NombreAlu", "ApellidoAlu");

            var paraList = _paraleloService.GetParaleloList().Result;
            ViewBag.ParaList = new SelectList(paraList, "IdPar", "IdPar");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Acta(string asignatura, string paralelo)
        {
            var asigList = _asignaturaService.GetAsignaturaList().Result;
            ViewBag.AsigList = new SelectList(asigList, "IdAsi", "NombreAsi");

            var paraList = _paraleloService.GetParaleloList().Result;
            ViewBag.ParaList = new SelectList(paraList, "IdPar", "IdPar");

            var userName = User.FindFirst(ClaimTypes.Name)?.Value;

            var alumnosMatriculados = await _matriculaService.GetAlumnosMatriculados(asignatura, paralelo);

            foreach (var alumnoMatriculado in alumnosMatriculados)
            {
                var calificacion = alumnoMatriculado.Matriculas.FirstOrDefault()?.Calificacions.FirstOrDefault();
                if (calificacion != null)
                {
                    var nuevaActa = new Actum
                    {
                        IdAct = await _actaService.GenerateNextId(),
                        IdCal = calificacion.IdCal
                    };

                    var actaResult = await _actaService.NewRegister(nuevaActa, userName);
                }
            }

            ViewData["MSG"] = "Registro realizado correctamente";
            return View();
        }

        public IActionResult Calificaciones()
        {
            var matList = _matriculaService.GetMatriculaList().Result;
            ViewBag.MatList = new SelectList(matList, "IdMat", "IdAlu");

            return View();
        }

    }
}
