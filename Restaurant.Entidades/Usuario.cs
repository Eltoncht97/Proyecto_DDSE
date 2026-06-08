namespace Restaurant.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string NombreCompleto { get; set; }
        public string Rol { get; set; }
        public bool Estado { get; set; }

        public Usuario()
        {
            Estado = true;
        }
    }
}
