using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Entidades;

namespace Restaurant.Datos
{
    public class ClienteDAO
    {
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Cliente_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Cliente
                        {
                            IdCliente = Convert.ToInt32(dr["IdCliente"]),
                            Nombres = dr["Nombres"].ToString(),
                            Apellidos = dr["Apellidos"] == DBNull.Value ? string.Empty : dr["Apellidos"].ToString(),
                            Documento = dr["Documento"] == DBNull.Value ? string.Empty : dr["Documento"].ToString(),
                            Telefono = dr["Telefono"] == DBNull.Value ? string.Empty : dr["Telefono"].ToString(),
                            Correo = dr["Correo"] == DBNull.Value ? string.Empty : dr["Correo"].ToString(),
                            Direccion = dr["Direccion"] == DBNull.Value ? string.Empty : dr["Direccion"].ToString(),
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
                SqlCommand cmd = new SqlCommand("usp_Cliente_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public int Insertar(Cliente c)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Cliente_Insertar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombres", c.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", (object)c.Apellidos ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Documento", (object)c.Documento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Telefono", (object)c.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Correo", (object)c.Correo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Direccion", (object)c.Direccion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", c.Estado);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void Actualizar(Cliente c)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Cliente_Actualizar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", c.IdCliente);
                cmd.Parameters.AddWithValue("@Nombres", c.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", (object)c.Apellidos ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Documento", (object)c.Documento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Telefono", (object)c.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Correo", (object)c.Correo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Direccion", (object)c.Direccion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", c.Estado);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idCliente)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Cliente_Eliminar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
