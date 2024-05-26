using Microsoft.EntityFrameworkCore;
using RegistroTecnico.Models;
using RegistroTecnico.DAL;
using System.Linq.Expressions;

namespace RegistroTecnico.Service;

public class TecnicoService
{
    private readonly Contexto Contexto;

    public TecnicoService(Contexto contexto)
    {
        Contexto = contexto;
    }

    // Método Existente
    public async Task<bool> Existe(int TecnicoId)
    {
        return await Contexto.Tecnicos.AnyAsync(p => p.TecnicoId == TecnicoId);
    }

    // Método Insertar
    private async Task<bool> Insertar(Tecnicos tecnico)
    {
        Contexto.Tecnicos.Add(tecnico);
        return await Contexto.SaveChangesAsync() > 0;
    }

    // Método Modificar
    private async Task<bool> Modificar(Tecnicos tecnico)
    {
        Contexto.Tecnicos.Update(tecnico);
        var modificado = await Contexto.SaveChangesAsync() > 0;
        Contexto.Entry(tecnico).State = EntityState.Detached;
        return modificado;
    }

    // Método Guardar
    public async Task<bool> Guardar(Tecnicos tecnico)
    {
        if (!await Existe(tecnico.TecnicoId))
            return await Insertar(tecnico);
        else
            return await Modificar(tecnico);
    }

    // Método Eliminar
    public async Task<bool> Eliminar(int id)
    {
        var tecnico = await Contexto.Tecnicos.FindAsync(id);
        if (tecnico != null)
        {
            Contexto.Tecnicos.Remove(tecnico);
            return await Contexto.SaveChangesAsync() > 0;
        }
        return false;
    }

    // Método Buscar
    public async Task<Tecnicos?> Buscar(int id)
    {
        return await Contexto.Tecnicos
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TecnicoId == id);
    }

    // Método Listar
    public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
    {
        return await Contexto.Tecnicos.Include(t => t.Tipotecnicos)
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
