namespace Restaurant.Entidades
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Documento { get; set; }   // DNI (8) o RUC (11)
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }

        public string NombreCompleto
        {
            get { return (Nombres + " " + Apellidos).Trim(); }
        }

        public Cliente()
        {
            Estado = true;
        }

        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}
