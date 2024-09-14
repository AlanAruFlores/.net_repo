using CapaDatos;
using CapaDominio;
using CapaNegocio;
using NSubstitute;

namespace CapaTest
{
    public class ProductoServiceTest
    {

        //Mock
        private IProductoService productoService = Substitute.For<IProductoService>();

        [Fact]
        public void DeberiaDevolverLaCantidadEsperadaCuandoObtengoLosProductos()
        {
            //Arrange
            List<Producto> productos = new List<Producto>()
            {
                new Producto(){ID = 1, Descripcion = "Producto 1", Precio = 200, Stock = 200 },
                new Producto(){ID = 2, Descripcion = "Producto 2", Precio = 200, Stock = 200 },
                new Producto(){ID = 3, Descripcion = "Producto 3", Precio = 200, Stock = 200 },
                new Producto(){ID = 4, Descripcion = "Producto 4", Precio = 200, Stock = 200 },

            };

            //Act
            productoService.ObtenerLosProductos().Returns(productos);
            int cantidad = productoService.ObtenerLosProductos().Count;

            //Assert
            Assert.Equal(4,cantidad);

        }
    }
}