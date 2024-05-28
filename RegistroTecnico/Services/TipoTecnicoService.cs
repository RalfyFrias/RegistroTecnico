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
        public async Task<bool> Existe(int Tecnicos)
        {
            return await _contexto.Tecnicos.AnyAsync(t => t.TipoId == Tecnicos);
        }

        // Método Insertar
        private async Task<bool> Insertar(Tecnicos tecnico)
        {
            _contexto.Tecnicos.Add(tecnico);
            return await _contexto.SaveChangesAsync() > 0;
        }

        // Método Modificar
        private async Task<bool> Modificar(Tecnicos tecnico)
        {
            _contexto.Tecnicos.Update(tecnico);
            return await _contexto.SaveChangesAsync() > 0;
        }

        // Método guardar
        public async Task<bool> Guardar(Tecnicos tecnico)
        {
            if (!await Existe(tecnico.TipoId))
                return await Insertar(tecnico);
            else
                return await Modificar(tecnico);
        }

        // Método eliminar
        public async Task<bool> Eliminar(int id)
        {
            var Tecnicos = await _contexto.Tecnicos.FindAsync(id);
            if (Tecnicos == null)
                return false;

            _contexto.Tecnicos.Remove(Tecnicos);
            return await _contexto.SaveChangesAsync() > 0;
        }

        // Método buscar
        public async Task<Tecnicos?> Buscar(int id)
        {
            return await _contexto.Tecnicos
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TipoId == id);
        }

        // Método listar
        public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
        {
            return await _contexto.Tecnicos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}

