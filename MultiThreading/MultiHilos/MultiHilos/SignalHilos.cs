using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHilos
{
    internal class SignalHilos
    {
        int conteo = 0;
        bool ejecutar = true;
        ManualResetEvent senial = new ManualResetEvent(false);

        public void Ejecutar()
        {
            Thread t = new Thread(() => Incrementar());
            t.Start();

            int n = 0;

            while (n < 150)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hilo Main");
                n++;
            }

            senial.Set(); // Mando una señal a que continue dicho hilo

        }


        public void Incrementar()
        {
            while (ejecutar)
            {
                conteo++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0} -> {1}", Thread.CurrentThread.ManagedThreadId, conteo);

                if (conteo == 100)
                    senial.WaitOne();
                if(conteo > 1000)
                {
                    ejecutar = false;
                    senial.Dispose();
                }
            }
        }
    }
}
