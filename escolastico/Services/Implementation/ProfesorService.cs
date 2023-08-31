using escolastico.Models;
using escolastico.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace escolastico.Services.Implementation
{
    public class ProfesorService : IProfesorService
    {
        public readonly PrjEscolasticoContext _dbContext;
        private readonly IAuditoriaService _auditoriaService;
        public ProfesorService(PrjEscolasticoContext dbContext, IAuditoriaService auditoriaService)
        {
            _dbContext = dbContext;
            _auditoriaService = auditoriaService;
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
        public async Task<Profesor> NewRegister(Profesor newRegister, string usuarioActual)
        {
            _dbContext.Profesors.Add(newRegister);
            await _dbContext.SaveChangesAsync();

            string tablaAfectada = "Profesor";
            string sentencia = "INSERT";
            string detalles = $"ID: {newRegister.IdPro}, Cedula: {newRegister.CedulaPro}, Nombre: {newRegister.NombrePro}, Apellido: {newRegister.ApellidoPro}, Fecha Nacimiento: {newRegister.FechaNacimientoPro}, Direccion: {newRegister.DireccionPro}, Telefono: {newRegister.TelefonoPro}, Correo: {newRegister.CorreoPro}, Genero: {newRegister.GeneroPro}, Usuario: {newRegister.UsuarioUsr}";
            string sentenciaCompleta = $"{sentencia}: {detalles}";
            _auditoriaService.Audit(usuarioActual, tablaAfectada, sentenciaCompleta);

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
