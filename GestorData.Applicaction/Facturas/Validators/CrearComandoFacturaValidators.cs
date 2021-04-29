using FluentValidation;
using GestorFactura.Applicaction.Facturas.Comandos;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorFactura.Applicaction.Facturas.Validators
{
    public class CrearComandoFacturaValidators : AbstractValidator<CrearComandoFactura>
    {
        public CrearComandoFacturaValidators()
        {
            RuleFor(v => v.MontoPagado).NotNull();
            RuleFor(v => v.fecha).NotNull();
            RuleFor(v => v.proviene).NotEmpty().MinimumLength(3);
            RuleFor(v => v.hacia).NotEmpty().MinimumLength(3);
            RuleFor(v => v.productoF).SetValidator(new DebeTenerProiedadValidatorDeProductoFactura());
        }
    }
}
