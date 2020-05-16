﻿using System.Collections.Generic;

namespace Domain
{
    public abstract class ProductoParaVender : Producto
    {
        public Producto EnvoltorioProducto { get; set; }
        public List<ProductoParaVenderDetalle>
            ProductoParaVenderDetalles = new List<ProductoParaVenderDetalle>();
        protected ProductoParaVender(string nombre, double cantidad,
            double costoUnitario, UnidadDeMedida unidad) :
            base(nombre, cantidad, costoUnitario, unidad)
        {
        }
        protected ProductoParaVender(string nombre) : base(nombre)
        {

        }
        protected ProductoParaVender()
        {

        }

    }
}
