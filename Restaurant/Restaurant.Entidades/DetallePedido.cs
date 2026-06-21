namespace Restaurant.Entidades
{
    public class DetallePedido
    {
        public int IdDetalle { get; set; }
        public int IdPedido { get; set; }
        public int IdPlato { get; set; }
        public string Plato { get; set; }       // nombre del plato (para grillas)
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string EstadoDetalle { get; set; }   // Solicitado / Servido (estado de cocina)

        public decimal Subtotal
        {
            get { return Cantidad * PrecioUnitario; }
        }

        public DetallePedido()
        {
            Cantidad = 1;
            EstadoDetalle = "Solicitado";
        }
    }
}
