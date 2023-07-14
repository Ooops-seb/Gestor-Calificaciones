using escolastico.Models;
using escolastico.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace escolastico.Services.Implementation
{
    public class AdministradorService :IAdministradorService
    {
        public readonly PrjEscolasticoContext _dbContext;
        public AdministradorService(PrjEscolasticoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Administrador> FindUser(string idUser)
        {
            Administrador user_found = await _dbContext.Administradors.Where(u => u.IdAdm == idUser && u.UsuarioUsr == null).FirstOrDefaultAsync();
            return user_found;
        }
        public async Task<Administrador> GetInfo(string userName)
        {
            Administrador user_info = await _dbContext.Administradors.Where(a => a.UsuarioUsr == userName).FirstOrDefaultAsync();
            return user_info;
        }
    }
}
