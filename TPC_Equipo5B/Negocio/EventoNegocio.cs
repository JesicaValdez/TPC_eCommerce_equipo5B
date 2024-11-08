using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Dominio;
using System.Collections;
using System.Data.SqlClient;

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
                datos.setearConsulta("SELECT e.Id, e.Codigo, e.Nombre, e.Descripcion, te.Id AS TipoEventoId, te.Descripcion, e.Fecha, e.CantidadEntradas, i.ImagenUrl FROM Eventos e INNER JOIN TiposEvento te ON e.IdTipoEvento = te.Id LEFT JOIN Imagenes i ON e.Id = i.IdEvento ORDER BY e.Fecha ASC;\r\n");
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
                            //precioEntrada = (decimal)datos.Lector["PrecioEntrada"],
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

        public Evento buscarEvento(int id)
        {
            try
            {
                Evento evento = new Evento();
                List<Evento> listaEventos = listarEventos();
                foreach (Evento evt in listaEventos)
                {
                    if (evt.id == id)
                    {
                        evento = evt;
                    }
                }
                return evento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        public void agregar(Evento evento)
        {
            try
            {
                datos.setearConsulta("INSERT INTO Eventos (Codigo, Nombre, Descripcion, IdTipoEvento, Fecha, CantidadEntradas) VALUES (@Codigo, @Nombre, @Descripcion, @IdTipoEvento, @Fecha, @PrecioEntrada, @CantidadEntradas)");
                datos.setearParametro("@Codigo", evento.codigo);
                datos.setearParametro("@Nombre", evento.nombre);
                datos.setearParametro("@Descripcion", evento.descripcion);
                datos.setearParametro("@IdTipoEvento", evento.tipoEvento.id);
                datos.setearParametro("@Fecha", evento.fecha);
            
                datos.setearParametro("@CantidadEntradas", evento.entradasDisponibles);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar evento: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminarEvento(int id)
        {
            AccesoDB dato = new AccesoDB();

            try
            {
                dato.setearConsulta("DELETE FROM Eventos WHERE Id = @id");
                dato.setearParametro("@id", id);
                dato.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dato.cerrarConexion();
            }
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

        public decimal buscarPrecio(int idevento, int idtipo)
        {
            decimal precio = 0;
            try
            {
                datos.setearConsulta("SELECT Precio FROM PreciosEntradas where IdEvento = @idevt and IdTipoEntrada = @idtipo");
                datos.setearParametro("@idevt", idevento);
                datos.setearParametro("@idtipo", idtipo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    precio = (decimal)datos.Lector["Precio"];
                }
                return precio;
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

        public List<Evento> listarFavoritos(int idusuario)
        {
            try
            {
                List<Evento> listaEventos = listarEventos();
                List<Evento> favoritos = new List<Evento>();
                datos.setearConsulta("SELECT IdEvento from Favoritos where IdUsuario = @idusu");
                datos.setearParametro("@idusu", idusuario);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Evento aux = buscarEvento((int)datos.Lector["IdEvento"]);
                    favoritos.Add(aux);
                }
                return favoritos;
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

        public void agregarFavorito(int idusuario, int idevento)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("INSERT INTO Favoritos (IdUsuario, IdEvento) VALUES (@idusu, @idevt)");

                datos.setearParametro("@idusu", idusuario);
                datos.setearParametro("@idevt", idevento);
                datos.ejecutarAccion();
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

        public void eliminarFavorito(int idusuario, int idevento)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("DELETE FROM Favoritos WHERE IdUsuario = @idusu and IdEvento = @idevt");
                datos.setearParametro("@idusu", idusuario);
                datos.setearParametro("@idevt", idevento);
                datos.ejecutarAccion();
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
    }
}

