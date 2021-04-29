using GestorFactura.Domain.Comun;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorFactura.Domain.Entidades
{
    public class ProductoFactura : EntidadAuditora
    {
        public int Id { get; set; }
        public int idFactura { get; set; }
        public string producto { get; set; }
        public double cantidad { get; set; }
        public double tipo { get; set; }
        public Factura factura { get; set; }


    }
}
