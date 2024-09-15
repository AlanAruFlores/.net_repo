using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_POO.Entidades
{
    public class PlantaPermanente : Empleado
    { 
        public int Bonos { get; set; }
        public override int CalcularSueldo() => SueldoBase + (Antiguedad*100) + (HorasExtras*200) + Bonos;
    }
}
