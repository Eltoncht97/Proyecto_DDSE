using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Entidades;

namespace Restaurant.Datos
{
    public class UsuarioDAO
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Usuario_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Usuario
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            NombreUsuario = dr["NombreUsuario"].ToString(),
                            Clave = dr["Clave"].ToString(),
                            NombreCompleto = dr["NombreCompleto"].ToString(),
                            Rol = dr["Rol"].ToString(),
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
                SqlCommand cmd = new SqlCommand("usp_Usuario_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public int Insertar(Usuario u)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Usuario_Insertar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreUsuario", u.NombreUsuario);
                cmd.Parameters.AddWithValue("@Clave", u.Clave);
                cmd.Parameters.AddWithValue("@NombreCompleto", u.NombreCompleto);
                cmd.Parameters.AddWithValue("@Rol", u.Rol);
                cmd.Parameters.AddWithValue("@Estado", u.Estado);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void Actualizar(Usuario u)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Usuario_Actualizar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", u.IdUsuario);
                cmd.Parameters.AddWithValue("@NombreUsuario", u.NombreUsuario);
                cmd.Parameters.AddWithValue("@Clave", u.Clave);
                cmd.Parameters.AddWithValue("@NombreCompleto", u.NombreCompleto);
                cmd.Parameters.AddWithValue("@Rol", u.Rol);
                cmd.Parameters.AddWithValue("@Estado", u.Estado);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idUsuario)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Usuario_Eliminar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Usuario Validar(string nombreUsuario, string clave)
        {
            Usuario usuario = null;
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Usuario_Validar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@Clave", clave);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        usuario = new Usuario
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            NombreUsuario = dr["NombreUsuario"].ToString(),
                            NombreCompleto = dr["NombreCompleto"].ToString(),
                            Rol = dr["Rol"].ToString(),
                            Estado = Convert.ToBoolean(dr["Estado"])
                        };
                    }
                }
            }
            return usuario;
        }
    }
}
