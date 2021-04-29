using GestorFactura.Applicaction.Facturas.modeloVista;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorFactura.Applicaction.Facturas.Queries
{
    public class TraerUsuarioFacturaQuery : IRequest<IList<FacturaModeloVista>>
    {
        public string usuario { get; set;}
    }
}
