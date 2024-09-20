namespace Sistema
{
    enum EstadoPedido
    {
        SinCadete,
        Pendiente,
        EnCamino,
        Completado
    }
    public class Cliente
    {
        private string nombre;
        private string direccion;
        private uint telefono;
        private string datosReferenciaDireccion;
        public Cliente(string nom,string dire, string tel, string refe)
        {
            nombre = nom;
            direccion = dire;
            telefono = uint.Parse(tel);
            datosReferenciaDireccion = refe;
        }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public uint Telefono { get => telefono; set => telefono = value; }
        public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }
    }
    public class Pedido
    {
        private int nro;
        private string obs;
        private Cliente cliente;
        private EstadoPedido estado;
        private Cadete? cadeteEncargado;
        public int Nro { get => nro; set => nro = value; }
        public string Obs { get => obs; set => obs = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        internal EstadoPedido Estado { get => estado; set => estado = value; }
        public Cadete CadeteEncargado { get => cadeteEncargado; set => cadeteEncargado = value; }

        public Pedido(int id, string observacion, Cliente cl)
        {
            nro = id;
            obs = observacion;
            cliente = cl;
            estado = EstadoPedido.SinCadete;
            cadeteEncargado = null;
        }
        public string VerDireccionCliente(int numero)
        {
            return cliente.Direccion;
        }

        public string VerDatosCliente()
        {
            return $"Datos del cliente:\nNombre: {cliente.Nombre}\nTelefono: {cliente.Telefono}\nDirección (datos de referencia): {cliente.Direccion} ({cliente.DatosReferenciaDireccion})";
        }
    }
}