using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Net;

namespace Sistema
{
    public class Cadeteria
    {
        private string nombre;
        private uint telefono;
        private List<Cadete>? listadoCadetes;

        public string Nombre { get => nombre; set => nombre = value; }
        public uint Telefono { get => telefono; set => telefono = value; }
        public List<Cadete>? ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

        public Cadeteria(string nombre, string telefono)
        {
            this.Nombre = nombre;
            this.Telefono = uint.Parse(telefono);
            ListadoCadetes = null;
        }
        public void CargarCadetes(List<Cadete> ListaCad)
        {
            ListadoCadetes = ListaCad;
        }
        public bool AsignarPedido(Pedido pedido,int nro)
        {
            foreach (Cadete cade in ListadoCadetes)
            {
                if (cade.Id == nro)
                {
                    if (pedido.CadeteEncargado == null)
                    {
                        pedido.CadeteEncargado = cade;
                        pedido.Estado = EstadoPedido.Pendiente;
                        cade.SumarPedido(pedido);
                        return true;
                    }
                }
            }
            return false;
        }
        public void CambiarEstado(int nroP,int estado)
        {
            foreach (Cadete cadet in ListadoCadetes)
            {
                foreach (Pedido pedidoX in cadet.ListadoPedidos)
                {
                    if (pedidoX.Nro == nroP)
                    {
                        switch (estado)
                        {
                            case 0:
                                pedidoX.Estado = EstadoPedido.SinCadete;
                                break;
                            case 1:
                                pedidoX.Estado = EstadoPedido.Pendiente;
                                break;
                            case 2:
                                pedidoX.Estado = EstadoPedido.EnCamino;
                                break;
                            case 3:
                                pedidoX.Estado = EstadoPedido.Completado;
                                break;
                            default:
                                pedidoX.Estado = EstadoPedido.SinCadete;
                                break;
                        }
                    }
                }   
            }
        }
        public void UpdPedido(int nroP, int idC)
        {
            Pedido Aux = null;
            foreach (Cadete cadeteX in ListadoCadetes)
            {
                foreach (Pedido pedidoX in cadeteX.ListadoPedidos)
                {
                    if (nroP == pedidoX.Nro)
                    {
                        Aux = pedidoX;
                    }
                }
                cadeteX.ListadoPedidos.RemoveAll(p => p.Nro == nroP);
            }
            if (Aux != null)
            {
                foreach (Cadete cadeteX in ListadoCadetes)
                {
                    if (cadeteX.Id == idC)
                    {
                        cadeteX.SumarPedido(Aux);
                    }
                }
            }
        }
        public int JornalACobrar(int idC)
        {
            foreach (Cadete cadeteX in listadoCadetes)
            {
                if (cadeteX.Id == idC)
                {
                    int pedidosEntregados = cadeteX.ListadoPedidos.FindAll(p => p.Estado == EstadoPedido.Completado).Count;
                    return pedidosEntregados * 500;   
                }
            }
            return 0;
        }
        public string Informe()
        {
            int total = 0;
            int j = 0;
            string p = "";
            foreach (Cadete cadeteX in listadoCadetes)
            {
                int pedidosEntregados = cadeteX.ListadoPedidos.FindAll(p => p.Estado == EstadoPedido.Completado).Count;
                total += JornalACobrar(cadeteX.Id);
                j++;
                p += $"El cadete {cadeteX.Nombre} hizo un total de {pedidosEntregados} ganando {JornalACobrar(cadeteX.Id)}\n";
            }
            float promedio = total / (500*j);
            return p + $"El total ganado fue de: {total}\nEl promedio de envios exitosos fue de: {promedio}";
        }
    }
    public class AccesoCSV
    {
        public List<Cadeteria> LeerCadeteria(string nombreArchivo)
        {
            List<Cadeteria> LineasCSV = new List<Cadeteria>();
            if (File.Exists(nombreArchivo))
            {
                string[] cadeteria = File.ReadAllLines(nombreArchivo);
                foreach (var line in cadeteria)
                {
                    string[] datos = line.Split(',');
                    Cadeteria Nueva = new Cadeteria(datos[0],datos[1]);
                    LineasCSV.Add(Nueva);
                }
                return LineasCSV;
            }
            else
            {
                return null;
            }
        }
        public List<Cadete> LeerCadetes(string path)
        {
            List<Cadete> LineasCadetesCSV = new List<Cadete>();
            int i = 0;
            if (File.Exists(path))
            {
                string[] cadetes = File.ReadAllLines(path);
                foreach (var line in cadetes)
                {
                    string[] datos = line.Split(',');
                    Cadete Nuevo = new Cadete(i,datos[0],datos[1],datos[2]);
                    i++;
                    LineasCadetesCSV.Add(Nuevo);
                }
                return LineasCadetesCSV;
            }
            else
            {
                return null;
            }
        }
        public bool Existe(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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