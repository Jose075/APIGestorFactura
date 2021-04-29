using AutoMapper;
using GestorFactura.Applicaction.Facturas.Comandos;
using GestorFactura.Applicaction.Facturas.modeloVista;
using GestorFactura.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorFactura.Applicaction.Facturas.PerfilesMapeo
{
    public class FacturaPerfilMapeo : Profile
    {
        public FacturaPerfilMapeo()
        {
            CreateMap<Factura, FacturaModeloVista>();
            CreateMap<ProductoFactura, ModeloVistaProducto>().ConstructUsing(i => new ModeloVistaProducto 
            {
                Id = i.Id,
                producto = i.producto,
                cantidad = i.cantidad,
                tipo = i.tipo
            });

            CreateMap<FacturaModeloVista, Factura>();
            CreateMap<ModeloVistaProducto, ProductoFactura>();

            CreateMap<CrearComandoFactura, Factura>();
        }

    }
}
