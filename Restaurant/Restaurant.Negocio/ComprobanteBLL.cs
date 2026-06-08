using System;
using Restaurant.Datos;
using Restaurant.Entidades;

namespace Restaurant.Negocio
{
    public class ComprobanteBLL
    {
        private const decimal TasaIgv = 0.18m;
        private readonly ComprobanteDAO _dao = new ComprobanteDAO();

        public Comprobante Generar(int idPedido, string tipo, decimal totalPedido)
        {
            if (idPedido <= 0)
                throw new ApplicationException("Seleccione un pedido para facturar.");
            if (totalPedido <= 0)
                throw new ApplicationException("El total del pedido debe ser mayor que cero.");

            Comprobante c = new Comprobante
            {
                IdPedido = idPedido,
                Tipo = tipo,
                Serie = tipo == "Factura" ? "F001" : "B001",
                Total = decimal.Round(totalPedido, 2),
                Fecha = DateTime.Now
            };
            c.SubTotal = decimal.Round(c.Total / (1 + TasaIgv), 2);
            c.Igv = decimal.Round(c.Total - c.SubTotal, 2);

            c.IdComprobante = _dao.Registrar(c);
            return c;
        }
    }
}
