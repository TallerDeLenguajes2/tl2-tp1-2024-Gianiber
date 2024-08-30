using Sistema;
using System.Collections.Generic;
using System.IO;
using System.Text;

Console.WriteLine("Desea ingresar un nuevo pedido? (s/n)");
string respuesta = Console.ReadLine();
if (respuesta != "n")
{
    do
    {
        Console.WriteLine("Nombre cliente: ");
        string nom = Console.ReadLine();
        Console.WriteLine("Direccion cliente: ");
        string dire = Console.ReadLine();
        Console.WriteLine("Telefono cliente: ");
        uint tel = Convert.ToUInt32(Console.ReadLine());
        Console.WriteLine("Alguna referencia para el cadete: ");
        string refe = Console.ReadLine();
        Cliente NCliente = new Cliente(nom,dire,tel,refe);
        ListaTareas.Add(NTarea);
    } while (respuesta != "n");   
}