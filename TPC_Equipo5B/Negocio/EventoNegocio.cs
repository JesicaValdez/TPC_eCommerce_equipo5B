using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Dominio;

namespace Negocio
{
    public class EventoNegocio
    {
        private List<Evento> listaEventos = new List<Evento>();
        
        AccesoDB datos = new AccesoDB();

        public EventoNegocio()
        {
            datos = new AccesoDB();
        }

        public List<Evento> listarEventos()
        {
            List<Evento> lista = new List<Evento>();

            try
            {
                datos.setearConsulta("select Codigo, Nombre, e.Descripcion, te.Descripcion as TipoEvento, Fecha, PrecioEntrada, CantidadEntradas from Eventos e inner join TiposEvento te on e.IdTipoEvento = te.Id order by Fecha asc");
                datos.ejecutarLectura();

                if (datos.Lector == null)
                {
                    throw new Exception("El lector no se inicializó.");
                }

                if (!datos.Lector.HasRows)
                {
                    throw new Exception("No hay filas para leer.");
                }

                while (datos.Lector.Read())
                {
                    Evento aux = new Evento();
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.tipoEvento = new TipoEvento();
                    aux.tipoEvento.descripcion = (string)datos.Lector["TipoEvento"];
                    aux.fecha = (DateTime)datos.Lector["Fecha"];
                    aux.precioEntrada = (decimal)datos.Lector["PrecioEntrada"];
                    aux.entradasDisponibles = (int)datos.Lector["CantidadEntradas"];
                    aux.imagenurl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRRCZVKWKAUmqHUszu8_M3CoepdRNIXk9SvZQ&s";
                    
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Evento> filtrarportipo(string tipo)
        {
            EventoNegocio negocio = new EventoNegocio();
            List<Evento> lista1 = negocio.listarEventos();
            List<Evento> lista2 = new List<Evento>();
            foreach (Evento art in lista1)
            {
                if (art.tipoEvento.descripcion == tipo)
                {
                    lista2.Add(art);
                }
            }
            return lista2;
        }
    }
}
