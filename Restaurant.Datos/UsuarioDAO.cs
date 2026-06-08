using System;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Entidades;

namespace Restaurant.Datos
{
    public class UsuarioDAO
    {
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
