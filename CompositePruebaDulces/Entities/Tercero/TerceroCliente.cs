﻿
using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities.Tercero
{
    public class TerceroCliente : Entity<int>
    {
        public Tercero Tercero { get; set; }
        public List<TerceroClientePrecioProducto> ListaDePrecios { get; set; }
        public TerceroCliente(TerceroClienteBuilder terceroClienteBuilder)
        {
            this.Tercero = terceroClienteBuilder.Tercero;
            this.ListaDePrecios = new List<TerceroClientePrecioProducto>();
        }
        public TerceroCliente()
        {

        }
        public void AddPrecio(TerceroClientePrecioProducto precio)
        {
            ListaDePrecios.Add(precio);
        }
        public double GetPrecioProducto(int id)
        {
            var precio = this.ListaDePrecios.
                Find((precio) => precio.ProductoId == id);
            
            return precio == null ? 0 : precio.Precio;
        }
        public class TerceroClienteBuilder
        {
            public Tercero Tercero { get; private set; }
            public TerceroClienteBuilder(Tercero tercero)
            {
                this.Tercero = tercero;
            }
            public TerceroCliente Build()
            {
                TerceroCliente cliente = new TerceroCliente(this);
                return cliente;
            }
        }
    }
}
