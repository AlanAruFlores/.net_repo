using MVC_ModeloParcialMiercoles11Mayo.Entidades;
using MVC_ModeloParcialMiercoles11Mayo.Logica;

namespace MVC_ModeloParcialMiercoles11Mayo.Test
{
    public class VentaServiceTest
    {

        IVentaService ventaService = new VentaService();

        [Fact]
        public void CuandoObtengaLaListaDeberiaNoEstarVacia()
        {
            int cantidadEsperada = 4;

            List<Venta> resultado = ventaService.ObtenerVentas();

            Assert.NotNull(resultado);
            Assert.NotEmpty(resultado);
            Assert.Equal(cantidadEsperada, resultado.Count());
        }

        [Fact]
        public void CuandoGuardeVentaDeberiaLaListaIncrementarse()
        {

            Venta venta = new Venta { Id = 10, Cliente = "Cliente 10", CantidadVendida = 30, PrecioUnitario = 2000 };
            int cantidadEsperada = 5;

            ventaService.Guardar(venta);
            List<Venta> resultado = ventaService.ObtenerVentas();

            Assert.NotNull(resultado);
            Assert.NotEmpty(resultado);
            Assert.Equal(cantidadEsperada, resultado.Count());
        }
    }
}