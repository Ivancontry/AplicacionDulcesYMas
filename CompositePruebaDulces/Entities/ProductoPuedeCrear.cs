﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public static class ProductoPuedeCrear
    {
        public static IReadOnlyList<string> PuedeCrearProducto(double cantidad,
            double costoUnitario)
        {
            var errores = new List<string>();
            if (cantidad < 0)
                errores.Add("Cantidad invalida");
            if (costoUnitario < 0)
                errores.Add("Costo unitario invalido");
            return errores;
        }
    }
}
