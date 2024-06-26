using Microsoft.EntityFrameworkCore;
using RegistroTecnico.Components;
using RegistroTecnico.DAL;
using RegistroTecnico.Models;
using RegistroTecnico.Service;
using RegistroTecnico.Services;



namespace RegistroTecnico
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var ConStr = builder.Configuration.GetConnectionString("ConStr");
            builder.Services.AddDbContext<Contexto>(Options => Options.UseSqlite(ConStr));
            builder.Services.AddScoped<TecnicosService>();
            builder.Services.AddScoped<TiposTecnicosService>();
            builder.Services.AddScoped<IncentivosTecnicoService>();

            builder.Services.AddBlazorBootstrap();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}