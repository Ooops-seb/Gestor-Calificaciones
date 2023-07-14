using escolastico.Models;

namespace escolastico.Services.Contract
{
    public interface IProfesorService
    {
        Task<Profesor> FindUser(string idUser);
        Task<Profesor> GetInfo(string idUser);
    }
}
