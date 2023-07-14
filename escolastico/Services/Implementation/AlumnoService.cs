using escolastico.Models;
using escolastico.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace escolastico.Services.Implementation
{
    public class AlumnoService: IAlumnoService
    {
        public readonly PrjEscolasticoContext _dbContext;
        public AlumnoService(PrjEscolasticoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Alumno> FindUser(string idUser)
        {
            Alumno user_found = await _dbContext.Alumnos.Where(u => u.IdAlu == idUser && u.UsuarioUsr == null).FirstOrDefaultAsync();
            return user_found;
        }
        public async Task<Alumno> GetInfo(string userName)
        {
            Alumno user_info = await _dbContext.Alumnos.Where(a => a.UsuarioUsr == userName).FirstOrDefaultAsync();
            return user_info;
        }
    }
}
