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
//CARGA PERSONAL
Random random = new Random();
Cliente Carlos = new Cliente("Carlos","Peru 120","3815900800","Porton negro");
Pedido Pedido1 = new Pedido(0,"Pizza napo",Carlos);
MiCadeteria.AsignarPedido(Pedido1,1);
Cliente Pepe = new Cliente("Pepe","Peru 200","3815123456","Casa roja");
Pedido Pedido2 = new Pedido(1,"Docena de pollo",Pepe);
MiCadeteria.AsignarPedido(Pedido2,1);
MiCadeteria.CambiarEstado(1,3);
Console.WriteLine(MiCadeteria.Informe());

//CARGA MANUAL DE PEDIDOS
/*Console.WriteLine("Desea ingresar un nuevo pedido? (s/n)");
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
        MiCadeteria.AsignarPedido(NPedido,random.Next(0, 2));
//        MiCadeteria.AsignarPedido(NPedido,0);
        i++;
        Console.WriteLine(NPedido.VerDatosCliente());
        Console.WriteLine(NPedido.CadeteEncargado.Mostrar());
        Console.WriteLine("Desea ingresar un nuevo pedido? (s/n)");
        respuesta = Console.ReadLine();
    } while (respuesta != "n");
}
Console.WriteLine("Desea actualizar un pedido? (s/n)");
respuesta = Console.ReadLine();
if (respuesta != "n")
{
    Console.WriteLine("Ingrese el numero del pedido:");
    int nroPedido = int.Parse(Console.ReadLine());
    Console.WriteLine("Ingrese el numero del cadete a asignar:");
    int idCadete = int.Parse(Console.ReadLine());
    MiCadeteria.UpdPedido(nroPedido,idCadete);
    foreach (Cadete cadeteX in MiCadeteria.ListadoCadetes)
    {
        if (cadeteX.Id == idCadete)
        {
            foreach (Pedido pedidoX in cadeteX.ListadoPedidos)
            {
                Console.WriteLine(pedidoX.Cliente.Direccion);
            }
        }
    }
}
Console.WriteLine("Desea actualizar el estado de un pedido? (s/n)");
respuesta = Console.ReadLine();
if (respuesta != "n")
{
    Console.WriteLine("Ingrese el numero del pedido:");
    int numeroPedido = int.Parse(Console.ReadLine());
    Console.WriteLine("Ingrese el nuevo estado del pedido:\n1-Pendiente\n2-En camino\n3-Completado");
    int estadoPedido = int.Parse(Console.ReadLine());
    MiCadeteria.CambiarEstado(numeroPedido,estadoPedido);
    foreach (Cadete cadeteX in MiCadeteria.ListadoCadetes)
    {
        foreach (Pedido pedidoX in cadeteX.ListadoPedidos)
        {
            if (pedidoX.Nro == numeroPedido)
            {
                Console.WriteLine(pedidoX.Estado);   
            }
        }
    }
}*/