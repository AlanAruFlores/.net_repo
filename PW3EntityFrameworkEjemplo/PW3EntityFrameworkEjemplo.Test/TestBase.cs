using Microsoft.Extensions.DependencyInjection;
using PW3EntityFrameworkEjemplo.Data.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW3EntityFrameworkEjemplo.Test
{
    public class TestBase
    {
        protected ServiceCollection Services { get; }
        protected ServiceProvider ServiceProvider { get; private set; }

        public TestBase()
        {

            // una colección de servicios que se utilizarán para la inyección de dependencias
            Services = new ServiceCollection();

            // Añadimos el servicio de base de datos en memoria
            Services.AddEntityFrameworkInMemoryDatabase();

            //Configuramos el contexto de la base de datos
            Services.AddDbContext<Pw3TesoroContext>((sp, options) =>
                options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // creamos una bd en memoria
                .UseInternalServiceProvider(sp)); //asegura que use el mismo service provider

            //resuelve y proporciona instancias de esos servicios del collection.
            ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
