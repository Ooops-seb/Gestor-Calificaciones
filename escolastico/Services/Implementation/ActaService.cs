using escolastico.Models;
using escolastico.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace escolastico.Services.Implementation
{
    public class ActaService : IActaService
    {
        public readonly PrjEscolasticoContext _dbContext;
        private readonly IAuditoriaService _auditoriaService;
        public ActaService(PrjEscolasticoContext dbContext, IAuditoriaService auditoriaService)
        {
            _dbContext = dbContext;
            _auditoriaService = auditoriaService;
        }
        public async Task<List<Actum>> GetActumList()
        {
            return await _dbContext.Acta.ToListAsync();
        }
        public async Task<Actum> NewRegister(Actum newRegister, string usuarioActual)
        {
            _dbContext.Acta.Add(newRegister);
            await _dbContext.SaveChangesAsync();

            string tablaAfectada = "Acta";
            string sentencia = "INSERT";
            string detalles = $"ID: {newRegister.IdAct} Calificacion: {newRegister.IdCal}";
            string sentenciaCompleta = $"{sentencia}: {detalles}";
            _auditoriaService.Audit(usuarioActual, tablaAfectada, sentenciaCompleta);

            return newRegister;
        }
        public async Task<string> GenerateNextId()
        {
            var lastAct = await _dbContext.Acta.OrderByDescending(a => a.IdAct).FirstOrDefaultAsync();

            if (lastAct != null)
            {
                var lastId = lastAct.IdAct;
                var numericPart = int.Parse(lastId.Substring(1)) + 1;
                var newId = "D" + numericPart.ToString("D4");
                return newId;
            }
            else
            {
                return "D0001";
            }
        }
    }
}
