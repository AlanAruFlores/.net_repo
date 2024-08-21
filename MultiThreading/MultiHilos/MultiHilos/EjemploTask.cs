using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHilos
{
    internal class EjemploTask
    {
        const int CANTIDAD_MILISEGUNDOS = 3000;
        bool ejecutar = true;
        int conteo = 0;

        public void Ejecutar()
        {
            Task feature = Task.Factory.StartNew(Incrementar);
            
            feature.Wait(TimeSpan.FromMilliseconds(CANTIDAD_MILISEGUNDOS));

            Console.WriteLine("El valor del conteo es {0} ", conteo);

        }

        public void Incrementar()
        {
            while (ejecutar)
            {
                conteo++;

                if (conteo > 1000)
                    ejecutar = false;
                ConsoleColor color = ConsoleColor.Green;
                Console.ForegroundColor = color;
                Console.WriteLine("{0} -> {1}", Thread.CurrentThread.ManagedThreadId, conteo);

            }
        }
    }
}
