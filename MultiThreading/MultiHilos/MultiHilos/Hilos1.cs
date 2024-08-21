using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHilos
{
    internal class Hilos1
    {
        public void ejecutarClase1()
        {
            Thread hiloA = new Thread(procesoA);
            Thread hiloB = new Thread(procesoB);

            hiloA.Start();
            hiloB.Start();
        }

        public void procesoA()
        {
            Console.WriteLine("Proceso A");
        }


        public void procesoB()
        {
            Console.WriteLine("Proceso B");
        }

    }
}
