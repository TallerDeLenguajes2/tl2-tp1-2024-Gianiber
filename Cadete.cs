namespace Sistema
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private long telefono;
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public long Telefono { get => telefono; set => telefono = value; }
        public Cadete(int id, string nombre, string direccion, long telefono)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }
        public string Mostrar()
        {
            return $"ID: {id}, Nombre: {nombre}, teléfono: {telefono}, dirección: {direccion}";
        }
    }
}