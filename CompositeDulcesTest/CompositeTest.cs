using NUnit.Framework;
using Domain;
using System.Collections.Generic;
using System;
using Domain.Entities;

namespace DomainTest
{
    public class CompositeTest
    {
        TerceroPropietario Administrador;
        ProductoMateriaPrima leche;
        ProductoMateriaPrima azucar;
        ProductoMateriaPrima ArinaPan;
        ProductoMateriaPrima BandejaSelloPlus4Onzas;
        ProductoParaFabricar calderoLeche;
        ProductoParaVender PresentacionBandejaSelloPlus4Onzas;
        ProductoParaVender UnidadesDeLeche;
        Tercero tercero;
        TerceroEmpleado TerceroEmpleado;
        Fabricacion Fabricacion;
        List<ProductoMateriaPrima> materiasPrimas;        
        [SetUp]
        public void Setup()
        {
            leche = new ProductoMateriaPrima("leche", 15, 1500 , "Litros");

            azucar = new ProductoMateriaPrima("Azucar", 17, 1800, "Libras");

            ArinaPan = new ProductoMateriaPrima("Arina Pan", 0.5 , 1300, "Libras");

            calderoLeche = new ProductoParaFabricarDuro("Caldero de Leche");
            calderoLeche.PorcentajeDeUtilidad = 30;

            BandejaSelloPlus4Onzas =
                new ProductoMateriaPrima("Bandeja de Sello Plus de 4 Onzas", 1, 300, "Onza");
            BandejaSelloPlus4Onzas.SetCantidad(  4);

            PresentacionBandejaSelloPlus4Onzas =
                new ProductoParaVenderConEmboltorio
                ("Presentacion de Bandeja Sello Plus 4 Onzas",BandejaSelloPlus4Onzas);
            
            tercero = new Tercero("Duvan", "1065840833");
            TerceroEmpleado = new TerceroEmpleado(tercero);            
            Administrador = new TerceroPropietario(tercero);
            Administrador.Productos.Add(leche);


            materiasPrimas = new List<ProductoMateriaPrima>();
            materiasPrimas.Add(leche);
            materiasPrimas.Add(ArinaPan);
            materiasPrimas.Add(azucar);
            Administrador.Productos.Add(azucar);
            Administrador.Productos.Add(PresentacionBandejaSelloPlus4Onzas);
            //Fabricacion = new Fabricacion(TerceroEmpleado,materiasPrimas);

            UnidadesDeLeche = new ProductoParaVenderSinEmboltorio();
        }

        [Test]
        public void ProbarCostoDelaPrimeraFabricacion()
        {
            Fabricacion = new Fabricacion(TerceroEmpleado);
            Fabricacion.AgregarMateriaPrima(leche);
            Fabricacion.AgregarMateriaPrima(ArinaPan);
            Fabricacion.AgregarMateriaPrima(azucar);
            calderoLeche.AgregarFabricacion(Fabricacion);
            calderoLeche.AdicionarCantidad(26);
            Assert.AreEqual(34.46, calderoLeche.CostoUnitario);
            Console.WriteLine(calderoLeche.PrecioDeVenta + " " +  calderoLeche.Cantidad);
        }

        [Test]
        public void ProbarCostoLuegoDeLaPrimeraPreparacion()
        {
            //Primera Fabricacion
            Fabricacion = new Fabricacion(TerceroEmpleado);
            Fabricacion.AgregarMateriaPrima(leche);
            Fabricacion.AgregarMateriaPrima(ArinaPan);
            Fabricacion.AgregarMateriaPrima(azucar);
            
            calderoLeche.AgregarFabricacion(Fabricacion);
            calderoLeche.AdicionarCantidad(26);
            
            leche.SetCantidad(35);
            azucar.SetCantidad(30);
            //Segunda Fabricacion
            Fabricacion = new Fabricacion(TerceroEmpleado);
            Fabricacion.AgregarMateriaPrima(leche);
            Fabricacion.AgregarMateriaPrima(ArinaPan);
            Fabricacion.AgregarMateriaPrima(azucar);

            calderoLeche.AgregarFabricacion(Fabricacion);
            calderoLeche.AdicionarCantidad(35);
            
            Assert.AreEqual(42.74, calderoLeche.CostoUnitario);
            Assert.AreEqual(3660, calderoLeche.Cantidad);
        }
        [Test]
        public void ProbarCreacionDePresentacionConEmboltorio()
        {
            Fabricacion = new Fabricacion(TerceroEmpleado);
            Fabricacion.AgregarMateriaPrima(leche);
            Fabricacion.AgregarMateriaPrima(ArinaPan);
            Fabricacion.AgregarMateriaPrima(azucar);
            calderoLeche.AgregarFabricacion(Fabricacion);
            calderoLeche.AdicionarCantidad(cantidadProducida: 26);

            ProductoParaVenderDetalle productoParaVenderDetalle =
                new ProductoParaVenderDetalle(calderoLeche, PresentacionBandejaSelloPlus4Onzas);
            productoParaVenderDetalle.SetCantidadNecesaria(cantidad:23);

            PresentacionBandejaSelloPlus4Onzas.AgregarDetalle(productoParaVenderDetalle);
            
            PresentacionBandejaSelloPlus4Onzas.
                Preparar(cantidad:7);
            Assert.AreEqual(expected: 1092.58, 
                actual: PresentacionBandejaSelloPlus4Onzas.CostoUnitario);

            Assert.AreEqual(expected: 3, 
                actual: PresentacionBandejaSelloPlus4Onzas.Cantidad);
            Console.WriteLine(PresentacionBandejaSelloPlus4Onzas.PrecioDeVenta);
        }
        [Test]
        public void ProbarCreacionDePresentacionSinEmboltorio()
        {
            Fabricacion = new Fabricacion(TerceroEmpleado);
            Fabricacion.AgregarMateriaPrima(leche);
            Fabricacion.AgregarMateriaPrima(ArinaPan);
            Fabricacion.AgregarMateriaPrima(azucar);

            calderoLeche.AgregarFabricacion(Fabricacion);
            calderoLeche.AdicionarCantidad(cantidadProducida: 26);

            ProductoParaVenderDetalle productoParaVenderDetalle =
                new ProductoParaVenderDetalle(calderoLeche, UnidadesDeLeche);
            productoParaVenderDetalle.SetCantidadNecesaria(cantidad: 5);

            UnidadesDeLeche.AgregarDetalle(productoParaVenderDetalle);

            UnidadesDeLeche.
                Preparar(cantidad: 10);
            Assert.AreEqual(expected: 172.3,
                actual: UnidadesDeLeche.CostoUnitario);
            Assert.AreEqual(expected: 10, actual: UnidadesDeLeche.Cantidad);
            Console.WriteLine(UnidadesDeLeche.PrecioDeVenta);
        }
    }
}