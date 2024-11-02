using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Entrada
    {
        public int IdEntrada { get; set; }
        public int codigo { get; set; }
        public Evento evento { get; set; }
        public Cliente cliente { get; set; }
        public DateTime fechaCompra { get; set; }

        public Evento Evento
        {
            get => default;
            set
            {
            }
        }
    }
}
