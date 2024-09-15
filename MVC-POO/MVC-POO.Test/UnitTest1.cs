using MVC_POO.Entidades;

namespace MVC_POO.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            List<ICalcularSueldo> empleados = new List<ICalcularSueldo>() {
                new Pasante(){ Nombre="Pepe", SueldoBase = 5000},
                new Contratado () { HorasTrabajadas = 50, ValorHora = 1000 },
                new PlantaPermanente(){ Nombre="Diaz",  Antiguedad=5, HorasExtras = 20, SueldoBase = 10000, Bonos=5000 }
            };

            var totalSueldos = LiquidadorSueldos<ICalcularSueldo>.CalcularSueldosTotalEmpleado(empleados);

            Assert.Equal(74500, totalSueldos);
        }
    }
}