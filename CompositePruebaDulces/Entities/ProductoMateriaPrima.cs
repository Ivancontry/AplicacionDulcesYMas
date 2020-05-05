﻿using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ProductoMateriaPrima : Producto
    {
        public List<FabricacionDetalle> FabricacionDetalles { get; set; }              

        public ProductoMateriaPrima(string nombre, double cantidad,
            double costoUnitario, string unidad) : 
            base(nombre, cantidad, costoUnitario, unidad)
        {
            FabricacionDetalles = new List<FabricacionDetalle>();
        }
        public ProductoMateriaPrima()
        {
            FabricacionDetalles = new List<FabricacionDetalle>();
        }

        protected override void ActualizarCosto()
        {            
        }
    }
}
