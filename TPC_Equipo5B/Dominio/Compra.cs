using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        public int idCompra {  get; set; }
        public Evento evento {  get; set; }
        public Cliente cliente { get; set; }
        public string tipoEntrada {  get; set; }
        public int cantidadEntradas {  get; set; }
        public DateTime fechaCompra { get; set; }
        public decimal montoTotal {  get; set; }
        public bool estado {  get; set; }


        public Compra()
        {
            idCompra = 0;
            evento = new Evento();
            cliente = new Cliente();
            tipoEntrada = "";
            cantidadEntradas = 0;
            fechaCompra = DateTime.MinValue;
            montoTotal = 0;
            estado = true;
        }
    }
}
