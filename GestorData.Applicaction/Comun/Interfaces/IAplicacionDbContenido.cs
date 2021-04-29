using GestorFactura.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GestorFactura.Applicaction.Comun.Interfaces
{
    public interface IAplicacionDbContenido
    {
        DbSet<Factura> Facturas { get; set; }
        DbSet<ProductoFactura> ProductoFacturas { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken); 
    }
}
