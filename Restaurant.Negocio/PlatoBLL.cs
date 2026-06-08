using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Restaurant.Datos;
using Restaurant.Entidades;

namespace Restaurant.Negocio
{
    public class PlatoBLL
    {
        private readonly PlatoDAO _dao = new PlatoDAO();

        public List<Plato> Listar()
        {
            return _dao.Listar();
        }

        public DataTable ListarTabla()
        {
            return _dao.ListarTabla();
        }

        public List<Plato> ListarDisponiblesPorCategoria(int idCategoria)
        {
            return _dao.Listar()
                       .Where(p => p.Estado && p.Disponible && p.IdCategoria == idCategoria)
                       .OrderBy(p => p.Precio)
                       .ToList();
        }

        public List<Plato> ListarDisponibles()
        {
            return _dao.Listar().Where(p => p.Estado && p.Disponible).ToList();
        }

        public int Registrar(Plato p)
        {
            Validar(p);
            return _dao.Insertar(p);
        }

        public void Modificar(Plato p)
        {
            if (p.IdPlato <= 0)
                throw new ApplicationException("Seleccione un plato válido para modificar.");
            Validar(p);
            _dao.Actualizar(p);
        }

        public void Eliminar(int idPlato)
        {
            if (idPlato <= 0)
                throw new ApplicationException("Seleccione un plato para eliminar.");
            _dao.Eliminar(idPlato);
        }

        private void Validar(Plato p)
        {
            if (p == null)
                throw new ApplicationException("No hay datos del plato.");
            if (string.IsNullOrWhiteSpace(p.Nombre))
                throw new ApplicationException("El nombre del plato es obligatorio.");
            if (p.IdCategoria <= 0)
                throw new ApplicationException("Debe seleccionar una categoría.");
            if (p.Precio <= 0)
                throw new ApplicationException("El precio debe ser mayor que cero.");
        }
    }
}
