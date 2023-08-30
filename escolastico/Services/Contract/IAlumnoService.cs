using escolastico.Models;

namespace escolastico.Services.Contract
{
    public interface IAlumnoService
    {
        Task<Alumno> FindUser(string idUser);
        Task<Alumno> GetInfo(string idUser);
        Task<Alumno> NewRegister(Alumno newRegister);
        Task<string> GenerateNextId();
    }
}
