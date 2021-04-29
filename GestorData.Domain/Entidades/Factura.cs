using GestorFactura.Domain.Comun;
using GestorFactura.Domain.numeracion;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorFactura.Domain.Entidades
{
    public class Factura : EntidadAuditora
    {
        public Factura()
        {
            this.productoF = new List<ProductoFactura>();
        }

        public int id { get; set; }
        public string numeroFactura { get; set;}
        public string logo { get; set; }
        public string proviene { get; set; }
        public string hacia { get; set; }
        public DateTime fecha { get; set; }
        public string terminosDePago { get; set; }
        public DateTime? FechadeVencimiento { get; set; }
        public double descuento { get; set; }
        public TipoDescuento TipoDescuento { get; set; }
        public double impuesto { get; set; }
        public TipoImpuesto TipoImpuesto { get; set; }
        public double MontoPagado { get; set; }

        public IList<ProductoFactura> productoF { get; set; }

    }
}
