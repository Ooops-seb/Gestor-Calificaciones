using escolastico.Models;
using escolastico.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace escolastico.Services.Implementation
{
    public class AdministradorService :IAdministradorService
    {
        public readonly PrjEscolasticoContext _dbContext;
        private readonly IAuditoriaService _auditoriaService;
        public AdministradorService(PrjEscolasticoContext dbContext, IAuditoriaService auditoriaService)
        {
            _dbContext = dbContext;
            _auditoriaService = auditoriaService;
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
        public async Task<Administrador> NewRegister(Administrador newRegister, string usuarioActual)
        {
            _dbContext.Administradors.Add(newRegister);
            await _dbContext.SaveChangesAsync();

            string tablaAfectada = "Administrador";
            string sentencia = "INSERT";
            string detalles = $"ID: {newRegister.IdAdm}, Cedula: {newRegister.CedulaAdm}, Nombre: {newRegister.NombreAdm}, Apellido: {newRegister.ApellidoAdm}, Fecha Nacimiento: {newRegister.FechaNacimientoAdm}, Direccion: {newRegister.DireccionAdm}, Telefono: {newRegister.TelefonoAdm}, Correo: {newRegister.CorreoAdm}, Genero: {newRegister.GeneroAdm}, Usuario: {newRegister.UsuarioUsr}";
            string sentenciaCompleta = $"{sentencia}: {detalles}";
            _auditoriaService.Audit(usuarioActual, tablaAfectada, sentenciaCompleta);

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
