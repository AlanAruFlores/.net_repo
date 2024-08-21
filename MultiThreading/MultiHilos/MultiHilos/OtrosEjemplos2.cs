using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHilos
{
    internal class OtrosEjemplos2
    {
        public void Ejecutar() {
            new Thread(EjecutarCiclo).Start();
            EjecutarCiclo();
            
        } 

        public void EjecutarCiclo()
        {
            for(int i = 0; i<5; i++)
            {
                Console.Write("?");
            }
        }
    }
}
