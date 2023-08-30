using escolastico.Models;
using escolastico.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace escolastico.Services.Implementation
{
    public class AsignaturaService :IAsignaturaService
    {
        public readonly PrjEscolasticoContext _dbContext;
        public AsignaturaService(PrjEscolasticoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Asignatura>> GetAsignaturaList()
        {
            return await _dbContext.Asignaturas.ToListAsync();
        }
        public async Task<Asignatura> NewRegister(Asignatura newRegister)
        {
            _dbContext.Asignaturas.Add(newRegister);
            await _dbContext.SaveChangesAsync();
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
