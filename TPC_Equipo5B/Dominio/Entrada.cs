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
        public Precio precio { get; set; }
        public Evento evento { get; set; }
        

        public Entrada()
        {
            IdEntrada = 0;
            precio =  new Precio();
            evento = new Evento();
        }

        public Evento Evento
        {
            get => default;
            set
            {
            }
        }
    }
}
