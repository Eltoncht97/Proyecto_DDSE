using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Restaurant.Datos;
using Restaurant.Entidades;

namespace Restaurant.Negocio
{
    public class EmpleadoBLL
    {
        private readonly EmpleadoDAO _dao = new EmpleadoDAO();

        public List<Empleado> Listar()
        {
            return _dao.Listar();
        }

        public DataTable ListarTabla()
        {
            return _dao.ListarTabla();
        }

        public List<Empleado> ListarMozos()
        {
            return _dao.Listar()
                       .Where(e => e.Estado && e.Cargo == "Mozo")
                       .OrderBy(e => e.Apellidos)
                       .ToList();
        }

        public int Registrar(Empleado e)
        {
            Validar(e);
            return _dao.Insertar(e);
        }

        public void Modificar(Empleado e)
        {
            if (e.IdEmpleado <= 0)
                throw new ApplicationException("Seleccione un empleado válido para modificar.");
            Validar(e);
            _dao.Actualizar(e);
        }

        public void Eliminar(int idEmpleado)
        {
            if (idEmpleado <= 0)
                throw new ApplicationException("Seleccione un empleado para eliminar.");
            _dao.Eliminar(idEmpleado);
        }

        private void Validar(Empleado e)
        {
            if (e == null)
                throw new ApplicationException("No hay datos del empleado.");
            if (string.IsNullOrWhiteSpace(e.Nombres))
                throw new ApplicationException("Los nombres son obligatorios.");
            if (string.IsNullOrWhiteSpace(e.Apellidos))
                throw new ApplicationException("Los apellidos son obligatorios.");
            if (string.IsNullOrWhiteSpace(e.Dni) || e.Dni.Length != 8)
                throw new ApplicationException("El DNI debe tener 8 dígitos.");
        }
    }
}
