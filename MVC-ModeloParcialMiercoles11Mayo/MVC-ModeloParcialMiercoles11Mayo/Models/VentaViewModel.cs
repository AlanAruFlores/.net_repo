using MVC_ModeloParcialMiercoles11Mayo.Entidades;

namespace MVC_ModeloParcialMiercoles11Mayo.Models
{
    public class VentaViewModel
    {
        public int Id { get; set; }
        public String Cliente { get; set; }
        public int CantidadVendida { get; set; }
        public int PrecioUnitario { get; set; }
        public int TotalVenta { get; set; }


        public static VentaViewModel ParseToVentaViewModel(Venta venta)
        {
            VentaViewModel obj =  new VentaViewModel
            {
                Id = venta.Id,
                Cliente = venta.Cliente,
                CantidadVendida = venta.CantidadVendida,
                PrecioUnitario = venta.PrecioUnitario
            };

            obj.TotalVenta = obj.CantidadVendida * venta.PrecioUnitario;
            return obj;
        }

        public static List<VentaViewModel> FromVentaToVentaViewModel(List<Venta> ventas)
        {
            return ventas.Select(x => ParseToVentaViewModel(x))
                    .ToList();
        }

    }
}
