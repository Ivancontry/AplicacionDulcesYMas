﻿using Application.Request;
using Domain.Contracts;
using Domain.Entities.EntitiesProducto;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.ProductoServices
{
    public abstract class ProductoService
    {
        protected IUnitOfWork _unitOfWork;
        protected ProductoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        protected IEnumerable<Producto> GetProductos()
        {
            return _unitOfWork.ProductoRepository.FindBy();
        }
        protected ProductoRequest Map(Producto producto)
        {
            ProductoRequest request = new ProductoRequest();
            return request.Map(producto);
        }
        protected ProductoSubCategoria BuscarSubCategoriaConId(int idSubcategoria)
        {
            return this._unitOfWork.SubCategoriaRepository.
                FindFirstOrDefault(subCategoria => subCategoria.Id ==idSubcategoria);
        }
        public abstract Response Crear(ProductoRequest request);
    }
}
