﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Domain.Base;

namespace Domain
{
    public class Tercero : Entity<int>
    {
        public string Nit { get; set; }
        public string RazonSocial { get; set; }
        public List<Contacto> Contactos { get; set; }
        public Tercero(string nit, string nombre)
        {
            this.Nit = nit;
            this.RazonSocial = nombre;
            Contactos = new List<Contacto>();            
        }
        public Tercero()
        {
            this.Contactos = new List<Contacto>();
        }
    }
}
