using AutoMapper;
using GestorFactura.Applicaction.Comun.Interfaces;
using GestorFactura.Applicaction.Facturas.Comandos;
using GestorFactura.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GestorFactura.Applicaction.Facturas.Manipuladores
{
    class CrearComandoFacturaManipulador : IRequestHandler<CrearComandoFactura, int>
    {
        private readonly IAplicacionDbContenido _contenido;
        private readonly IMapper _mapper;

        public CrearComandoFacturaManipulador(IAplicacionDbContenido contenido, IMapper mapper)
        {
            _contenido = contenido;
            _mapper = mapper;
        }

        public async Task<int> Handle(CrearComandoFactura request, CancellationToken cancellationToken)
        {
            var entidad = _mapper.Map<Factura>(request);

            _contenido.Facturas.Add(entidad);
            await _contenido.SaveChangesAsync(cancellationToken);
            return entidad.id;
        }
    }
}
