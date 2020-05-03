﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public abstract class ProductoParaVender : Producto
    {        
        public ProductoMateriaPrima EmboltorioProducto { get; set; }
        public List<ProductoParaVenderDetalle> ProductoParaVenderDetalles { get; private set; }        
        protected ProductoParaVender(string nombre, double cantidad,
            double costoUnitario, string unidad)
        {
            this.Nombre = nombre;
            this.Cantidad = cantidad;
            this.CostoUnitario = costoUnitario;
            this.UnidadDeMedida = unidad;
        }
        protected ProductoParaVender(string nombre)
        {
            this.Nombre = nombre;
            this.ProductoParaVenderDetalles = new List<ProductoParaVenderDetalle>();
        }
        public void AgregarDetalle(ProductoParaVenderDetalle productoParaVenderDetalle)
        {
            this.ProductoParaVenderDetalles.Add(productoParaVenderDetalle);
        }
        public abstract void Preparar(double cantidad);  
    }    
}