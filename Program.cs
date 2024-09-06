using Sistema;
using System.Collections.Generic;
using System.IO;
using System.Text;
string micad = "cadeteria.csv";
string miscadetes = "cadetes.csv";
AccesoCSV Archivados = new AccesoCSV();
Cadeteria MiCadeteria = null;

if (Archivados.Existe(micad) && Archivados.Existe(miscadetes))
{
    MiCadeteria = Archivados.LeerCadeteria(micad)[0];
    MiCadeteria.CargarCadetes(Archivados.LeerCadetes(miscadetes));
}
Console.WriteLine("Desea ingresar un nuevo pedido? (s/n)");
string respuesta = Console.ReadLine();
int i = 0;
if (respuesta != "n")
{
    do
    {
        Console.WriteLine("Nombre cliente: ");
        string nom = Console.ReadLine();
        Console.WriteLine("Direccion cliente: ");
        string dire = Console.ReadLine();
        Console.WriteLine("Telefono cliente: ");
        string tel = Console.ReadLine();
        Console.WriteLine("Alguna referencia para el cadete: ");
        string refe = Console.ReadLine();
        Cliente NCliente = new Cliente(nom,dire,tel,refe);
        Console.WriteLine("Descripcion del pedido: ");
        string obs = Console.ReadLine();
        Pedido NPedido = new Pedido(i,obs,NCliente);
        Random random = new Random();
        MiCadeteria.agregarPedido(NPedido,random.Next(0, 3));
        i++;
        Console.WriteLine(NPedido.VerDatosCliente());
    } while (respuesta != "n");
}