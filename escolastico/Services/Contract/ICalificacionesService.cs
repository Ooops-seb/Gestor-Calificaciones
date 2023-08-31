using escolastico.Models;

namespace escolastico.Services.Contract
{
    public interface ICalificacionesService
    {
        Task<List<Calificacion>> GetCalificacionList();
        Task<Calificacion> NewRegister(Calificacion newRegister, string usuarioActual);
        Task<string> GenerateNextId();
    }
}
