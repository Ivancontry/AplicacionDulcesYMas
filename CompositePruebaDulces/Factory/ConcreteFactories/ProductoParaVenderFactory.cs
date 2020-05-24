﻿using Domain.Entities.EntitiesProducto;
using Domain.Factory.AbstractFactory;
using System;

namespace Domain.Factory.ConcreteFactories
{
    public class ProductoParaVenderFactory : IProductoFactory
    {
        public Producto CrearProducto(Especificacion especificacion)
        {
            return especificacion switch
            {
                Especificacion.TieneEnvoltorio => new ProductoParaVenderConEnvoltorio(),
                Especificacion.NoTieneEnvoltorio => new ProductoParaVenderSinEnvoltorio(),
                _ => throw new
                    InvalidOperationException("No es de tipo para Vender"),
            };
        }
    }
}
