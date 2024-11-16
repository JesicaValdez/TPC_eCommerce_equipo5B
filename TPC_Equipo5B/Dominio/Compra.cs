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
        public Entrada entrada {  get; set; }
        public Cliente cliente { get; set; }
        public DateTime fechaCompra { get; set; }
        public int cantidadEntradas {  get; set; }


        public Compra()
        {
            idCompra = 0;
            entrada = new Entrada();
            cliente = new Cliente();
            fechaCompra = DateTime.MinValue;
            cantidadEntradas = 0;
        }
    }
}
