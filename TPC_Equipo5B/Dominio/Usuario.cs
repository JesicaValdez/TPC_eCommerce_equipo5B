using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public Usuario()
        {
            IdUsuario = 0;
            NombreUsuario = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            TipoUsuario = new TipoUsuario();
        }

        public Usuario(int idUsuario, string nombreUsuario, string apellido, string email, string password, TipoUsuario tipoUsuario)
        {
            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;
            Email = email;
            Password = password;
            TipoUsuario = tipoUsuario;
        }
    }
}