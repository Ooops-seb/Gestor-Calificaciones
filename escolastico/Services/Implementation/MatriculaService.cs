using escolastico.Models;
using escolastico.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace escolastico.Services.Implementation
{
    public class MatriculaService: IMatriculaService
    {
        private readonly PrjEscolasticoContext _context;
        private readonly IAuditoriaService _auditoriaService;
        public MatriculaService(PrjEscolasticoContext prjEscolasticoContext,  IAuditoriaService auditoriaService)
        {
            _context = prjEscolasticoContext;
            _auditoriaService = auditoriaService;
        }
        public async Task<List<Matricula>> GetMatriculaList()
        {
            return await _context.Matriculas.ToListAsync();
        }
        public async Task<string> GenerateNextId()
        {
            var lastMat = await _context.Matriculas.OrderByDescending(a => a.IdMat).FirstOrDefaultAsync();

            if (lastMat != null)
            {
                var lastId = lastMat.IdMat;
                var numericPart = int.Parse(lastId.Substring(1)) + 1;
                var newId = "G" + numericPart.ToString("D4");
                return newId;
            }
            else
            {
                return "G0001";
            }
        }
        public async Task<Matricula> NewRegister(Matricula newRegister, string usuarioActual)
        {
            _context.Matriculas.Add(newRegister);
            await _context.SaveChangesAsync();

            string tablaAfectada = "Matricula";
            string sentencia = "INSERT";
            string detalles = $"ID: {newRegister.IdPar}, Alumno: {newRegister.IdAlu}, Asignatura: {newRegister.IdAsi}, Paralelo: {newRegister.IdPar}";
            string sentenciaCompleta = $"{sentencia}: {detalles}";
            _auditoriaService.Audit(usuarioActual, tablaAfectada, sentenciaCompleta);

            return newRegister;
        }
        public async Task<Matricula> GetMatriculaById(string matriculaId)
        {
            var matricula = await _context.Matriculas
                .FirstOrDefaultAsync(m => m.IdMat == matriculaId);

            return matricula;
        }
        public async Task<List<Alumno>> GetAlumnosMatriculados(string asignatura, string paralelo)
        {
            var alumnosMatriculados = await _context.Matriculas
                .Where(m => m.IdAsi == asignatura && m.IdPar == paralelo)
                .Select(m => m.IdAluNavigation) 
                .ToListAsync();

            return alumnosMatriculados;
        }
    }
}
