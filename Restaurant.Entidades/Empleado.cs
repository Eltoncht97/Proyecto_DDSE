namespace Restaurant.Entidades
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Cargo { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }

        public string NombreCompleto
        {
            get { return (Nombres + " " + Apellidos).Trim(); }
        }

        public Empleado()
        {
            Cargo = "Mozo";
            Estado = true;
        }

        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}
