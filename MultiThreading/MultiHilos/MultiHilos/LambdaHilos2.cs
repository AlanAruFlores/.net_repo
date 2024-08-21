using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHilos
{
    internal class LambdaHilos2
    {
        public void Ejecutar()
        {
            for(int i = 0; i<10; i++)
            {
                int temp = i;
                new Thread(() => Console.WriteLine("{0}", temp)).Start();
            }
        }
    }
}
