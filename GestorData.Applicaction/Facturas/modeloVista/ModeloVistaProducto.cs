using System;
using System.Collections.Generic;
using System.Text;

namespace GestorFactura.Applicaction.Facturas.modeloVista
{
    public class ModeloVistaProducto
    {
        public int Id { get; set; }
        public string producto { get; set; }
        public double cantidad { get; set; }
        public double tipo { get; set; }

        public double Monto
        {
            get
            {
                return cantidad * tipo;
            }
        }

    }
}
