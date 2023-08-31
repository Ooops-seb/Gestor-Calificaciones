using escolastico.Models;
using escolastico.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace escolastico.Services.Implementation
{
    public class CalificacionesService: ICalificacionesService
    {
        public readonly PrjEscolasticoContext _dbContext;
        private readonly IAuditoriaService _auditoriaService;
        public CalificacionesService(PrjEscolasticoContext dbContext, IAuditoriaService auditoriaService)
        {
            _dbContext = dbContext;
            _auditoriaService = auditoriaService;
        }
        public async Task<List<Calificacion>> GetCalificacionList()
        {
            return await _dbContext.Calificacions.ToListAsync();
        }
        public async Task<Calificacion> NewRegister(Calificacion newRegister, string usuarioActual)
        {
            _dbContext.Calificacions.Add(newRegister);
            await _dbContext.SaveChangesAsync();

            string tablaAfectada = "Calificaciones";
            string sentencia = "INSERT";
            string detalles = $"ID: {newRegister.IdCal} Matricula: {newRegister.IdMat}, Nota U1: {newRegister.NotaU1Cal}, Nota U2: {newRegister.NotaU2Cal}, Nota U3: {newRegister.Notau3Cal}";
            string sentenciaCompleta = $"{sentencia}: {detalles}";
            _auditoriaService.Audit(usuarioActual, tablaAfectada, sentenciaCompleta);

            return newRegister;
        }
        public async Task<string> GenerateNextId()
        {
            var lastCal = await _dbContext.Calificacions.OrderByDescending(a => a.IdCal).FirstOrDefaultAsync();

            if (lastCal != null)
            {
                var lastId = lastCal.IdCal;
                var numericPart = int.Parse(lastId.Substring(1)) + 1;
                var newId = "K" + numericPart.ToString("D4");
                return newId;
            }
            else
            {
                return "K0001";
            }
        }
    }
}
