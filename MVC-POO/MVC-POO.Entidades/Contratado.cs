using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_POO.Entidades
{
    public class Contratado : ICalcularSueldo
    {
        public int ValorHora { get; set; }
        public int HorasTrabajadas { get;set; }

        public int CalcularSueldo() => ValorHora * HorasTrabajadas;
    }
}
