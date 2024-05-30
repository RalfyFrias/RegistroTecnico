using Microsoft.EntityFrameworkCore;
using RegistroTecnico.DAL;
using RegistroTecnico.Migrations;
using RegistroTecnico.Models;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace RegistroTecnico.Services
{
    public class TiposTecnicosService
    {
        private readonly Contexto _contexto;

        public TiposTecnicosService(Contexto contexto)
        {
            _contexto = contexto;
        }

        // Método Existente
        public async Task<bool> Existe(int tipostecnicos)
        {
            return await _contexto.Tecnicos.AnyAsync(t => t.TipoId == tipostecnicos);
        }

        // Método Insertar
        private async Task<bool> Insertar(Tipostecnicos tipostecnicos)
        {
            _contexto.TiposTecnicos.Add(tipostecnicos);
            return await _contexto.SaveChangesAsync() > 0;
        }

        // Método Modificar
        private async Task<bool> Modificar(Tipostecnicos tipostecnicos)
        {
            _contexto.TiposTecnicos.Update(tipostecnicos);
            return await _contexto.SaveChangesAsync() > 0;
        }

        // Método guardar
        public async Task<bool> Guardar(Tipostecnicos tipostecnicos)
        {
            if (!await Existe(tipostecnicos.TipoId))
                return await Insertar(tipostecnicos);
            else
                return await Modificar(tipostecnicos);
        }

        // Método eliminar
        public async Task<bool> Eliminar(int id)
        {
            var Tecnicos = await _contexto.TiposTecnicos.FindAsync(id);
            if (Tecnicos == null)
                return false;

            _contexto.TiposTecnicos.Remove(Tecnicos);
            return await _contexto.SaveChangesAsync() > 0;
        }

        // Método buscar
        public async Task<Tipostecnicos?> Buscar(int id)
        {
            return await _contexto.TiposTecnicos
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TipoId == id);
        }

        // Método listar
        public async Task<List<Tipostecnicos>> Listar(Expression<Func<Tipostecnicos, bool>> criterio)
        {
            return await _contexto.TiposTecnicos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}

