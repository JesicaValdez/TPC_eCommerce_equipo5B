using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Precio
    {
        public int idPrecio { get; set; }
        public int idEvento { get; set; }
        public string tipoEntrada { get; set; }
        public decimal precio { get; set; }
        public int cantidadEntradas {  get; set; }


        public Precio()
        {
            idPrecio = 0;
            idEvento = 0;
            tipoEntrada = string.Empty;
            precio = 0;
            cantidadEntradas = 0;

        }
    }

    
}
