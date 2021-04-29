using FluentValidation.Validators;
using GestorFactura.Applicaction.Facturas.modeloVista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GestorFactura.Applicaction.Facturas.Validators
{
    public class DebeTenerProiedadValidatorDeProductoFactura : PropertyValidator
    {
        public DebeTenerProiedadValidatorDeProductoFactura()
        : base("Propiedad {PropetyName} no debería estar vacío en la lista")
        {
            
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var lista = context.PropertyValue as IList<ModeloVistaProducto>;
            return lista != null && lista.Any();
        }
    }
}
