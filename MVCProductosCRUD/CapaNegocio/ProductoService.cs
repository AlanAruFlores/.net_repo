
using CapaDatos;
using CapaDominio;

namespace CapaNegocio
{

    public interface IProductoService
    {
        List<Producto> ObtenerLosProductos();
        void CrearProducto(Producto producto);
    }

    public class ProductoService : IProductoService
    {
        ProductoDAO dao;

        public ProductoService()
        {
            this.dao = new ProductoDAO();
        }

        public List<Producto> ObtenerLosProductos()
        {
           return dao.GetTodosProductos();
        }

        public void CrearProducto(Producto producto)
        {
            dao.GuardarProducto(producto);
        }
    }
}
