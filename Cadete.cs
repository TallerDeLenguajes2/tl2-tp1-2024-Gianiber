namespace Sistema
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private uint telefono;
        private List<Pedido>? listadoPedidos;
        public Cadete(int id, string nombre, string direccion, string telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = uint.Parse(telefono);
            listadoPedidos = new List<Pedido>();
        }
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public uint Telefono { get => telefono; set => telefono = value; }
        public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
        public void SumarPedido(Pedido p)
        {
            listadoPedidos.Add(p);
        }
        public string Mostrar()
        {
            return $"ID: {id}, Nombre: {nombre}, teléfono: {telefono}, dirección: {direccion}";
        }
    }
}