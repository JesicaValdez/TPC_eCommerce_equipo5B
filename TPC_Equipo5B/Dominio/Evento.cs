using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dominio
{
    public class Evento
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public TipoEvento tipoEvento { get; set; }
        public decimal precioEntrada { get; set; }
        public int entradasDisponibles { get; set; }
        public DateTime fecha { get; set; }
        public string imagenurl { get; set; }

        public TipoEvento TipoEvento
        {
            get => default;
            set
            {
            }
        }
    }
}
