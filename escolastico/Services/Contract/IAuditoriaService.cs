using escolastico.Models;

namespace escolastico.Services.Contract
{
    public interface IAuditoriaService
    {
        void Audit(string usuario, string tablaAfectada, string sentencia);
        Task<List<Auditorium>> GetAllAuditoriaRecords();
    }
}
