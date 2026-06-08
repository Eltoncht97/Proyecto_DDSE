using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Entidades;

namespace Restaurant.Datos
{
    public class EmpleadoDAO
    {
        public List<Empleado> Listar()
        {
            List<Empleado> lista = new List<Empleado>();
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Empleado_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Empleado
                        {
                            IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]),
                            Nombres = dr["Nombres"].ToString(),
                            Apellidos = dr["Apellidos"].ToString(),
                            Dni = dr["Dni"].ToString(),
                            Cargo = dr["Cargo"].ToString(),
                            Telefono = dr["Telefono"] == DBNull.Value ? string.Empty : dr["Telefono"].ToString(),
                            Estado = Convert.ToBoolean(dr["Estado"])
                        });
                    }
                }
            }
            return lista;
        }

        public DataTable ListarTabla()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Empleado_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public int Insertar(Empleado e)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Empleado_Insertar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombres", e.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", e.Apellidos);
                cmd.Parameters.AddWithValue("@Dni", e.Dni);
                cmd.Parameters.AddWithValue("@Cargo", e.Cargo);
                cmd.Parameters.AddWithValue("@Telefono", (object)e.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", e.Estado);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void Actualizar(Empleado e)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Empleado_Actualizar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEmpleado", e.IdEmpleado);
                cmd.Parameters.AddWithValue("@Nombres", e.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", e.Apellidos);
                cmd.Parameters.AddWithValue("@Dni", e.Dni);
                cmd.Parameters.AddWithValue("@Cargo", e.Cargo);
                cmd.Parameters.AddWithValue("@Telefono", (object)e.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", e.Estado);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idEmpleado)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Empleado_Eliminar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
