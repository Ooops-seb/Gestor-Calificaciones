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
    }
}
