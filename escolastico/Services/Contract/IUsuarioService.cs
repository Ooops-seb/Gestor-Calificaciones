using escolastico.Models;

namespace escolastico.Services.Contract
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUser (string userName, string password);
        Task<Usuario> SaveUser (string idUser, Usuario user);
    }
}