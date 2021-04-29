using GestorFactura.Applicaction.Comun.Interfaces;
using GestorFactura.Domain.Comun;
using GestorFactura.Domain.Entidades;
using GestorFactura.Infrastructure.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GestorFactura.Infrastructure.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IAplicacionDbContenido
    {
        private readonly IServiciosUsuariosPrincipal _serviciosUsuariosPrincipal;

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            IServiciosUsuariosPrincipal serviciosUsuariosPrincipal) : base(options, operationalStoreOptions)
        {
            _serviciosUsuariosPrincipal = serviciosUsuariosPrincipal;
        }

        public DbSet<Factura> Facturas { get; set; }
        public DbSet<ProductoFactura> ProductoFacturas { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach(var entrada in ChangeTracker.Entries<EntidadAuditora>())
            {
                switch (entrada.State)
                { 
                    case EntityState.Added:
                        entrada.Entity.creadoPor = _serviciosUsuariosPrincipal.idUsuario;
                        entrada.Entity.creado = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entrada.Entity.ultimaVezModificadoPor = _serviciosUsuariosPrincipal.idUsuario;
                        entrada.Entity.ultimaVezModificado = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
