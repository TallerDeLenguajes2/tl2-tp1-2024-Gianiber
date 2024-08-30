using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Net;

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
        public Cliente(string nom,string dire, uint tel, string refe)
        {
            nombre = nom;
            direccion = dire;
            telefono = tel;
            datosReferenciaDireccion = refe;
        }
        public global::System.String Nombre { get => nombre; set => nombre = value; }
        public global::System.String Direccion { get => direccion; set => direccion = value; }
        public global::System.UInt32 Telefono { get => telefono; set => telefono = value; }
        public global::System.String DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }
    }
    public class Pedido
    {
        private int Nro;
        private string Obs;
        private Cliente Cliente;
        private EstadoPedido Estado;
        public Pedido(int id, string observacion, Cliente cl)
        {
            Nro = id;
            Obs = observacion;
            Cliente = cl;
            Estado = EstadoPedido.SinCadete;
        }
        public string VerDireccionCliente(int numero)
        {
            return Cliente.Direccion;
        }

        public void DatosCliente()
        {
            Console.WriteLine("Datos del cliente:\n");
            Console.WriteLine("Nombre: " + Cliente.Nombre + "\n");
            Console.WriteLine("Telefono: " + Cliente.Telefono + "\n");
            Console.WriteLine("Direccion (datos de referencia): " + Cliente.Direccion + " (" + Cliente.DatosReferenciaDireccion + ")\n");
        }
    }
    public class Cadete
    {
        private int id;
        private string Nombre;
        private string Direccion;
        private uint Telefono;
        private List<Pedido> ListadoPedidos
    }
    public class Cadeteria
    {
        private string Nombre;
        private uint Telefono;
        private List<Cadete> ListadoCadetes;

        /*public AltaPedidos
        */

        /*public Cadeteria(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                string prod = File.ReadAllText(nombreArchivo);
                List<Cadete>? CadeteTexto = JsonSerializer.Deserialize<List<Cadete>>(prod);
                return CadeteTexto;
            }
            else
            {
                return null;
            }
        }*/

        /*public List<Cadete>? AltaCadete(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                string prod = File.ReadAllText(nombreArchivo);
                List<Cadete>? CadeteTexto = JsonSerializer.Deserialize<List<Cadete>>(prod);
                return CadeteTexto;
            }
            else
            {
                return null;
            }
        }*/
    }
}