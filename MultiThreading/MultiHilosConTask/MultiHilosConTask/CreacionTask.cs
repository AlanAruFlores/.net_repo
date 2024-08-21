using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHilosConTask
{
    internal class CreacionTask
    {
        public static void PrimerMain()
        {
            Task task = new Task(() => {
                Thread.CurrentThread.Name = "Hilo Secundario";
                Console.WriteLine("{0}", Thread.CurrentThread.Name);

                Thread.Sleep(3000);
                Queue<string> nombres = new Queue<string>();
                nombres.Enqueue("Alan");
                nombres.Enqueue("Alejandro");
                nombres.Enqueue("Leo");

                foreach (string n in nombres)
                    Console.WriteLine(n);

            });

            task.Start();

            Thread.CurrentThread.Name = "Hilo Principal";
            Console.WriteLine("{0}", Thread.CurrentThread.Name);

            task.Wait();

        }

        public static void SegundoMain()
        {
            Task task = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Hilo Secundario";
                Console.WriteLine("{0}", Thread.CurrentThread.Name);

                Stack<string> nombres = new Stack<string>();
                nombres.Push("Alan");
                nombres.Push("Alejandro");
                nombres.Push("Leo");

                Thread.Sleep(3000);

                foreach (string n in nombres)
                    Console.WriteLine(n);

            });

            Thread.CurrentThread.Name = "Hilo Principal";
            Console.WriteLine("{0}", Thread.CurrentThread.Name);

            task.Wait();
        }


        struct Cliente
        {
            public int Id {get; set;}
            public string Nombre { get; set; }
            public string Apellido { get; set; }

            public override string ToString()
            {
                return Id + " | NOMBRE: " + Nombre + " | Apellido: " + Apellido;
            }

        }

        static Dictionary<int, List<string>> dataClients = new Dictionary<int, List<string>>{
            { 1 ,new List<string>{"Ale","Flores"}},
            { 2 , new List<string>{ "Juan", "Perez"} },
            { 3, new List<string>{ "Pepe", "Fernando"} },
            { 4, new List<string>{ "Carlos", "Karl" } }
        };


        static Queue<Cliente> dataOptimizado = new Queue<Cliente>();
        
        private static void OrganizarDatos()
        {
            //Iteramos el dictornary
            foreach(KeyValuePair<int, List<string>> item in dataClients)
            {
               Cliente c = new Cliente();
               c.Id = item.Key;
               c.Nombre = item.Value[0];
               c.Apellido = item.Value[1];

               dataOptimizado.Enqueue(c);
            }
        }

        private static void MostrarClientePorId(int id)
        {
            List<Cliente> list = dataOptimizado.ToList();
            foreach (Cliente l in list)
                if (l.Id == id)
                    Console.WriteLine(l.ToString());

        }

        public static void TercerMain()
        {
            Task t = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Organizando Datos.....");
                OrganizarDatos();
                Thread.Sleep(4000);
            });

            t.Wait();

            Task[] taskGetClients = new Task[dataOptimizado.Count];


            
            List<int> keys = dataClients.Keys.ToList();

            //foreach(int k in keys)
            //{
            //    Console.WriteLine(k);

            //}
            for (int i = 0; i < taskGetClients.Length; i++)
            {
                taskGetClients[i] = Task.Factory.StartNew((arguments) =>
                {
                   
                    Tuple<int>? args = arguments as Tuple<int>;

                    int index = args.Item1;

                    Console.WriteLine("Buscando usuario con el id: " + index + " .....");
                    Thread.Sleep(2000);
                    MostrarClientePorId(index);

                }, Tuple.Create(keys[i]));
            }
            
            Task.WaitAll(taskGetClients);

            Console.WriteLine("Finalizado");

        }
    }
}
