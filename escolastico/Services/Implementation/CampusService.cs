using escolastico.Models;
using escolastico.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace escolastico.Services.Implementation
{
    public class CampusService: ICampusService
    {
        public readonly PrjEscolasticoContext _dbContext;
        public CampusService(PrjEscolasticoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Campus>> GetCampusList()
        {
            return await _dbContext.Campuses.ToListAsync();
        }
        public async Task<Campus> NewRegister(Campus newRegister)
        {
            _dbContext.Campuses.Add(newRegister);
            await _dbContext.SaveChangesAsync();
            return newRegister;
        }
        public async Task<string> GenerateNextId()
        {
            var lastCamp = await _dbContext.Campuses.OrderByDescending(a => a.IdCam).FirstOrDefaultAsync();

            if (lastCamp != null)
            {
                var lastId = lastCamp.IdCam;
                var numericPart = int.Parse(lastId.Substring(1)) + 1;
                var newId = "C" + numericPart.ToString("D4");
                return newId;
            }
            else
            {
                return "C0001";
            }
        }
    }
}
