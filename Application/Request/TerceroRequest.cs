﻿using Domain;
using Domain.Entities.Tercero;
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
        public List<Contacto> ContactosTercero { get; set; }
        public TerceroRequest()
        {

        }

        public TerceroRequest(string nitTercero, string razonSocialTercero)
        {
            NitTercero = nitTercero;
            RazonSocialTercero = razonSocialTercero;
        }

        public TerceroRequest Map(Tercero tercero)
        {
            NitTercero = tercero.Nit;
            RazonSocialTercero = tercero.RazonSocial;
            ContactosTercero = tercero.Contactos;
            return this;
        }
    }
    
}
