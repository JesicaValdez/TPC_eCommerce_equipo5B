using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Dominio;
using System.Collections;

namespace Negocio
{
    public class EventoNegocio
    {
        private AccesoDB datos = new AccesoDB();

        public List<Evento> listarEventos()
        {
            List<Evento> listaEventos= new List<Evento>();
            
            try
            {
                datos.setearConsulta("SELECT e.Id, e.Codigo, e.Nombre, e.Descripcion, te.Id AS TipoEventoId, te.Descripcion, e.Fecha, e.PrecioEntrada, e.CantidadEntradas, i.ImagenUrl FROM Eventos e INNER JOIN TiposEvento te ON e.IdTipoEvento = te.Id LEFT JOIN Imagenes i ON e.Id = i.IdEvento ORDER BY e.Fecha ASC;\r\n");
                datos.ejecutarLectura();

                if (datos.Lector == null || !datos.Lector.HasRows)
                {
                    throw new Exception("No hay filas para leer.");
                }
                
                while (datos.Lector.Read())
                {
                    int eventoId = (int)datos.Lector["Id"];
                    Evento aux = listaEventos.FirstOrDefault(e => e.id == eventoId);

                    if (aux == null)
                    {
                        aux = new Evento
                        {
                            id = (int)datos.Lector["Id"],
                            codigo = (string)datos.Lector["Codigo"],
                            nombre = (string)datos.Lector["Nombre"],
                            descripcion = (string)datos.Lector["Descripcion"],
                            tipoEvento = new TipoEvento
                            {
                                id = (int)datos.Lector["TipoEventoId"], // Asignar el ID
                                descripcion = datos.Lector["Descripcion"] != DBNull.Value ? (string)datos.Lector["Descripcion"] : string.Empty
                            },
                            fecha = (DateTime)datos.Lector["Fecha"],
                            precioEntrada = (decimal)datos.Lector["PrecioEntrada"],
                            entradasDisponibles = (int)datos.Lector["CantidadEntradas"]
                        };

                    listaEventos.Add(aux);
                    }
                    if (datos.Lector["ImagenUrl"] != DBNull.Value)
                    {
                        aux.imagenes.Add(new Imagen { IdEvento = aux.id, Url = (string)datos.Lector["ImagenUrl"] });
                    }
                }
                return listaEventos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar eventos: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        
        public List<Evento> filtrarportipo(int idTipoEvento)
        {
            List<Evento> listaEventos = listarEventos(); // Obtenemos todos los eventos
            List<Evento> listaFiltrada = listaEventos.Where(e => e.tipoEvento.id == idTipoEvento).ToList();
            return listaFiltrada;
        }

        public List<Evento> carrito(List<int> lista)
        {
            List<Evento> listaEventos = listarEventos();
            List<Evento> carrito = new List<Evento>();
            bool b;
            foreach (Evento evt in listaEventos)
            {
                b = false;
                foreach (int id in lista)
                {
                    if (evt.id == id)
                    {
                        foreach (Evento fav in carrito)
                        {
                            if (fav.id == id)
                            {
                                b = true;
                            }
                        }
                        if(b == false)
                            carrito.Add(evt);
                    }
                }
                
            }
            return carrito;
        }

    }
}

