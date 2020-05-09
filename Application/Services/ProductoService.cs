﻿using Application.Request;
using Application.Services;
using Domain;
using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
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
            return this._unitOfWork.ProductoRepository.
                FindBy();
        }
        protected ProductoRequest Map(Producto producto)
        {
            ProductoRequest request = new ProductoRequest();
            return request.Map(producto);
        }
        protected List<ProductoRequest> ConvertirProductoARequest(List<Producto> productos)
        {
            List<ProductoRequest> request = new List<ProductoRequest>();
            productos.ForEach(x => request.Add(this.Map(x)));
            return request;
        }
    }
    public class CrearProductoMateriaPrima : ProductoService
    {        
        public CrearProductoMateriaPrima(IUnitOfWork unitOfWork):base(unitOfWork)
        {            
        }        

        public Response CrearProducto(ProductoRequest productoRequest)
        {
            
            var errores = ProductoPuedeCrear.PuedeCrearProducto
                (productoRequest.CantidadProducto,
                productoRequest.CostoUnitarioProducto);

            if (errores.Any())
                return new Response { Mensaje = String.Join(", ", errores) };

            Producto producto = this._unitOfWork.ProductoRepository.
                FindFirstOrDefault(t => t.Nombre == productoRequest.NombreProducto);

            if(producto != null)         
                return new Response { Mensaje = "El producto ya existe" };

            producto = new ProductoMateriaPrima(productoRequest.NombreProducto,
                productoRequest.CantidadProducto, productoRequest.CostoUnitarioProducto,
                productoRequest.UnidadDeMedidaProducto);

            this._unitOfWork.ProductoRepository.Add(producto);
            this._unitOfWork.Commit();
            return new Response { 
                Mensaje = "Producto registrado con exito",
                Data = new ProductoRequest().Map(producto)
            };
        }
        
    }
    public class ListarProductos : CrearProductoMateriaPrima

    {
        public ListarProductos(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public Response GetAllProductos()
        {            
            Response productoResponse = new Response();
            productoResponse.Data = ConvertirProductoARequest(this.GetProductos().ToList());
            return productoResponse;
        }
    }
    public class ListarProductosPorTipo : ListarProductos
    {
        private Type _tipo;
        public ListarProductosPorTipo(IUnitOfWork unitOfWork) : base(unitOfWork)
        {            
        }
        public ListarProductosPorTipo EstablecerTipo(Producto producto)
        {
            _tipo = producto.GetType();
            return this;
        }
        public Response Filtrar()
        {
            var filtrado =
            this.GetProductos().
                Where(x => x.GetType() == _tipo);            
            return new Response 
            { 
                Data = this.ConvertirProductoARequest(filtrado.ToList()) 
            };
        }
    }
}
