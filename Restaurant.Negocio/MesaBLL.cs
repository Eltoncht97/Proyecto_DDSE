using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Restaurant.Datos;
using Restaurant.Entidades;

namespace Restaurant.Negocio
{
    public class MesaBLL
    {
        private readonly MesaDAO _dao = new MesaDAO();

        public List<Mesa> Listar()
        {
            return _dao.Listar();
        }

        public DataTable ListarTabla()
        {
            return _dao.ListarTabla();
        }

        public List<Mesa> ListarActivas()
        {
            return _dao.Listar().Where(m => m.Estado).OrderBy(m => m.Numero).ToList();
        }

        public int Registrar(Mesa m)
        {
            Validar(m);
            return _dao.Insertar(m);
        }

        public void Modificar(Mesa m)
        {
            if (m.IdMesa <= 0)
                throw new ApplicationException("Seleccione una mesa válida para modificar.");
            Validar(m);
            _dao.Actualizar(m);
        }

        public void Eliminar(int idMesa)
        {
            if (idMesa <= 0)
                throw new ApplicationException("Seleccione una mesa para eliminar.");
            _dao.Eliminar(idMesa);
        }

        private void Validar(Mesa m)
        {
            if (m == null)
                throw new ApplicationException("No hay datos de la mesa.");
            if (m.Numero <= 0)
                throw new ApplicationException("El número de mesa debe ser mayor que cero.");
            if (m.Capacidad <= 0)
                throw new ApplicationException("La capacidad debe ser mayor que cero.");
        }
    }
}
