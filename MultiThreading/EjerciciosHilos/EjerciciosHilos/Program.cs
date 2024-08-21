using System.Runtime.CompilerServices;

namespace EjerciciosHilos
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            /*
            EjercicioUno ej1 = new EjercicioUno();
            ej1.Ejecutar();
           
            EjercicioDos ej2 = new EjercicioDos();
            ej2.Ejecutar();

            EjercicioTres ej3 = new EjercicioTres();
            ej3.Ejecutar();
           

            Ejercicio4 ej4 = new Ejercicio4();
            ej4.Ejecutar();
            

            Ejercicio5 ej5 = new Ejercicio5();
            ej5.Ejecutar();
           

            Ejercicio6 ej6 = new Ejercicio6();
            ej6.Ejecutar();
            */

            Ejercicio7 ej7 = new Ejercicio7();
            await ej7.Ejecutar();
        }
    }

    /**
     * Realizar ejercicio donde los hilos muestren las primeras 10 Tablas de multiplicacion
     * de forma ordenada utilizando la sincronizacion de los hilos
     */
    internal class EjercicioUno
    {
        public void Ejecutar()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Procesando Informacion....");
                Thread.Sleep(1000);

            }
            Console.WriteLine("\n\n");

            for (int i = 1; i < 10; i++)
            {
                int temp = i;
                Thread t = new Thread(() =>
                 {
                     Thread.CurrentThread.Name = "Tabla del " + temp + ":";
                     MostrarTabla(temp);
                 });
                t.Start();
                t.Join();
            }

            Thread.CurrentThread.Name = "Tabla del 10:";
            MostrarTabla(10);
        }
        public void MostrarTabla(int n)
        {
            int i = 0;
            Console.WriteLine(Thread.CurrentThread.Name);
            while (i <= 10)
            {
                Console.WriteLine("{0} x {1} = {2}", i, n, (n * i));
                i++;
            }
            Console.WriteLine("\n\n");
            Thread.Sleep(1000);
        }
    }

    /*
       Realizar un programa donde se cargan por cada hilo 2 productos y se vayan mostrando la
        cantidad actual al usuario. Hacer SIN EL USO DEL JOIN (LOCKER)
     */
    internal class EjercicioDos
    {
        public struct Producto
        {
            public Producto(int codigo, string nombre, float precio, int stock)
            {
                Codigo = codigo;
                Nombre = nombre;
                Precio = precio;
                Stock = stock;
            }

            public int Codigo { get; set; }
            public string Nombre { get; set; }
            public float Precio { get; set; }
            public int Stock { get; set; }


            public override String ToString() => "CODIGO: " + Codigo + " | NOMBRE: " + Nombre + " | PRECIO: $" + Precio + " | STOCK: " + Stock;

        }

        Producto[] productos;
        int currentIndex = 0;
        static object obj = new object();

        public EjercicioDos()
        {
            this.productos = new Producto[10];
        }

        private void CargarDatos(Producto p)
        {
            this.productos[currentIndex] = p;
            currentIndex++;
        }

        public void Ejecutar()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Thread[] arrayThreads =
            {
                new Thread(() =>
                {
                    lock (obj)
                    {
                       CargarDatos(new Producto(2321, "Leche", 24.4f, 1000));
                       CargarDatos(new Producto(2224, "Queso", 10f, 800));
                       Console.WriteLine("Objectos Cargados: {0}", (currentIndex));
                       Thread.Sleep(2000);
                    }
                }),
                new Thread(() =>
                {
                    lock (obj)
                    {
                        CargarDatos(new Producto(2324, "Milanga", 20f, 600));
                        CargarDatos(new Producto(3000, "Alfajor", 2f, 2000));
                        Console.WriteLine("Objectos Cargados: {0}", (currentIndex));
                        Thread.Sleep(2000);

                    }
                }),
                new Thread(() =>
                {
                    lock(obj){
                        CargarDatos(new Producto(3004, "Mermelada", 30.4f, 1000));
                        CargarDatos(new Producto(1900, "Dulce de Leche", 10f, 800));
                        Console.WriteLine("Objectos Cargados: {0}", (currentIndex));
                        Thread.Sleep(2000);
                    }
                }),
                new Thread(() =>
                {
                    lock (obj)
                    {
                        CargarDatos(new Producto(4000, "Yogurt", 14.4f, 400));
                        CargarDatos(new Producto(2288, "Agua", 10f, 800));
                        Console.WriteLine("Objectos Cargados: {0}", (currentIndex));
                        Thread.Sleep(2000);

                    }
                }),

                new Thread(() =>
                {
                    lock (obj)
                    {
                        CargarDatos(new Producto(5000, "Bondiola", 43.4f, 100));
                        CargarDatos(new Producto(4014, "Milanesa", 10f, 800));
                        Console.WriteLine("Objectos Cargados: {0}", (currentIndex));
                        Thread.Sleep(2000);

                    }
                })

            };

            for (int i = 0; i < arrayThreads.Length; i++)
            {
                arrayThreads[i].Start();
            }


            Thread.Sleep(10000);
            Console.ForegroundColor = ConsoleColor.White;
            MostrarProductosCargados();
        }

        private void MostrarProductosCargados()
        {
            foreach (Producto p in productos)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }


    /**
     * Simular un juego de caballos de apuesta. Usando hilos.
     * Hacer uso de una matriz 3x10;
     * 
     */
    internal class EjercicioTres
    {
        bool hayGanador = false;
        Caballo caballoGanador;

        string[,] matriz = new string[3, 10];

        object obj = new object();
        public EjercicioTres()
        {

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 10; j++)
                    matriz[i, j] = "_ ";
            matriz[0, 0] = matriz[1, 0] = matriz[2, 0] = "*";

        }

        public void Ejecutar()
        {
            Thread thMain = new Thread(() =>
            {
                while (hayGanador != true)
                {
                    lock (obj)
                    {
                        Console.Clear();
                        MostrarMatriz();
                        Thread.Sleep(100);
                    }

                }

                Caballo ganador = ObtenerGanador();
                Console.WriteLine("El ganador es el caballo " + ganador);
            });
            thMain.Start();


            for (int j = 0; j < 3; j++)
            {
                int temp = j;
                new Thread(() =>
                {
                    Avanzar(temp);
                }).Start();

            }

        }

        public Caballo ObtenerGanador()
        {
            Caballo[] arr = { Caballo.UNO, Caballo.DOS, Caballo.TRES };

            int indexGanador = 0;
            for (int i = 0; i < 3; i++)
            {
                if (matriz[i, 9] == "*")
                {
                    indexGanador = i;
                    break;
                }
            }

            Caballo c = arr[indexGanador];
            return c;
        }

        public void MostrarMatriz()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(matriz[i, j]);
                }
                Console.WriteLine("");
            }
        }

        public void Avanzar(int filaCaballo)
        {
            int i = 1;
            while (hayGanador != true)
            {
                lock (obj)
                {
                    if (i <= 9)
                    {
                        matriz[filaCaballo, i] = "*";
                        matriz[filaCaballo, i - 1] = "_ ";
                    }
                    else
                    {
                        hayGanador = true;
                    }
                    i++;
                    Thread.Sleep(1000);
                }
            }
        }
    }

    enum Caballo
    {
        UNO, DOS, TRES
    }


    /**
     * Ejercicio que permite simular un reloj usando ThreadPool
     */

    class Ejercicio4
    {
        bool girarReloj = true;

        struct Reloj
        {
            public Reloj()
            {
                Hora = 0;
                Minuto = 0;
                Segundo = 0;
            }

            public int Hora { get; set; }
            public int Minuto { get; set; }
            public int Segundo { get; set; }
        }

        Reloj reloj = new Reloj();

        public void Ejecutar()
        {
            ThreadPool.QueueUserWorkItem(ContarReloj);
            Thread.Sleep(1000000);

            girarReloj = false;

        }

        public void ContarReloj(object data)
        {
            while (girarReloj)
            {
                Console.Clear();
                MostrarReloj();

                reloj.Segundo = reloj.Segundo + 1;

                if (reloj.Segundo >= 60) {
                    reloj.Minuto += 1;
                    reloj.Segundo = 0;

                }
                else if (reloj.Minuto >= 60)
                {
                    reloj.Minuto = 0;
                    reloj.Hora += 1;

                }

                Thread.Sleep(100);
            }
        }

        private void MostrarReloj()
        {
            string formatoReloj = ((reloj.Hora <= 9) ? "0" : "") + reloj.Hora + ":"+
                ((reloj.Minuto <= 9) ? "0" : "") + reloj.Minuto + ":" + ((reloj.Segundo <= 9) ? "0" : "") + reloj.Segundo;
            Console.WriteLine(formatoReloj);
        }
    }


    /**
     * Simular una barra de carga en consola usando task
     */

    class Ejercicio5
    {
        string[,] barraCarga = new string[3, 10];
        string[] tareas = new string[3];


        private void crearListaTareas()
        {
            for (int i = 0; i < 3; i++)
                tareas[i] = "Cargando Tarea " + (i + 1) + "...";
        }
        private void mostrarTareas()
        {
            foreach(string t in tareas)
                Console.WriteLine(t);
        }

        private void cargarBarraVacia()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 10; j++) {
                    if (i == 0 || i == 2)
                        barraCarga[i, j] = "-";
                    else if (i == 1)
                        if (j == 0 || j == 9)
                            barraCarga[i, j] = "|";
                        else
                            barraCarga[i, j] = " ";
                }
            }
        }

        private void mostrarBarra()
        {
            for (int i = 0; i < 3; i++)
            {
                for( int j = 0; j < 10; j++)
                {
                    Console.Write(barraCarga[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        bool cargar = true;
        int progresoCarga = 0;

        public void Ejecutar()
        {
            cargarBarraVacia();
            crearListaTareas();

            ThreadStart[] myFunctions = new ThreadStart[3];
            myFunctions[0] = RealizarTarea1;
            myFunctions[1] = RealizarTarea2;
            myFunctions[2] = RealizarTarea3;

            for (int i = 0; i < 3; i++)
                new Thread(myFunctions[i]).Start();

            Task task = new Task(CargarDatos);
            task.Start();
            /*
            Task task = Task.Factory.StartNew(CargarDatos);
            task.Wait(TimeSpan.FromMilliseconds(100000));
            */
            //Task.Factory.StartNew(myFunctions[i]).Wait(TimeSpan.FromMilliseconds(4000));

            while (progresoCarga < 8)
            {
                cargar = (progresoCarga >= 8) ? false : true;
                Thread.Sleep(1000);

            }
            Console.WriteLine("Barra Completada");

            
        }


        public void CargarDatos()
        {
            while (cargar)
            {
                Console.Clear();
                actualizarBarra();
                mostrarBarra();
                mostrarTareas();

                Thread.Sleep(1000);
            }


        }
       

        private void actualizarBarra()
        {
            for(int i = 0; i < progresoCarga; i++)
              barraCarga[1, i + 1] = "*";
            
        }

        public void RealizarTarea1()
        {
            Thread.Sleep(2000);
            progresoCarga += 2;
            tareas[0] = "Tarea 1 Finalizada";
        }

        public void RealizarTarea2()
        {
            Thread.Sleep(4000);
            progresoCarga += 3;
            tareas[1] = "Tarea 2 Finalizada";
        }

        public void RealizarTarea3()
        {
            Thread.Sleep(6000);
            progresoCarga += 3;
            tareas[2] = "Tarea 3 Finalizada";
        }

    }


    /**
     * Realizar ejercicio donde un hilo requiera de un valor dependiente de otro hilo para poder finalizar
     * su tarea. Usar Signal
     */

    class Ejercicio6
    {
        ManualResetEvent senial = new ManualResetEvent(false);

        float x = 0;


        public void Ejecutar()
        {
            Task t1 = new Task(calcularX);
            Task<float> t2 = new Task<float>(calcularValorFinal);


            t1.Start();
            t2.Start();


            //Se bloqueara el hilo quien llama otro hilo para obtener su resultado
            float result = t2.Result;
            Console.WriteLine("El resultado es {0}", result);


        }
        
        
        public void calcularX()
        {
            float valorX = (4 + 2) * 2;
            Console.WriteLine("Calculando valor de x ....");
            Thread.Sleep(4000);
            x = valorX;
            Console.Clear();
            Console.WriteLine("Resultado de X obtenido!! ");
            senial.Set();
           
        }

        public float calcularValorFinal()
        {
            Console.WriteLine("Esperando valor de x.....");
            if (x == 0)
                senial.WaitOne();
            return x * 2;
        }


    }

    /**
     * Ejercicio 7: Realizar el ejercicio 6 de una forma mas eficiente,  usando async await
     */


    class Ejercicio7
    {
        public async Task Ejecutar()
        {
            Task<float> taskResultado = calcularValorFinal();

            float resultado = await taskResultado;
            Console.WriteLine("El resultado es {0}", resultado);
        }


        public async Task<float> CalcularX()
        {
            float valorX = (4 + 2) * 2;
            Console.WriteLine("Calculando valor de x ....");
            await Task.Delay(4000);
            Console.Clear();
            Console.WriteLine("Resultado de X obtenido!! ");
            return valorX;

        }

        public async Task<float> calcularValorFinal()
        {
            Console.WriteLine("Esperando valor de x.....");
            Task<float> tareaValorX = CalcularX();
            float resultado = await tareaValorX *2;
            return resultado;
        }


    }
}