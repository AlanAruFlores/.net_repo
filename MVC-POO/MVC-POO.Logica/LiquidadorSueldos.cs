using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_POO.Entidades
{
    public class LiquidadorSueldos <T> where T: ICalcularSueldo //Genercio que acepta clases implementadas o la misma de la ICalcularSueldo
    {
        public static int CalcularSueldosTotalEmpleado(List<T> empleados)
           => empleados.Sum(emp => emp.CalcularSueldo());

    }
}
