using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHilos
{
    internal class SincronizacionHilos
    {
        int cont;
        Boolean ejecutar = true;

        public void ejecutarClase3()
        {
            Thread hilo1 = new Thread(Incrementar);
            Thread hilo2 = new Thread(Incrementar);
            
            hilo1.IsBackground = true;
            hilo2.IsBackground = true;

            hilo1.Start();
            hilo2.Start();

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
                Console.Write(Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("->{0}", cont);
                cont++;
                Thread.Sleep(1000);

            }
        }

    }
}
