using Microsoft.EntityFrameworkCore;
using RegistroTecnico.DAL;
using RegistroTecnico.Migrations;
using RegistroTecnico.Models;
using System.Linq.Expressions;

namespace RegistroTecnico.Services
{
    public class TipoTecnicoService
    {
        private readonly Contexto _contexto;

        public TipoTecnicoService(Contexto contexto)
        {
            _contexto = contexto;
        }

        // Método Existente
        public async Task<bool> Existe(int TipoTecnicoId)
        {
            return await _contexto.TipoTecnico.AnyAsync(t => t.TipoId == TipoTecnicoId);
        }

        // Método Insertar
        private async Task<bool> Insertar(Tipotecnico tipoTecnicos)
        {
            _contexto.TipoTecnico.Add(tipoTecnicos);
            return await _contexto.SaveChangesAsync() > 0;
        }

        // Método Modificar
        private async Task<bool> Modificar(Tipotecnico tipoTecnicos)
        {
            _contexto.TipoTecnico.Update(tipoTecnicos);
            return await _contexto.SaveChangesAsync() > 0;
        }

        // Método guardar
        public async Task<bool> Guardar(Tipotecnico tipoTecnicos)
        {
            if (!await Existe(tipoTecnicos.TipoId))
                return await Insertar(tipoTecnicos);
            else
                return await Modificar(tipoTecnicos);
        }

        // Método eliminar
        public async Task<bool> Eliminar(int id)
        {
            var tipoTecnico = await _contexto.TipoTecnico.FindAsync(id);
            if (tipoTecnico == null)
                return false;

            _contexto.TipoTecnico.Remove(tipoTecnico);
            return await _contexto.SaveChangesAsync() > 0;
        }

        // Método buscar
        public async Task<Tipotecnico?> Buscar(int id)
        {
            return await _contexto.TipoTecnico
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TipoId == id);
        }

        // Método listar
        public async Task<List<Tipotecnico>> Listar(Expression<Func<Tipotecnico, bool>> criterio)
        {
            return await _contexto.TipoTecnico
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}

