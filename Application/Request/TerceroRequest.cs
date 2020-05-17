﻿using Domain.Entities.Tercero;
using System.Collections.Generic;

namespace Application.Request
{
    public class TerceroRequest
    {
        public string NitTercero { get; set; }
        private string _razonSocial;
        public string RazonSocialTercero 
        { 
            get => _razonSocial; 
            set => _razonSocial = value.ToUpper(); 
        }
        public List<ContactoRequest> ContactosTercero { get; set; }
        public TerceroRequest()
        {

        }

        public TerceroRequest(string nitTercero, string razonSocialTercero)
        {
            NitTercero = nitTercero;
            RazonSocialTercero = razonSocialTercero;
            ContactosTercero = new List<ContactoRequest>();
        }

        public TerceroRequest Map(Tercero tercero)
        {
            NitTercero = tercero.Nit;
            RazonSocialTercero = tercero.RazonSocial;
            if (ContactosTercero != null)
            {
                tercero.Contactos.ForEach((contacto) =>
                {
                    ContactosTercero.Add(new ContactoRequest().
                        Map(contacto));
                });
            }
            return this;
        }
    }

    public class ContactoRequest
    {
        public string TerceroDireccion { get; set; }
        public string TerceroNumeroCelular { get; set; }
        public string TerceroEmail { get; internal set; }

        public ContactoRequest Map(Contacto contacto)
        {
            this.TerceroDireccion = contacto.Direccion;
            this.TerceroNumeroCelular = contacto.NumeroCelular;
            this.TerceroEmail = contacto.Email;
            return this;
        }
    }
}
