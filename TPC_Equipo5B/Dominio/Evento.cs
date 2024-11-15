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
        public string lugar { get; set; }
        public string direccion { get; set; }
        //public decimal precios { get; set; }  
        public TipoEvento tipoEvento { get; set; }
        public int entradasDisponibles { get; set; }
        public DateTime fecha { get; set; }
        public List<Imagen> imagenes { get; set; }  // Lista de imágenes
        public string imagenUrl { get; set; }


        public Evento()
        {
            id = 0;
            codigo = string.Empty;
            nombre = string.Empty;
            descripcion = string.Empty;
            lugar = string.Empty;
            direccion = string.Empty;
            tipoEvento = new TipoEvento();
            //precio = 0;
            entradasDisponibles = 0;
            fecha = DateTime.MinValue;
            imagenUrl= string.Empty;
            imagenes = new List<Imagen>();
        }

    }
}
