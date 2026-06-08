using System;
using Restaurant.Datos;
using Restaurant.Entidades;

namespace Restaurant.Negocio
{
    public class UsuarioBLL
    {
        private readonly UsuarioDAO _dao = new UsuarioDAO();

        public Usuario IniciarSesion(string nombreUsuario, string clave)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ApplicationException("Ingrese el nombre de usuario.");
            if (string.IsNullOrWhiteSpace(clave))
                throw new ApplicationException("Ingrese la contraseña.");

            Usuario usuario = _dao.Validar(nombreUsuario, clave);
            if (usuario == null)
                throw new ApplicationException("Usuario o contraseña incorrectos.");

            return usuario;
        }
    }
}
