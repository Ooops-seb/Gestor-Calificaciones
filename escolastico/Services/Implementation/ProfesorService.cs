using escolastico.Models;
using escolastico.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace escolastico.Services.Implementation
{
    public class ProfesorService : IProfesorService
    {
        public readonly PrjEscolasticoContext _dbContext;
        public ProfesorService(PrjEscolasticoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Profesor> FindUser(string idUser)
        {
            Profesor user_found = await _dbContext.Profesors.Where(u => u.IdPro == idUser && u.UsuarioUsr == null).FirstOrDefaultAsync();
            return user_found;
        }

        public async Task<Profesor> GetInfo(string userName)
        {
            Profesor user_info = await _dbContext.Profesors.Where(a => a.UsuarioUsr == userName).FirstOrDefaultAsync();
            return user_info;
        }
        public async Task<List<Profesor>> GetProfesorList()
        {
            return await _dbContext.Profesors.ToListAsync();
        }
        public async Task<Profesor> NewRegister(Profesor newRegister)
        {
            _dbContext.Profesors.Add(newRegister);
            await _dbContext.SaveChangesAsync();

            return newRegister;
        }
        public async Task<string> GenerateNextId()
        {
            var lastProf = await _dbContext.Profesors.OrderByDescending(a => a.IdPro).FirstOrDefaultAsync();

            if (lastProf != null)
            {
                var lastId = lastProf.IdPro;
                var numericPart = int.Parse(lastId.Substring(1)) + 1;
                var newId = "P" + numericPart.ToString("D4");
                return newId;
            }
            else
            {
                return "P0001";
            }
        }
    }
}
