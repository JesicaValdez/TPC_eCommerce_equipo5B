using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoUsuario
    {
        public int IdTipoUsuario { get; set; }
        public string TiposUsuario { get; set; }

        public TipoUsuario()
        {
            IdTipoUsuario = 0;
            TiposUsuario = string.Empty;
        }

        public TipoUsuario(int idTipoUsuario, string descripcion)
        {
            IdTipoUsuario = idTipoUsuario;
            TiposUsuario = descripcion;
        }
    }
}