using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Restaurant.Datos;
using Restaurant.Entidades;

namespace Restaurant.Negocio
{
    public class PedidoBLL
    {
        private readonly PedidoDAO _dao = new PedidoDAO();

        public int RegistrarPedido(Pedido pedido)
        {
            if (pedido == null)
                throw new ApplicationException("No hay datos del pedido.");
            if (pedido.IdMesa <= 0)
                throw new ApplicationException("Debe seleccionar una mesa.");
            if (pedido.IdEmpleado <= 0)
                throw new ApplicationException("Debe seleccionar el mozo que atiende.");
            if (pedido.Detalles == null || pedido.Detalles.Count == 0)
                throw new ApplicationException("Debe agregar al menos un plato al pedido.");

            // Tema 5 - LINQ: cálculo del total a partir del subtotal de cada línea.
            pedido.Total = pedido.Detalles.Sum(d => d.Subtotal);

            if (string.IsNullOrWhiteSpace(pedido.Situacion))
                pedido.Situacion = "Atendido";

            return _dao.Registrar(pedido);
        }

        public List<Pedido> Listar()
        {
            return _dao.Listar();
        }

        public DataTable ListarTabla()
        {
            return _dao.ListarTabla();
        }

        public List<DetallePedido> ObtenerDetalle(int idPedido)
        {
            return _dao.ObtenerDetalle(idPedido);
        }

        public void CambiarSituacion(int idPedido, string situacion)
        {
            if (idPedido <= 0)
                throw new ApplicationException("Seleccione un pedido válido.");
            _dao.CambiarSituacion(idPedido, situacion);
        }
    }
}
