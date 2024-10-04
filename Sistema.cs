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
        private long telefono;
        private List<Cadete>? listadoCadetes;
        private List<Pedido>? listadoPedidos;

        public string Nombre { get => nombre; set => nombre = value; }
        public long Telefono { get => telefono; set => telefono = value; }
        public List<Cadete>? ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
        public List<Pedido>? ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

        public Cadeteria(string nombre, long telefono,List<Cadete> listadoCadetes,List<Pedido> listadoPedidos)
        {
            this.Nombre = nombre;
            this.Telefono = telefono;
            ListadoCadetes = null;
            ListadoPedidos = new List<Pedido>();
        }
        public string MostrarInformacion(){
            string p = $"Cadeteria {Nombre}\n";
            foreach (Cadete cadeteX in listadoCadetes)
            {
                p += $"ID: {cadeteX.Id}, Nombre: {cadeteX.Nombre}, teléfono: {cadeteX.Telefono}, dirección: {cadeteX.Direccion}\n";
            }
            return p;
        }
        public void CargarCadetes(List<Cadete> ListaCad)
        {
            listadoCadetes = ListaCad;
        }
        public void SumarPedido(Pedido p)
        {
            listadoPedidos.Add(p);
        }
        public bool AsignarPedido(Pedido pedido,int nro)
        {
            foreach (Cadete cade in listadoCadetes)
            {
                if (cade.Id == nro)
                {
                    if (pedido.CadeteEncargado == null)
                    {
                        pedido.CadeteEncargado = cade;
                        pedido.Estado = EstadoPedido.Pendiente;
                        SumarPedido(pedido);
                        return true;
                    }
                }
            }
            return false;
        }
        public void CambiarEstado(int nroP,int estado)
        {
            foreach (Pedido pedidoX in listadoPedidos)
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
        public void UpdPedido(int nroP, int idC)
        {
            foreach (Pedido pedidoX in listadoPedidos)
            {
                if (nroP == pedidoX.Nro)
                {
                    foreach (Cadete cadeteX in listadoCadetes)
                    {
                        if (cadeteX.Id == idC)
                        {
                            pedidoX.CadeteEncargado = cadeteX;
                        }
                    }
                }
            }
        }
        public float JornalACobrar(int idC)
        {
            int pedidosEntregados = listadoPedidos.FindAll(p => p.Estado == EstadoPedido.Completado && p.CadeteEncargado.Id == idC).Count;
            return pedidosEntregados * 500;
        }
        public string Informe()
        {
            float total = 0;
            int j = 0;
            string p = "";
            foreach (Cadete cadeteX in listadoCadetes)
            {
                int pedidosEntregados = listadoPedidos.FindAll(p => p.Estado == EstadoPedido.Completado && p.CadeteEncargado.Id == cadeteX.Id).Count;
                total += JornalACobrar(cadeteX.Id);
                j++;
                p += $"El cadete {cadeteX.Nombre} hizo un total de {pedidosEntregados} ganando {JornalACobrar(cadeteX.Id)}\n";
            }
            float promedio = total / (500*j);
            return p + $"El total ganado fue de: {total}\nEl promedio de envios exitosos fue de: {promedio}";
        }
    }
}