using AutoMapper;
using GestorFactura.Applicaction.Comun.Interfaces;
using GestorFactura.Applicaction.Facturas.modeloVista;
using GestorFactura.Applicaction.Facturas.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GestorFactura.Applicaction.Facturas.Manipuladores
{
    public class TraerFacturaUsuarioQueryManipulador : IRequestHandler<TraerUsuarioFacturaQuery, IList<FacturaModeloVista>>
    {
        private readonly IAplicacionDbContenido _contenido;
        private readonly IMapper _mapper;

        public TraerFacturaUsuarioQueryManipulador(IAplicacionDbContenido contenido, IMapper mapper)
        {
            _contenido = contenido;
            _mapper = mapper;
        }
        
        async Task<IList<FacturaModeloVista>> IRequestHandler<TraerUsuarioFacturaQuery, IList<FacturaModeloVista>>.Handle(TraerUsuarioFacturaQuery request, CancellationToken cancellationToken)
        {
            var resultado = new List<FacturaModeloVista> ();
            var facturas = await _contenido.Facturas.Include(i => i.productoF)
                .Where(i => i.creadoPor == request.usuario).ToListAsync();
            if(facturas != null)
            {
                resultado = _mapper.Map<List<FacturaModeloVista>>(facturas);

            }

            return resultado;
        }
    }
}
