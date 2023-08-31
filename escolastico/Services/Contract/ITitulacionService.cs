using escolastico.Models;

namespace escolastico.Services.Contract
{
    public interface ITitulacionService
    {
        Task<List<Titulacion>> GetTitulacionList();
        Task<Titulacion> NewRegister(Titulacion newRegister, string usuarioActual);
        Task<string> GenerateNextId();
    }
}
