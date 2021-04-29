using System;
using System.Collections.Generic;
using System.Text;

namespace GestorFactura.Domain.Comun
{
    public class EntidadAuditora
    {
        public string creadoPor { get; set; }
        public DateTime creado { get; set; }
        public string ultimaVezModificadoPor { get; set; }

        public DateTime? ultimaVezModificado { get; set; }
    }
}
