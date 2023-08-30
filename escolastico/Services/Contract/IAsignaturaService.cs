using escolastico.Models;

namespace escolastico.Services.Contract
{
    public interface IAsignaturaService
    {
        Task<List<Asignatura>> GetAsignaturaList();
        Task<string> GenerateNextId();
        Task<Asignatura> NewRegister(Asignatura newRegister);
    }
}
