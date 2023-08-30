using escolastico.Models;

namespace escolastico.Services.Contract
{
    public interface IAdministradorService
    {
        Task<Administrador> FindUser(string idUser);
        Task<Administrador> GetInfo(string idUser);
        Task<Administrador> NewRegister(Administrador newRegister);
        Task<string> GenerateNextId();
    }
}
