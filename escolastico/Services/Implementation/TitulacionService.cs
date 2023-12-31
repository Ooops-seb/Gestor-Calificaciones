﻿using escolastico.Models;
using escolastico.Services.Contract;
using Microsoft.EntityFrameworkCore;
using System;

namespace escolastico.Services.Implementation
{
    public class TitulacionService :ITitulacionService
    {
        private readonly PrjEscolasticoContext _dbContext;
        private readonly IAuditoriaService _auditoriaService;

        public TitulacionService(PrjEscolasticoContext dbContext, IAuditoriaService auditoriaService)
        {
            _dbContext = dbContext;
            _auditoriaService = auditoriaService;
        }
        public async Task<List<Titulacion>> GetTitulacionList()
        {
            return await _dbContext.Titulacions.ToListAsync();
        }
        public async Task<Titulacion> NewRegister(Titulacion newRegister, string usuarioActual)
        {
            _dbContext.Titulacions.Add(newRegister);
            await _dbContext.SaveChangesAsync();

            string tablaAfectada = "Titulacion";
            string sentencia = "INSERT";
            string detalles = $"ID: {newRegister.IdTit}, Nombre: {newRegister.NombreTit}, Creditos: {newRegister.CreditosTotalesTit}";
            string sentenciaCompleta = $"{sentencia}: {detalles}";
            _auditoriaService.Audit(usuarioActual, tablaAfectada, sentenciaCompleta);

            return newRegister;
        }
        public async Task<string> GenerateNextId()
        {
            var lastTit = await _dbContext.Titulacions.OrderByDescending(a => a.IdTit).FirstOrDefaultAsync();

            if (lastTit != null)
            {
                var lastId = lastTit.IdTit;
                var numericPart = int.Parse(lastId.Substring(1)) + 1;
                var newId = "T" + numericPart.ToString("D4");
                return newId;
            }
            else
            {
                return "T0001";
            }
        }
    }
}
