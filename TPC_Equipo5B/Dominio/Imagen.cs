using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Imagen
    {
        public int IdEvento { get; set; }
        public string Url { get; set; }
        
        public Imagen()
        {
            IdEvento = 0;
            Url = string.Empty;
        }
    }
}
