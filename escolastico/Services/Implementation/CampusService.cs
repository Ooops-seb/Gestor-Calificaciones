﻿using escolastico.Models;
using escolastico.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace escolastico.Services.Implementation
{
    public class CampusService: ICampusService
    {
        public readonly PrjEscolasticoContext _dbContext;
        private readonly IAuditoriaService _auditoriaService;
        public CampusService(PrjEscolasticoContext dbContext, IAuditoriaService auditoriaService)
        {
            _dbContext = dbContext;
            _auditoriaService = auditoriaService;
        }
        public async Task<List<Campus>> GetCampusList()
        {
            return await _dbContext.Campuses.ToListAsync();
        }
        public async Task<Campus> NewRegister(Campus newRegister, string usuarioActual)
        {
            _dbContext.Campuses.Add(newRegister);
            await _dbContext.SaveChangesAsync();

            string tablaAfectada = "Campus";
            string sentencia = "INSERT";
            string detalles = $"ID: {newRegister.IdCam}, Nombre: {newRegister.NombreCam}, Direccion: {newRegister.DireccionCam}";
            string sentenciaCompleta = $"{sentencia}: {detalles}";
            _auditoriaService.Audit(usuarioActual, tablaAfectada, sentenciaCompleta);

            return newRegister;
        }
        public async Task<string> GenerateNextId()
        {
            var lastCamp = await _dbContext.Campuses.OrderByDescending(a => a.IdCam).FirstOrDefaultAsync();

            if (lastCamp != null)
            {
                var lastId = lastCamp.IdCam;
                var numericPart = int.Parse(lastId.Substring(1)) + 1;
                var newId = "C" + numericPart.ToString("D4");
                return newId;
            }
            else
            {
                return "C0001";
            }
        }
    }
}
