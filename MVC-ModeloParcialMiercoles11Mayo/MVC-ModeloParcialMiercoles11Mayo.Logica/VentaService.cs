
using MVC_ModeloParcialMiercoles11Mayo.Entidades;

namespace MVC_ModeloParcialMiercoles11Mayo.Logica
{

    public interface IVentaService
    {
        public void Guardar(Venta venta);

        public List<Venta> ObtenerVentas();

    }
    public class VentaService : IVentaService
    {
        static List<Venta> ventasData = new List<Venta>() { 
            new Venta{ Id = 1, Cliente="Cliente 1", CantidadVendida = 10, PrecioUnitario = 2000},
            new Venta{ Id = 2, Cliente="Cliente 3", CantidadVendida = 20, PrecioUnitario = 2000},
            new Venta{ Id = 3, Cliente="Cliente 3", CantidadVendida = 30, PrecioUnitario = 2000},
            new Venta{ Id = 4, Cliente="Cliente 4", CantidadVendida = 40, PrecioUnitario = 2000},
        };

        public void Guardar(Venta venta)
        {
            venta.Id = ventasData.Max(x => x.Id) + 1;
            ventasData.Add(venta);
        }

        public List<Venta> ObtenerVentas()
        {
            return ventasData;
        }
    }
}
