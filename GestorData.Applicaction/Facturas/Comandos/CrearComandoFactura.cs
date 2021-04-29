using GestorFactura.Applicaction.Facturas.modeloVista;
using GestorFactura.Domain.numeracion;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorFactura.Applicaction.Facturas.Comandos
{
    public class CrearComandoFactura : IRequest<int>
    {
        public CrearComandoFactura()
        {
            this.productoF = new List<ModeloVistaProducto>();
        }

        public string numeroFactura { get; set; }
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

        public IList<ModeloVistaProducto> productoF { get; set; }
    }
}
