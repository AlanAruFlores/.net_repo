using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHilos
{
    internal class SincronizacionHilos2
    {
        int cont = 0;
        bool ejecutar = true;
        int id1;
        int id2;

        object obj = new object();

        public void EjecutarClase5()
        {
            Thread thread1 = new Thread(Incrementar);
            Thread thread2 = new Thread(Incrementar);

            thread1.IsBackground = true;
            thread2.IsBackground = true;

            //obtenemos los identificadores de cada hilo
            id1 = thread1.ManagedThreadId;
            id2 = thread2.ManagedThreadId;

            thread1.Start();
            thread2.Start();

            while (ejecutar)
            {
                if (cont > 100)
                    ejecutar = false;
            }
        }

        public void Incrementar()
        {
            while (ejecutar)
            {
                lock (obj)
                {
                    if (Thread.CurrentThread.ManagedThreadId == id1)
                        Console.ForegroundColor = ConsoleColor.Green;
                    if (Thread.CurrentThread.ManagedThreadId == id2)
                        Console.ForegroundColor = ConsoleColor.Red;

                    cont++;
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " -> " + cont);
                    Thread.Sleep(1000);
                }

            }
        }
    }
}
