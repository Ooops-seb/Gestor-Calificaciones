using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using escolastico.Models;
using escolastico.Services.Contract;
using escolastico.Resources;

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
        public async Task<Usuario> SaveUser(string idUser, Usuario user)
        {
            if(idUser.Substring(0,1) == "A")
            {
                _dbContext.Usuarios.Add(user);
                await _dbContext.SaveChangesAsync();

                var administrador = await _dbContext.Administradors.FirstOrDefaultAsync(a => a.IdAdm == idUser);
                if (administrador != null)
                {
                    administrador.UsuarioUsr = user.UsuarioUsr;
                    await _dbContext.SaveChangesAsync();
                }
            }
            else if(idUser.Substring(0,1) == "P")
            {
                _dbContext.Usuarios.Add(user);
                await _dbContext.SaveChangesAsync();

                var profesor = await _dbContext.Profesors.FirstOrDefaultAsync(a => a.IdPro == idUser);
                if (profesor != null)
                {
                    profesor.UsuarioUsr = user.UsuarioUsr;
                    await _dbContext.SaveChangesAsync();
                }
            }
            else if (idUser.Substring(0, 1) == "S")
            {
                _dbContext.Usuarios.Add(user);
                await _dbContext.SaveChangesAsync();

                var alumno = await _dbContext.Alumnos.FirstOrDefaultAsync(a => a.IdAlu == idUser);
                if (alumno != null)
                {
                    alumno.UsuarioUsr = user.UsuarioUsr;
                    await _dbContext.SaveChangesAsync();
                }
            }
            return user;
        }
    }
}