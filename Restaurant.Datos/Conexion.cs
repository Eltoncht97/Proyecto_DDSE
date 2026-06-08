using System.Data.SqlClient;

namespace Restaurant.Datos
{
    public static class Conexion
    {
        // Ajuste "Data Source" según su instalación de SQL Server:
        //   .  (instancia por defecto)  |  .\SQLEXPRESS  |  (localdb)\MSSQLLocalDB
        public static string Cadena =
            "Data Source=.;Initial Catalog=RestaurantDB;Integrated Security=True";

        public static SqlConnection Obtener()
        {
            return new SqlConnection(Cadena);
        }
    }
}
