using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHilosConTask
{
    internal class TaskConRetorno
    {
        public static void PrimerMain()
        {
            double[,] args = {
                { 4,4},
                { 2,2},
                { 8,8}
            };

            Task<double>[] arrTask = new Task<double>[3];
            double[] results = new double[arrTask.Length];

            var sumatoriaTotal = 0.0;

            for (int i = 0; i < arrTask.Length; i++) {
                Console.Clear();
                arrTask[i] = Task<double>.Factory.StartNew((arguments) =>
                {
                    Thread.CurrentThread.Name = "Hilo " + (i + 1);

                    Console.WriteLine("Ejecutando el {0} ....", Thread.CurrentThread.Name);
                    Thread.Sleep(2000);
                    Tuple<double, double>? tupla = arguments as Tuple<double, double>;
                    return HacerOperacion(tupla.Item1, tupla.Item2);

                }, Tuple.Create(args[i, 0], args[i, 1]));

                results[i] = arrTask[i].Result;
                sumatoriaTotal += results[i];
                Console.WriteLine("El resultado es: {0:N2}", results[i]);
                Thread.Sleep(2000);

            }

            Console.WriteLine("El resultado final es : {0:N2}", sumatoriaTotal);
        }

        public static double HacerOperacion(double inicio, double multiplo)
        {
            var suma = 0.0;
            for (var i = inicio; i < inicio + 10; i += 1)
                suma += multiplo;

            return suma;
        }

        //----------------------------------------------------

        public static void SegundoMain()
        {
            const int N_HILOS = 4;
            Task<int>[] tareasRetorno = new Task<int>[N_HILOS];

            int[] resultados = new int[N_HILOS];
            int acum = 0;

            string aux = "";

            for (int i = 0; i < N_HILOS; i++)
            {
                tareasRetorno[i] = Task<int>.Factory.StartNew((parametro) =>
                {
                    Thread.CurrentThread.Name = "HILO " + (i + 1);
                    aux = Thread.CurrentThread.Name;
                    Console.WriteLine("EJECUTANDO {0}... ", aux);
                    Thread.Sleep(3000);

                    Tuple<int, int> tupla = parametro as Tuple<int, int>;
                    int valMin = tupla.Item1;
                    int valMax = tupla.Item2;

                    int numeroRandom = new Random().Next(valMin, valMax);
                    return numeroRandom;
                }, Tuple.Create(1, 10));

                resultados[i] = tareasRetorno[i].Result;
                acum += resultados[i];
                Console.WriteLine("RESULTADO DEL " + aux + " ES: " + resultados[i] + "\n\n");

            }

            Console.WriteLine("El resultado final es: {0}", acum);


        }

        //Tener en cuenta que cuando hacemos uso de una expresion lambda, la misma captura
        //Solo la referencia de la variable.

        struct ClientStruct
        {

            public ClientStruct(int id, string name)
            {
                Id = id;
                Name = name;

            }
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString() => Id + " | " + Name;

        }
        public static void TercerMain()
        {
            const int COUNT = 4;
            Task[] createInstanceTask = new Task[COUNT];

            Queue<ClientStruct> data = new Queue<ClientStruct>();

            for (int i = 0; i < createInstanceTask.Length; i++)
            {
                createInstanceTask[i] = Task.Factory.StartNew((parametro) =>
                {
                    string param = parametro.ToString();
                    data.Enqueue(new ClientStruct(i, param));
                }, "Cliente " + (i + 1));
            }

            Task.WaitAll(createInstanceTask);

            Task showTask = Task.Run(() =>
            {
                foreach (ClientStruct cl in data)
                    Console.WriteLine(cl.ToString());

            });

            showTask.Wait();

        }
    }
}
