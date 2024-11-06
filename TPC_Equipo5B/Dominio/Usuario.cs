using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUsuario
    {
        ADMIN = 1,
        CLIENTE = 2
    }
    public class Usuario : Cliente
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public TipoUsuario TipoUsuario { get; set; }


        public Evento Evento
        {
            get => default;
            set
            {
            }
        }

        public Usuario()
        {
        }

        public Usuario(string usuario, string password, bool admin)
        {
            NombreUsuario = usuario;
            Pass = password;

            TipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario.CLIENTE;
        }
    }
}