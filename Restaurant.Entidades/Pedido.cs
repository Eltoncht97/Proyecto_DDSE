using System;
using System.Collections.Generic;

namespace Restaurant.Entidades
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime Fecha { get; set; }
        public int IdMesa { get; set; }
        public int IdEmpleado { get; set; }
        public int? IdCliente { get; set; }
        public string Situacion { get; set; }   // Pendiente / Atendido / Pagado / Anulado
        public decimal Total { get; set; }

        // Campos descriptivos para listados
        public string Mesa { get; set; }
        public string Mozo { get; set; }
        public string Cliente { get; set; }

        public List<DetallePedido> Detalles { get; set; }

        public Pedido()
        {
            Fecha = DateTime.Now;
            Situacion = "Pendiente";
            Detalles = new List<DetallePedido>();
        }
    }
}
