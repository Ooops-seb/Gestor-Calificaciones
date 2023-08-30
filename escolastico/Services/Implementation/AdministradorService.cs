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
        public async Task<Administrador> NewRegister(Administrador newRegister)
        {
            _dbContext.Administradors.Add(newRegister);
            await _dbContext.SaveChangesAsync();

            return newRegister;
        }
        public async Task<string> GenerateNextId()
        {
            var lastAdmin = await _dbContext.Administradors.OrderByDescending(a => a.IdAdm).FirstOrDefaultAsync();

            if (lastAdmin != null)
            {
                var lastId = lastAdmin.IdAdm;
                var numericPart = int.Parse(lastId.Substring(1)) + 1;
                var newId = "A" + numericPart.ToString("D4");
                return newId;
            }
            else
            {
                return "A0001";
            }
        }
    }
}
