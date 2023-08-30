using escolastico.Models;
using escolastico.Services.Contract;
using Microsoft.EntityFrameworkCore;
using System;

namespace escolastico.Services.Implementation
{
    public class TitulacionService :ITitulacionService
    {
        private readonly PrjEscolasticoContext _dbContext;

        public TitulacionService(PrjEscolasticoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Titulacion>> GetTitulacionList()
        {
            return await _dbContext.Titulacions.ToListAsync();
        }
        public async Task<Titulacion> NewRegister(Titulacion newRegister)
        {
            _dbContext.Titulacions.Add(newRegister);
            await _dbContext.SaveChangesAsync();

            return newRegister;
        }
        public async Task<string> GenerateNextId()
        {
            var lastTit = await _dbContext.Titulacions.OrderByDescending(a => a.IdTit).FirstOrDefaultAsync();

            if (lastTit != null)
            {
                var lastId = lastTit.IdTit;
                var numericPart = int.Parse(lastId.Substring(1)) + 1;
                var newId = "T" + numericPart.ToString("D4");
                return newId;
            }
            else
            {
                return "T0001";
            }
        }
    }
}
