using escolastico.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using escolastico.Models;

namespace escolastico.Controllers.EscolasticControl
{
    [Authorize]
    public class HistoryController : Controller
    {
        private readonly IAuditoriaService _auditoriaService;
        public HistoryController(IAuditoriaService auditoriaService)
        {
            _auditoriaService = auditoriaService;
        }
        public async Task<IActionResult> Index()
        {
            var auditoria = await _auditoriaService.GetAllAuditoriaRecords();
            return View(auditoria);
        }
    }
}
