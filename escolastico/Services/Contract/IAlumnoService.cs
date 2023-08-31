using escolastico.Models;

namespace escolastico.Services.Contract
{
    public interface IAlumnoService
    {
        Task<Alumno> FindUser(string idUser);
        Task<Alumno> GetInfo(string idUser);
        Task<List<Alumno>> GetAlumnoList();
        Task<Alumno> NewRegister(Alumno newRegister, string usuarioActual);
        Task<string> GenerateNextId();
    }
}
