using escolastico.Models;
using escolastico.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace escolastico.Services.Implementation
{
    public class AlumnoService: IAlumnoService
    {
        public readonly PrjEscolasticoContext _dbContext;
        private readonly IAuditoriaService _auditoriaService;
        public AlumnoService(PrjEscolasticoContext dbContext, IAuditoriaService auditoriaService)
        {
            _dbContext = dbContext;
            _auditoriaService = auditoriaService;
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
        public async Task<List<Alumno>> GetAlumnoList()
        {
            return await _dbContext.Alumnos.ToListAsync();
        }
        public async Task<Alumno> NewRegister(Alumno newRegister, string usuarioActual) {
            _dbContext.Alumnos.Add(newRegister);
            await _dbContext.SaveChangesAsync();

            string tablaAfectada = "Alumno";
            string sentencia = "INSERT";
            string detalles = $"ID: {newRegister.IdAlu}, Cedula: {newRegister.CedulaAlu}, Nombre: {newRegister.NombreAlu}, Apellido: {newRegister.ApellidoAlu}, Campus: {newRegister.IdCam}, Titulo: {newRegister.IdTit}, Creditos: {newRegister.CreditosAprobadosAlu}, Fecha Nacimiento: {newRegister.FechaNacimientoAlu}, Direccion: {newRegister.DireccionAlu}, Telefono: {newRegister.TelefonoAlu}, Correo: {newRegister.CorreoAlu}, Genero: {newRegister.GeneroAlu}, Usuario: {newRegister.UsuarioUsr}";
            string sentenciaCompleta = $"{sentencia}: {detalles}";
            _auditoriaService.Audit(usuarioActual, tablaAfectada, sentenciaCompleta);

            return newRegister;
        }
        public async Task<string> GenerateNextId(){
            var lastAlumno = await _dbContext.Alumnos.OrderByDescending(a => a.IdAlu).FirstOrDefaultAsync();

            if (lastAlumno != null)
            {
                var lastId = lastAlumno.IdAlu;
                var numericPart = int.Parse(lastId.Substring(1)) + 1;
                var newId = "S" + numericPart.ToString("D4");
                return newId;
            }
            else
            {
                return "S0001";
            }
        }
    }
}
