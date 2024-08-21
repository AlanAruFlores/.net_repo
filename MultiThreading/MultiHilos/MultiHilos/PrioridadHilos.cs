using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHilos
{
    internal class PrioridadHilos
    {
       
        bool seguirEjecutando = true;
        static object obj = new object();
        public void Ejecutar()
        {
            Thread th = new Thread(Incrementar);
            Thread th2 = new Thread(Incrementar);

            th.Name = "Hilo Lowest";
            th2.Name = "Hilo Highest";
            th.Priority = ThreadPriority.Lowest;
            th2.Priority = ThreadPriority.Highest;

            th.Start();
            th2.Start();
        }

        public void Incrementar() {
            int localCount = 0;
            ConsoleColor cl = Thread.CurrentThread.Name.Equals("Hilo Highest") ? ConsoleColor.Red : ConsoleColor.Green;

            while (seguirEjecutando)
            {
                lock (obj)
                {
                    Console.ForegroundColor = cl;
                    if (localCount > 1000)
                        seguirEjecutando = false;
                    Console.Write(Thread.CurrentThread.Name + " -> ");
                    Console.WriteLine(localCount);
                    localCount++;
                }

            }

        }

    }
}
