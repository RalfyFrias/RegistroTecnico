﻿using RegistroTecnico.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RegistroTecnico.DAL;

namespace RegistroTecnico.Services
{
    public class IncentivosTecnicoService
    {
        private readonly Contexto Contexto;

        public IncentivosTecnicoService(Contexto contexto)
        {
            Contexto = contexto;
        }

        public async Task<bool> Existe(int incentivoId)
        {
            return await Contexto.IncentivosTecnicos.AnyAsync(t => t.IncentivoId == incentivoId);
        }


        public async Task<bool> Existe(string descripcion)
        {
            return await Contexto.IncentivosTecnicos.AnyAsync(t => t.Descripcion.ToLower() == descripcion.ToLower());
        }


        private async Task<bool> Insertar(IncentivosTecnicos incentivo)
        {
            Contexto.Add(incentivo);
            return await Contexto.SaveChangesAsync() > 0;
        }


        private async Task<bool> Modificar(IncentivosTecnicos incentivo)
        {
            Contexto.IncentivosTecnicos.Update(incentivo);
            return await Contexto.SaveChangesAsync() > 0;
        }


        public async Task<bool> Guardar(IncentivosTecnicos incentivo)
        {
            if (!await Existe(incentivo.IncentivoId))
                return await Insertar(incentivo);
            else
                return await Modificar(incentivo);
        }

        public async Task<bool> Eliminar(int id)
        {
            var incentivo = await Contexto.IncentivosTecnicos.FindAsync(id);
            if (incentivo == null)
                return false;

            Contexto.IncentivosTecnicos.Remove(incentivo);
            return await Contexto.SaveChangesAsync() > 0;
        }


        public async Task<IncentivosTecnicos?> Buscar(int id)
        {
            return await Contexto.IncentivosTecnicos.AsNoTracking().FirstOrDefaultAsync(t => t.IncentivoId == id);
        }

        public async Task<List<IncentivosTecnicos>> Listar(Expression<Func<IncentivosTecnicos, bool>> criterio)
        {   
            return await Contexto.IncentivosTecnicos.AsNoTracking().Where(criterio).ToListAsync();
        }
    }
}