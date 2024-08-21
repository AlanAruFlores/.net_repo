using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHilos
{
    internal class EjemploThreadPool
    {

        const int CANTIDAD_MILISEGUNDOS = 3000;
        int conteo = 0;
        bool ejecutar = true;

        public void Ejecutar()
        {
            object argumento = 1000;
            ThreadPool.QueueUserWorkItem(Incrementar,argumento);

            Thread.Sleep(CANTIDAD_MILISEGUNDOS);
            Console.WriteLine("El valor del conteo es: {0}", conteo);
        
        }

        public void Incrementar(object parametro)
        {
            int limite = (int)parametro;
            while (ejecutar)
            {
                conteo++;
                ejecutar = (conteo > limite) ? false : true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0} -> {1}", Thread.CurrentThread.ManagedThreadId, conteo);
            }
        }
    }
}
