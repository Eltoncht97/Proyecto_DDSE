using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Restaurant.Datos;
using Restaurant.Entidades;

namespace Restaurant.Negocio
{
    public class CategoriaBLL
    {
        private readonly CategoriaDAO _dao = new CategoriaDAO();

        public List<Categoria> Listar()
        {
            return _dao.Listar();
        }

        public DataTable ListarTabla()
        {
            return _dao.ListarTabla();
        }

        public List<Categoria> ListarActivas()
        {
            return _dao.Listar().Where(c => c.Estado).OrderBy(c => c.Nombre).ToList();
        }

        public List<Categoria> Buscar(string texto)
        {
            texto = (texto ?? string.Empty).Trim().ToLower();
            return _dao.Listar()
                       .Where(c => c.Nombre.ToLower().Contains(texto))
                       .ToList();
        }

        public int Registrar(Categoria c)
        {
            Validar(c);
            return _dao.Insertar(c);
        }

        public void Modificar(Categoria c)
        {
            if (c.IdCategoria <= 0)
                throw new ApplicationException("Seleccione una categoría válida para modificar.");
            Validar(c);
            _dao.Actualizar(c);
        }

        public void Eliminar(int idCategoria)
        {
            if (idCategoria <= 0)
                throw new ApplicationException("Seleccione una categoría para eliminar.");
            _dao.Eliminar(idCategoria);
        }

        private void Validar(Categoria c)
        {
            if (c == null)
                throw new ApplicationException("No hay datos de la categoría.");
            if (string.IsNullOrWhiteSpace(c.Nombre))
                throw new ApplicationException("El nombre de la categoría es obligatorio.");
        }
    }
}
