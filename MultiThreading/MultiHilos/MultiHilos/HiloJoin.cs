using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHilos
{
    internal class HiloJoin
    {
        public void EjecutarClase7()
        {
            Thread thread1 = new Thread(ImprimirHilo);
            Thread thread2 = new Thread(ImprimirHilo);

            thread1.Start();
            thread1.Join();
            thread2.Start();
            thread2.Join();
            ImprimirHilo(); 
        }
        public void ImprimirHilo()
        {
            Console.WriteLine("Hilo " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
