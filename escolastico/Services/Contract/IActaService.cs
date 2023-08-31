using escolastico.Models;

namespace escolastico.Services.Contract
{
    public interface IActaService
    {
        Task<List<Actum>> GetActumList();
        Task<Actum> NewRegister(Actum newRegister, string usuarioActual);
        Task<string> GenerateNextId();
    }
}
