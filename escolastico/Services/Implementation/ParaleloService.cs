using escolastico.Models;
using escolastico.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace escolastico.Services.Implementation
{
    public class ParaleloService : IParaleloService
    {
        private readonly PrjEscolasticoContext _dbContext;
        private readonly IAuditoriaService _auditoriaService;
        public ParaleloService(PrjEscolasticoContext dbContext, IAuditoriaService auditoriaService)
        {
            _dbContext = dbContext;
            _auditoriaService = auditoriaService;
        }
    
        public async Task<List<Paralelo>> GetParaleloList()
        {
            return await _dbContext.Paralelos.ToListAsync();
        }
        public async Task<Paralelo> NewRegister(Paralelo newRegister, string usuarioActual)
        {
            _dbContext.Paralelos.Add(newRegister);
            await _dbContext.SaveChangesAsync();

            string tablaAfectada = "Paralelo";
            string sentencia = "INSERT";
            string detalles = $"ID: {newRegister.IdPar}, Nombre: {newRegister.NombrePar},Horario: {newRegister.HorarioPar}, Alumnos: {newRegister.AlumnosRegistradosPar}";
            string sentenciaCompleta = $"{sentencia}: {detalles}";
            _auditoriaService.Audit(usuarioActual, tablaAfectada, sentenciaCompleta);

            return newRegister;
        }
        public async Task<string> GenerateNextId()
        {
            var lastPar = await _dbContext.Paralelos.OrderByDescending(a => a.IdPar).FirstOrDefaultAsync();

            if (lastPar != null)
            {
                var lastId = lastPar.IdPar;
                var numericPart = int.Parse(lastId.Substring(1)) + 1;
                var newId = "N" + numericPart.ToString("D4");
                return newId;
            }
            else
            {
                return "N0001";
            }
        }
    }
}
