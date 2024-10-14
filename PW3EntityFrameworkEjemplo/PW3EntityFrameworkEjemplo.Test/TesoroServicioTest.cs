using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PW3EntityFrameworkEjemplo.Data.Entidades;
using PW3EntityFrameworkEjemplo.Logica;

namespace PW3EntityFrameworkEjemplo.Test
{
    /*Para el testing usamos memory database*/
    public class TesoroServicioTest : TestBase
    {

        public TesoroServicioTest()
        {
  
        }

        [Fact]
        public void AgregarTest()
        {

            Pw3TesoroContext context = ServiceProvider.GetService<Pw3TesoroContext>();
            ITesoroServicio tesoroServicio = new TesoroServicio(context);

            var tesoroNuevo = new Tesoro {
                Nombre = "NuevoTesoro",
                ImagenRuta = "/imagen/TesoroNuevo.jpg"
            };

            tesoroServicio.AgregarTesoro(tesoroNuevo);
            Tesoro tesoro = context.Tesoros.Find(tesoroNuevo.Id);

            Assert.NotNull(tesoro);
            Assert.Equal(tesoroNuevo.Nombre, tesoro.Nombre);
            Assert.Equal(tesoroNuevo.ImagenRuta, tesoro.ImagenRuta);
        }
    }
}