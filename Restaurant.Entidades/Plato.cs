namespace Restaurant.Entidades
{
    public class Plato
    {
        public int IdPlato { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }   // nombre de categoría (para grillas)
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }
        public bool Estado { get; set; }

        public Plato()
        {
            Disponible = true;
            Estado = true;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
