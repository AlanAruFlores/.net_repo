
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Conexion
    {

        const string CONEXION = "Server=DESKTOP-B5HECAG\\SQLEXPRESS;Database=crud_producto;User ID=sa;Password=pachan242";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(CONEXION);
        }

        public void AbrirConexion(SqlConnection connection) {
            connection.Open();
        }

        public void CerrarConexion(SqlConnection connection)
        {
            connection.Close();
        }

    }
}
