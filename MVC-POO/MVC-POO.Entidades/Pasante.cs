using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_POO.Entidades
{
    public class Pasante : Empleado
    {
        public override int CalcularSueldo() => SueldoBase;

    }
}
