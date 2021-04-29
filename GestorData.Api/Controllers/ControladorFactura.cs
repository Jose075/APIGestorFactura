using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorFactura.Applicaction.Comun.Interfaces;
using GestorFactura.Applicaction.Facturas.Comandos;
using GestorFactura.Applicaction.Facturas.modeloVista;
using GestorFactura.Applicaction.Facturas.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace GestorFactura.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]

    //*aquíva la ruta del localhost*/api/ControladorFactura
    //[ApiController]
    public class ControladorFactura : APIControlador
    {
        private readonly IServiciosUsuariosPrincipal _usuarioServicioPrincipal;
        public ControladorFactura(IServiciosUsuariosPrincipal serviciosUsuariosPrincipal)
        {
            _usuarioServicioPrincipal = serviciosUsuariosPrincipal;
        }
        
        [HttpPost]
        public async Task<ActionResult<int>> Create(CrearComandoFactura comando)
        {
            return await Mediator.Send(comando);
        }

        [HttpGet]
        public async Task<IList<FacturaModeloVista>> Get()
        {
            return await Mediator.Send(new TraerUsuarioFacturaQuery { usuario = _usuarioServicioPrincipal.idUsuario });
        }
    }
}
