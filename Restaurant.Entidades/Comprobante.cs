using System;

namespace Restaurant.Entidades
{
    public class Comprobante
    {
        public int IdComprobante { get; set; }
        public int IdPedido { get; set; }
        public string Tipo { get; set; }        // Boleta / Factura
        public string Serie { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }

        public Comprobante()
        {
            Tipo = "Boleta";
            Serie = "B001";
            Fecha = DateTime.Now;
        }
    }
}
