﻿using Domain.Base;
using System.Collections.Generic;

namespace Domain.Entities.EntitiesProducto
{
    public class ProductoCategoria : Entity<int>
    {
        public string Nombre { get; set; }
        public List<ProductoSubCategoria> SubCategorias { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
