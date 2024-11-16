using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dominio
{
    public class Cliente
    {
        public int IdCliente {  get; set; }
        public string Dni {  get; set; }
        public string Nombre { get; set; }
        public string Apellido {  get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string Telefono {  get; set; }

        internal Compra Carrito
        {
            get => default;
            set
            {
            }
        }

        public Cliente()
        {
            IdCliente = 0;
            Dni = "";
            Nombre = "";
            Apellido = "";
            fechaNacimiento = DateTime.MinValue;
            Telefono = "";
        }
    }
}
