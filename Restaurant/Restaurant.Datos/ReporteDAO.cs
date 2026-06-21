using System;
using System.Data;
using System.Data.SqlClient;

namespace Restaurant.Datos
{
    public class ReporteDAO
    {
        public DataTable VentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = new DataTable("Ventas");
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Reporte_VentasPorFecha", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable PlatosMasVendidos(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Reporte_PlatosMasVendidos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable VentasPorEmpleado(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Reporte_VentasPorEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable ReporteClientes(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Reporte_Clientes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
