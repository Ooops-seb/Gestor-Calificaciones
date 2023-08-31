using escolastico.Models;
using escolastico.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace escolastico.Services.Implementation
{
    public class AuditoriaService : IAuditoriaService
    {
        private readonly PrjEscolasticoContext _context;

        public AuditoriaService(PrjEscolasticoContext context)
        {
            _context = context;
        }

        public void Audit(string usuario, string tablaAfectada, string sentencia)
        {
            var auditoria = new Auditorium
            {
                Fecha = DateTime.Now,
                Usuario = usuario,
                TablaAfectada = tablaAfectada,
                Sentencia = sentencia
            };

            _context.Auditoria.Add(auditoria);
            _context.SaveChanges();
        }
        public async Task<List<Auditorium>> GetAllAuditoriaRecords()
        {
            return await _context.Auditoria.ToListAsync();
        }
    }
}
