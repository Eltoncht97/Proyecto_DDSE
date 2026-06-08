using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Entidades;

namespace Restaurant.Datos
{
    public class MesaDAO
    {
        public List<Mesa> Listar()
        {
            List<Mesa> lista = new List<Mesa>();
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Mesa_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Mesa
                        {
                            IdMesa = Convert.ToInt32(dr["IdMesa"]),
                            Numero = Convert.ToInt32(dr["Numero"]),
                            Capacidad = Convert.ToInt32(dr["Capacidad"]),
                            Ubicacion = dr["Ubicacion"] == DBNull.Value ? string.Empty : dr["Ubicacion"].ToString(),
                            Situacion = dr["Situacion"].ToString(),
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
                SqlCommand cmd = new SqlCommand("usp_Mesa_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public int Insertar(Mesa m)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Mesa_Insertar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Numero", m.Numero);
                cmd.Parameters.AddWithValue("@Capacidad", m.Capacidad);
                cmd.Parameters.AddWithValue("@Ubicacion", (object)m.Ubicacion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Situacion", m.Situacion);
                cmd.Parameters.AddWithValue("@Estado", m.Estado);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void Actualizar(Mesa m)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Mesa_Actualizar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdMesa", m.IdMesa);
                cmd.Parameters.AddWithValue("@Numero", m.Numero);
                cmd.Parameters.AddWithValue("@Capacidad", m.Capacidad);
                cmd.Parameters.AddWithValue("@Ubicacion", (object)m.Ubicacion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Situacion", m.Situacion);
                cmd.Parameters.AddWithValue("@Estado", m.Estado);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idMesa)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Mesa_Eliminar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdMesa", idMesa);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
