using CapaDominio;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class ProductoDAO
    {
        Conexion conn;

        const string GET_ALL_QUERY = "select id,descripcion,precio,stock from producto;";
        
        public ProductoDAO() {
            this.conn = new Conexion();
        }


        public List<Producto> GetTodosProductos() {
            List<Producto> listaProductos = new List<Producto>();
            try
            {
                using (SqlConnection connection = conn.GetConnection())
                {
                    SqlCommand command = new SqlCommand(GET_ALL_QUERY, connection);
                    command.CommandType = CommandType.Text;
                    conn.AbrirConexion(connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaProductos.Add(new Producto()
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("id")),
                                Descripcion = reader.GetString(reader.GetOrdinal("descripcion")),
                                Precio = reader.GetDecimal(reader.GetOrdinal("precio")),
                                Stock = reader.GetInt32(reader.GetOrdinal("stock"))
                            });

                        }

                    }

                    conn.CerrarConexion(connection);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion:"+ex.Message);
            }
            return listaProductos;
        }
    }
}
