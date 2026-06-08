using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Restaurant.Datos;
using Restaurant.Entidades;

namespace Restaurant.Negocio
{
    public class ClienteBLL
    {
        private readonly ClienteDAO _dao = new ClienteDAO();

        public List<Cliente> Listar()
        {
            return _dao.Listar();
        }

        public DataTable ListarTabla()
        {
            return _dao.ListarTabla();
        }

        public List<Cliente> ListarActivos()
        {
            return _dao.Listar().Where(c => c.Estado).OrderBy(c => c.Nombres).ToList();
        }

        public int Registrar(Cliente c)
        {
            Validar(c);
            return _dao.Insertar(c);
        }

        public void Modificar(Cliente c)
        {
            if (c.IdCliente <= 0)
                throw new ApplicationException("Seleccione un cliente válido para modificar.");
            Validar(c);
            _dao.Actualizar(c);
        }

        public void Eliminar(int idCliente)
        {
            if (idCliente <= 0)
                throw new ApplicationException("Seleccione un cliente para eliminar.");
            _dao.Eliminar(idCliente);
        }

        private void Validar(Cliente c)
        {
            if (c == null)
                throw new ApplicationException("No hay datos del cliente.");
            if (string.IsNullOrWhiteSpace(c.Nombres))
                throw new ApplicationException("El nombre del cliente es obligatorio.");
        }
    }
}
