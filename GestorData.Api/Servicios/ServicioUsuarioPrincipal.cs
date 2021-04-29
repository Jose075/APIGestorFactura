using GestorFactura.Applicaction.Comun.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GestorFactura.Api.Servicios
{
    public class ServicioUsuarioPrincipal : IServiciosUsuariosPrincipal
    {
        public ServicioUsuarioPrincipal(IHttpContextAccessor httpContextAccessor)
        {
            this.idUsuario = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string idUsuario { get; }
    }
}
