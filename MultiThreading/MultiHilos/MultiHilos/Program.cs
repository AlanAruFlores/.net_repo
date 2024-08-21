namespace MultiHilos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Hilos1 hilos1 = new Hilos1();
            hilos1.ejecutarClase1();
            */

            /*
            TiposHilos tiposHilos = new TiposHilos();
            tiposHilos.ejecutarClase2();
            */

            /*
            SincronizacionHilos sincronizacion = new SincronizacionHilos();
            sincronizacion.ejecutarClase3();
            
            SincronizacionHilos2 sincronizacion2 = new SincronizacionHilos2();
            sincronizacion2.EjecutarClase5();
            

            EjecutarOtrosEjemplos();
            */

            /*
            HiloJoin hilosJoin = new HiloJoin() ;
            hilosJoin.EjecutarClase7();
           
            LambdHilos lambdaHilos = new LambdHilos();
            lambdaHilos.EjecutarClase8();
           
            LambdaHilos2 lambdaHilos2 = new LambdaHilos2();
            lambdaHilos2.Ejecutar();
            

            NombrarHilos nombrarHilos = new NombrarHilos();
            nombrarHilos.Ejecutar();
            

            PrioridadHilos ph = new PrioridadHilos();
            ph.Ejecutar();
           

            ExcepcionesHilos excHilos = new ExcepcionesHilos();
            excHilos.Ejecutar();
            

            EjemploTask ejTask = new EjemploTask();
            ejTask.Ejecutar();
            

            EjemploThreadPool ejThreadPool = new EjemploThreadPool();
            ejThreadPool.Ejecutar();
            */

            SignalHilos senialHilos = new SignalHilos();
            senialHilos.Ejecutar();


        }
        static void EjecutarOtrosEjemplos()
        {
            /*
            OtrosEjemplos oe = new OtrosEjemplos();
            oe.Ejecutar();
            
            OtrosEjemplos2 oe2 = new OtrosEjemplos2();
            oe2.Ejecutar();
            */
            OtrosEjemplos3 oe3 = new OtrosEjemplos3();
            oe3.Ejecutar();

        }
    }
}