using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHilos
{
    internal class NombrarHilos
    {
        string nombreHiloMain = "Hilo Main";
        string nombreHilo = "Hilo th";
       
        public void Ejecutar()
        {
            Thread.CurrentThread.Name = nombreHiloMain;
            Thread th = new Thread(ImprimirHilo);
            th.Name = nombreHilo;
            th.Start();
            th.Join();

            ImprimirHilo();
        }

        public void ImprimirHilo()
        {
            ConsoleColor color = (Thread.CurrentThread.Name.Equals(nombreHilo)) 
                ? ConsoleColor.Red : ConsoleColor.Green;

            Console.ForegroundColor = color;

            Console.WriteLine("El Hilo es {0}", Thread.CurrentThread.Name);
        }
    }
}
