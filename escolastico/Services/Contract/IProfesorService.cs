using escolastico.Models;

namespace escolastico.Services.Contract
{
    public interface IProfesorService
    {
        Task<Profesor> FindUser(string idUser);
        Task<Profesor> GetInfo(string idUser);
        Task<Profesor> NewRegister(Profesor newRegister);
        Task<string> GenerateNextId();
        Task<List<Profesor>> GetProfesorList();
    }
}
