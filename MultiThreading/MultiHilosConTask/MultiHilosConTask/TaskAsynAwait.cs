using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MultiHilosConTask
{
    internal class TaskAsynAwait
    {
        public static void MetodoSincrono()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Soy un metodo sincrono");
        }

        public static async Task MetodoAsincrono()
        {
            await Task.Delay(1000);
            Console.WriteLine("Soy un metodo asincrono");
        }


        //-------------------

        static int countm1 = 0, countm2 = 0;
        public static async Task PrimerMain()
        {
            Task t = MostrarMetodo1();
            MostrarMetodo2();

            await t;

            //task.Wait()
            //Console.ReadKey();
        }

        public static async Task MostrarMetodo1()
        {
            await Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 100; i++){
                    Console.WriteLine("Metodo 1");
                    countm1++;
                }
                Console.WriteLine(countm1);

            });

        }

        public static void MostrarMetodo2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Metodo 2");
                countm2++;
            }
            Console.WriteLine(countm2);
        }


        //------------------------------------------------------------

        public static async Task SegundoMain()
        {
            await Execute();
        }

        public static async Task Execute()
        {
            Task t = ShowNumbersBetweenOneAndTen();

            Task<int> random = GetARandomNumber();
            int value = await random;
            ShowMultiplyTable(value);

            t.Wait();

        }

        public static async Task ShowNumbersBetweenOneAndTen()
        {
            for(int i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                Console.WriteLine(i);
            }
        }

        public static async Task<int> GetARandomNumber()
        {
            Console.WriteLine("Generating Random Number...");
            await Task.Delay(3000);
            return new Random().Next(1, 10);
        }

        public static void ShowMultiplyTable(int value)
        {
            Console.WriteLine("Generating the table....");
            Thread.Sleep(3000);
            for(int i  = 0; i< 10; i++)
                Console.WriteLine("{0} X {1} = {2}", value, i, (value * i));   
            
        }



        /*
         Ejercicio : cargar los datos en un dictionary y luego mostrarla en la consla. A su vez
          Deberia estar cargandose otros datos en otro dictionary y mostrarlos
         */



        struct Client
        {
            public int DNI { get; set; }
            public string Name { get; set; }

            public override string ToString() => $"{DNI} | {Name}";

        }


        struct Employee
        {
            public int CUIL { get; set; }
            public string Name { get; set; }

            public override string ToString() => $"{CUIL} | {Name}";

        }


        static  Dictionary<int, Client> dataClients = new Dictionary<int, Client>();
        static Dictionary<int, Employee> dataEmployee = new Dictionary<int, Employee>();

        //data unordered

        static Queue<Client> clients = new Queue<Client>();
        static Queue<Employee> employees = new Queue<Employee>();

        public static async Task TercerMain()
        {
            await Start();
        }

        public static async Task Start()
        {
            Task[] loadDataUnordered = new Task[2];
            loadDataUnordered[0] = EnqueueDataClients();
            loadDataUnordered[1] = EnqueueDataEmployee();

            Task.WaitAll(loadDataUnordered);

            Console.WriteLine("Completed !! \n\n");

            //Here we are gonna to order the data 

            Task[] putDataInDictionary = new Task[]
            {
                Task.Run(()=>{
                    int i  = 1;
                    foreach(Client c in clients)
                    {
                        dataClients.Add(i,c);
                        i++;
                    }
                }),
                Task.Run(()=>{
                    int i  = 1;
                    foreach(Employee e in employees)
                    {
                        dataEmployee.Add(i,e);
                        i++;
                    }
                })
            };

            Task.WaitAll(putDataInDictionary);

            await ShowClients();
            await Task.Delay(4000);
            await ShowEmployees();
        }

        public static async Task EnqueueDataClients()
        {
            Console.WriteLine("Loading data Clients...");
            await Task.Delay(2000);
            clients.Enqueue(new Client() { DNI = 425232, Name = "Pepe" });
            clients.Enqueue(new Client() { DNI = 444234, Name = "Pedro" });

        }

        public static async Task EnqueueDataEmployee()
        {
            Console.WriteLine("Loading data Employees...");
            await Task.Delay(4000);
            employees.Enqueue(new Employee { CUIL= 21232314,Name = "Juan"});
            employees.Enqueue(new Employee { CUIL = 221321321, Name = "Martin" });
        }

        public static async Task ShowClients()
        {
            List<Client> clientsList = dataClients.Values.ToList();

            Console.WriteLine("CLIENTS: ");
            foreach(Client c in clientsList)
            {
                Console.WriteLine(c.ToString());
            }

        }

        public static async Task ShowEmployees()
        {
            List<Employee> employeeList = dataEmployee.Values.ToList();
            Console.WriteLine("EMPLOYEES: ");
            foreach (Employee e in employeeList)
            {
                Console.WriteLine(e.ToString());
            }
        }


        /*
         Ejercicio: Ordenar 2 arrays mezclados y mostrarlos usando async await
         */


        static int[] arr1 = new int[] { 4, 2, 32, 2, 3, 4 };
        static int[] arr2 = new int[] { 8, 2, 4, 2, 3, 10 };


        public static async Task CuartoMain()
        {
            await Begin();
        }

        public static async Task Begin()
        {
            Task[] tSorts = new Task[2]
            {
                Task.Run(async ()=>{
                    Console.WriteLine("Ordenando arreglo 1....");
                    await Task.Delay(2000);
                    arr1 = await SortArray(arr1);
                }),
                Task.Run(async ()=>{
                    Console.WriteLine("Ordenando arreglo 2....");
                    await Task.Delay(2000);
                    arr2 = await SortArray(arr2);
                })
            };

            Task.WaitAll(tSorts);
            Console.Clear();

            Task t = ShowArray(arr1,1);
            Task t2 = ShowArray(arr2,2);

            await t;
            await t2;

        }

        public static async Task<int[]> SortArray(int[] arr)
        {
            int aux;
            for(int i  =  0; i < arr.Length; i++)
            {
                for(int  j = 0;  j < arr.Length-1; j++)
                {
                    if (arr[j] > arr[j + 1 ])
                    {
                        aux = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = aux;
                    }
                }
            }
            return arr;
            
        }

        public static async Task ShowArray(int[] arr, int n)
        {
            Console.WriteLine("Mostrando arreglo " + n);
            foreach (int x in arr)
                Console.Write($"{x}-");

            Console.WriteLine();
        }
    }
}
