using escolastico.Models;

namespace escolastico.Services.Contract
{
    public interface IMatriculaService
    {
        Task<List<Matricula>> GetMatriculaList();
        Task<string> GenerateNextId();
        Task<Matricula> NewRegister(Matricula newRegister, string usuarioActual);
        Task<List<Alumno>> GetAlumnosMatriculados(string asignatura, string paralelo);
    }
}
