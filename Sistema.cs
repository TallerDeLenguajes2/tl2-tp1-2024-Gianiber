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
        private List<Cadete> listadoCadetes;
        public Cadeteria(string nombre, string telefono)
        {
            this.nombre = nombre;
            this.telefono = uint.Parse(telefono);
            listadoCadetes = null;
        }
        public string Mostrar()
        {
            return $"Nombre: {nombre}, teléfono: {telefono}";
        }
        public void CargarCadetes(List<Cadete> ListaCad)
        {
            listadoCadetes = ListaCad;
        }
        public void agregarPedido(Pedido pedido,int nro)
        {
            foreach (Cadete cade in listadoCadetes)
            {
                if (cade.Id == nro)
                {
                    pedido.IdEncargado = nro;
                    cade.ListadoPedidos.Add(pedido);
                }
            }
        }
        public void cambiarEstado(int nro,int estado)
        {
            foreach (Cadete cadet in listadoCadetes)
            {
                foreach (Pedido pedidoX in cadet.ListadoPedidos)
                {
                    if (pedidoX.Nro == nro)
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
        public void UpdPedido(int nro, int id)
        {
            foreach (Cadete cadeteX in listadoCadetes)
            {
                if (cadeteX.Id == id)
                {
                    foreach (Pedido pedidoX in cadeteX.ListadoPedidos)
                    {
                        if (pedidoX.Nro == nro)
                        {
                            pedidoX.IdEncargado = id;
                        }
                    }
                }
            }
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