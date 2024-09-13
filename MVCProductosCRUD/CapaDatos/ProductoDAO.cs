using CapaDominio;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class ProductoDAO
    {
        Conexion conn;

        const string GET_ALL_QUERY = "select id,descripcion,precio,stock from producto";
        const string GET_BY_ID = "select id,descripcion,precio,stock from producto where id = @id";
        const string INSERT_QUERY = "insert into producto (descripcion,precio,stock) values(@descripcion, @precio, @stock)";
        const string DELETE_QUERY = "delete producto where id = @id";
        const string UPDATE_QUERY = "update producto set descripcion = @descripcion, precio = @precio, stock = @stock where id = @id";
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



        public void GuardarProducto(Producto producto)
        {
            try
            {
                using (SqlConnection connection = conn.GetConnection())
                {
                    SqlCommand command = new SqlCommand(INSERT_QUERY, connection);
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@precio", producto.Precio);
                    command.Parameters.AddWithValue("@stock", producto.Stock);
                    conn.AbrirConexion(connection);

                    command.ExecuteNonQuery();

                    conn.CerrarConexion(connection);
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);  
            }
        }

        public void EliminarProductoPorId(int id)
        {
            try
            {
                using (SqlConnection connection = conn.GetConnection())
                {
                    SqlCommand command = new SqlCommand(DELETE_QUERY, connection);
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", id);

                    conn.AbrirConexion(connection);
                    command.ExecuteNonQuery();

                    conn.CerrarConexion(connection);
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }


        public Producto GetProductoPorId(int id)
        {
            Producto producto = null;

            try
            {
                using (SqlConnection connection = conn.GetConnection())
                {
                    SqlCommand command = new SqlCommand(GET_BY_ID, connection);
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", id);
                    conn.AbrirConexion(connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            producto = new Producto()
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("id")),
                                Descripcion = reader.GetString(reader.GetOrdinal("descripcion")),
                                Precio = reader.GetDecimal(reader.GetOrdinal("precio")),
                                Stock = reader.GetInt32(reader.GetOrdinal("stock"))
                            };

                        }

                    }

                    conn.CerrarConexion(connection);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion:" + ex.Message);
            }
            return producto;
        }


        public void ActualizarProducto(Producto producto) {
            try{ 
            
                using(SqlConnection connection = conn.GetConnection())
                {
                    SqlCommand command = new SqlCommand(UPDATE_QUERY, connection);
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@precio", producto.Precio);
                    command.Parameters.AddWithValue("@stock", producto.Stock);
                    command.Parameters.AddWithValue("@id", producto.ID);

                    conn.AbrirConexion(connection);
                    command.ExecuteNonQuery();
                    conn.CerrarConexion(connection);
                }
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        
        }
    }
}
