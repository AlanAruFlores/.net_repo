using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHilos
{
    internal class LambdHilos
    {
        public void EjecutarClase8()
        {
            Thread t1 = new Thread(() =>
            {
                Console.WriteLine("El resultado de 4x4 es = "+MultiplicarNumeros(4, 4));
            });

            Thread t2 = new Thread(() =>
            {
                Console.WriteLine("El resultado de 4+4 es = " + SumarNumeros(4, 4));
            });

            t1.Start();
            t1.Join();

            t2.Start();
            t1.Join();


        }

        public int MultiplicarNumeros(int n, int n2) => n * n2;
        public int SumarNumeros(int n, int n2) => n + n2;

    }
}
