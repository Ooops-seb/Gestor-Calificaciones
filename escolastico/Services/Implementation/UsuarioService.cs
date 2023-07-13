using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using escolastico.Models;
using escolastico.Services.Contract;

namespace escolastico.Services.Implementation
{
    public class UsuarioService :IUsuarioService
    {
        public readonly PrjEscolasticoContext _dbContext;
        public UsuarioService(PrjEscolasticoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Usuario> GetUser(string userName, string password)
        {
            Usuario user_found = await _dbContext.Usuarios.Where(u => u.UsuarioUsr == userName && u.PasswordUsr == password).FirstOrDefaultAsync();
            return user_found;
        }
        public async Task<Usuario> SaveUser(Usuario user)
        {
            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}