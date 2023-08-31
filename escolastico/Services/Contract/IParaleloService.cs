using escolastico.Models;

namespace escolastico.Services.Contract
{
    public interface IParaleloService
    {
        Task<List<Paralelo>> GetParaleloList();
        Task<Paralelo> NewRegister(Paralelo newRegister, string usuarioActual);
        Task<string> GenerateNextId();
    }
}
