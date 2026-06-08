namespace Restaurant.Entidades
{
    public class Mesa
    {
        public int IdMesa { get; set; }
        public int Numero { get; set; }
        public int Capacidad { get; set; }
        public string Ubicacion { get; set; }
        public string Situacion { get; set; }   // Libre / Ocupada / Reservada
        public bool Estado { get; set; }

        public Mesa()
        {
            Capacidad = 4;
            Situacion = "Libre";
            Estado = true;
        }

        public override string ToString()
        {
            return "Mesa " + Numero;
        }
    }
}
