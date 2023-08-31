using escolastico.Models;
using escolastico.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace escolastico.Services.Implementation
{
    public class AsignaturaService :IAsignaturaService
    {
        public readonly PrjEscolasticoContext _dbContext;
        private readonly IAuditoriaService _auditoriaService;
        public AsignaturaService(PrjEscolasticoContext dbContext, IAuditoriaService auditoriaService)
        {
            _dbContext = dbContext;
            _auditoriaService = auditoriaService;
        }
        public async Task<List<Asignatura>> GetAsignaturaList()
        {
            return await _dbContext.Asignaturas.ToListAsync();
        }
        public async Task<Asignatura> NewRegister(Asignatura newRegister, string usuarioActual)
        {
            _dbContext.Asignaturas.Add(newRegister);
            await _dbContext.SaveChangesAsync();

            string tablaAfectada = "Asignatura";
            string sentencia = "INSERT";
            string detalles = $"ID: {newRegister.IdAsi} Nombre: {newRegister.NombreAsi}, Créditos: {newRegister.CreditosAsi}, Profesor: {newRegister.IdPro}";
            string sentenciaCompleta = $"{sentencia}: {detalles}";
            _auditoriaService.Audit(usuarioActual, tablaAfectada, sentenciaCompleta);

            return newRegister;
        }
        public async Task<string> GenerateNextId()
        {
            var lastAsig = await _dbContext.Asignaturas.OrderByDescending(a => a.IdAsi).FirstOrDefaultAsync();

            if (lastAsig != null)
            {
                var lastId = lastAsig.IdAsi;
                var numericPart = int.Parse(lastId.Substring(1)) + 1;
                var newId = "M" + numericPart.ToString("D4");
                return newId;
            }
            else
            {
                return "M0001";
            }
        }
    }
}
