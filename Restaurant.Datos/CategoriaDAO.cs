using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Entidades;

namespace Restaurant.Datos
{
    public class CategoriaDAO
    {
        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Categoria_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Categoria
                        {
                            IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                            Nombre = dr["Nombre"].ToString(),
                            Descripcion = dr["Descripcion"] == DBNull.Value ? string.Empty : dr["Descripcion"].ToString(),
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
                SqlCommand cmd = new SqlCommand("usp_Categoria_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public int Insertar(Categoria c)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Categoria_Insertar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", (object)c.Descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", c.Estado);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void Actualizar(Categoria c)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Categoria_Actualizar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCategoria", c.IdCategoria);
                cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", (object)c.Descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", c.Estado);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idCategoria)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Categoria_Eliminar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
