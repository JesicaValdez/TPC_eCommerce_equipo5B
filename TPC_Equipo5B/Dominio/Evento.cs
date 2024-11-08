using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Evento
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public TipoEvento tipoEvento { get; set; }
        //public decimal precioEntrada { get; set; }
        public int entradasDisponibles { get; set; }
        public DateTime fecha { get; set; }
        public List<Imagen> imagenes { get; set; }  // Lista de imágenes

        public Evento()
        {
            id = 0;
            codigo = string.Empty;
            nombre = string.Empty;
            descripcion = string.Empty;
            tipoEvento = new TipoEvento();
            //precioEntrada = 0;
            entradasDisponibles = 0;
            fecha = DateTime.MinValue;
            imagenes = new List<Imagen>(); // Inicializar la lista
        }
    }
}
