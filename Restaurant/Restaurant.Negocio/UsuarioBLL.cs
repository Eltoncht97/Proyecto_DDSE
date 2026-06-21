using System;
using System.Collections.Generic;
using System.Data;
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

        public List<Usuario> Listar()
        {
            return _dao.Listar();
        }

        public DataTable ListarTabla()
        {
            return _dao.ListarTabla();
        }

        public int Registrar(Usuario u)
        {
            Validar(u);
            return _dao.Insertar(u);
        }

        public void Modificar(Usuario u)
        {
            if (u.IdUsuario <= 0)
                throw new ApplicationException("Seleccione un usuario válido para modificar.");
            Validar(u);
            _dao.Actualizar(u);
        }

        public void Eliminar(int idUsuario)
        {
            if (idUsuario <= 0)
                throw new ApplicationException("Seleccione un usuario para eliminar.");
            _dao.Eliminar(idUsuario);
        }

        private void Validar(Usuario u)
        {
            if (u == null)
                throw new ApplicationException("No hay datos del usuario.");
            if (string.IsNullOrWhiteSpace(u.NombreUsuario))
                throw new ApplicationException("El nombre de usuario es obligatorio.");
            if (string.IsNullOrWhiteSpace(u.Clave))
                throw new ApplicationException("La contraseña es obligatoria.");
            if (string.IsNullOrWhiteSpace(u.NombreCompleto))
                throw new ApplicationException("El nombre completo es obligatorio.");
            if (string.IsNullOrWhiteSpace(u.Rol))
                throw new ApplicationException("Debe seleccionar un rol.");
        }
    }
}
