namespace Restaurant.Entidades
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public Categoria()
        {
            Estado = true;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
