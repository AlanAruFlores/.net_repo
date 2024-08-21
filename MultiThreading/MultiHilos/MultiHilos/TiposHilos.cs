using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHilos
{
    internal class TiposHilos
    {
        public void ejecutarClase2()
        {
            //BackGround
            Thread hiloBackground = new Thread(()=>mostrarMensajeHilo());
            hiloBackground.IsBackground = true;
            hiloBackground.Start();

            int i = 0;
           while (i < 25)
           {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Mensaje del hilo Principal");
                i++;
           }
        }


        public void mostrarMensajeHilo()
        {
            int j = 0;
            while (j < 25)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mensaje del hilo");
                j++;
            }
        }
    }
}
