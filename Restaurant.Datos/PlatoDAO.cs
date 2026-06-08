using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Entidades;

namespace Restaurant.Datos
{
    public class PlatoDAO
    {
        public List<Plato> Listar()
        {
            List<Plato> lista = new List<Plato>();
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Plato_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Plato
                        {
                            IdPlato = Convert.ToInt32(dr["IdPlato"]),
                            IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                            Categoria = dr["Categoria"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Descripcion = dr["Descripcion"] == DBNull.Value ? string.Empty : dr["Descripcion"].ToString(),
                            Precio = Convert.ToDecimal(dr["Precio"]),
                            Disponible = Convert.ToBoolean(dr["Disponible"]),
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
                SqlCommand cmd = new SqlCommand("usp_Plato_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public int Insertar(Plato p)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Plato_Insertar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCategoria", p.IdCategoria);
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", (object)p.Descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Precio", p.Precio);
                cmd.Parameters.AddWithValue("@Disponible", p.Disponible);
                cmd.Parameters.AddWithValue("@Estado", p.Estado);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void Actualizar(Plato p)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Plato_Actualizar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPlato", p.IdPlato);
                cmd.Parameters.AddWithValue("@IdCategoria", p.IdCategoria);
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", (object)p.Descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Precio", p.Precio);
                cmd.Parameters.AddWithValue("@Disponible", p.Disponible);
                cmd.Parameters.AddWithValue("@Estado", p.Estado);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idPlato)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Plato_Eliminar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPlato", idPlato);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
