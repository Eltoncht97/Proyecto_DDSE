using System;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Entidades;

namespace Restaurant.Datos
{
    public class ComprobanteDAO
    {
        public int Registrar(Comprobante c)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Comprobante_Insertar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPedido", c.IdPedido);
                cmd.Parameters.AddWithValue("@Tipo", c.Tipo);
                cmd.Parameters.AddWithValue("@Serie", c.Serie);
                cmd.Parameters.AddWithValue("@SubTotal", c.SubTotal);
                cmd.Parameters.AddWithValue("@Igv", c.Igv);
                cmd.Parameters.AddWithValue("@Total", c.Total);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
