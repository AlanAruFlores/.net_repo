using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace MultiHilos
{
    internal class ExcepcionesHilos
    {
        int conteo = 0;
        bool ejecutar = true;
        static object obj = new object();

        public void Ejecutar()
        {
            Thread th = new Thread(ImprimirDiezNumeros);
            Thread th2 = new Thread(ImprimirDiezNumeros);
            th.Name = "Hilo 1";
            th2.Name = "Hilo 2";

            th.Start();
            th2.Start();
        }

        public void ImprimirDiezNumeros()
        {
            try
            {
                while (ejecutar)
                {
                    lock (obj)
                    {
                        if (conteo > 10)
                        {
                            ejecutar = false;
                            throw new Exception();
                        }
                        Console.Write(Thread.CurrentThread.Name + " -> ");
                        Console.WriteLine(conteo);
                        conteo++;
                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Hubo Excepcion");
            }

        }
    }
}
