
using CapaDatos;
using CapaDominio;

namespace CapaNegocio
{

    public interface IProductoService
    {
        List<Producto> ObtenerLosProductos();
        void CrearProducto(Producto producto);

        void EliminarProductoPorId(int id);
        Producto ObtenerProductoId(int id);

        void ActualizarProducto(Producto producto);
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

        public void EliminarProductoPorId(int id)
        {
            dao.EliminarProductoPorId(id);
        }

        public Producto ObtenerProductoId(int id)
        {
            return dao.GetProductoPorId(id);
        }

        public void ActualizarProducto(Producto producto)
        {
            dao.ActualizarProducto(producto);
        }
    }
}
