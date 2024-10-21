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
        public int Id {  get; set; }
        public string Dni {  get; set; }
        public string Nombre { get; set; }
        public string Apellido {  get; set; }
        public string Email {  get; set; }
        public string Direccion {  get; set; }
        public string Ciudad {  get; set; }
        public int CodigoPostal {  get; set; }

        public Cliente()
        {
            Id = 0;
            Dni = "";
            Nombre = "";
            Apellido = "";
            Email = "";
            Direccion = "";
            Ciudad = "";
            CodigoPostal = 0;
        }
    }
}
