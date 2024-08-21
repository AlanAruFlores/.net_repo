using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHilos
{
    internal class OtrosEjemplos
    {
        public void Ejecutar()
        {
            Thread t = new Thread(ImprimirY);
            t.Start();
            Console.Write("X");
        }
        public void ImprimirY()
        {
            for(int i = 0; i<20; i++)
            {
                Console.Write("Y");
            }
        }
    }
}
