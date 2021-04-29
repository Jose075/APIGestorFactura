using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorFactura.Infrastructure.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GestorFactura.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using var alcance = host.Services.CreateScope();
            var servicios = alcance.ServiceProvider;
            try
            {
                var contenido = servicios.GetRequiredService<ApplicationDbContext>();
                contenido.Database.Migrate();

            }
            catch(Exception ex)
            {
                var logeador = alcance.ServiceProvider.GetRequiredService<ILogger<Program>>();
                logeador.LogError(ex, "Un error ha ocurrido mientras se estaba migrando o enviando la base de datos");
            }

            host.Run();


        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
                
    }
}
