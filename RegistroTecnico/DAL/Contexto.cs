using Microsoft.EntityFrameworkCore;
using RegistroTecnico.Migrations;
using RegistroTecnico.Models;
using RegistroTecnico.Services;


namespace RegistroTecnico.DAL
{
	public class Contexto : DbContext
	{
		public Contexto(DbContextOptions<Contexto> options)
		: base (options) { }

	  public DbSet<Tecnicos> Tecnicos { get; set;}
      public DbSet<Tipotecnico> TipoTecnico { get; set; }

    }
} 