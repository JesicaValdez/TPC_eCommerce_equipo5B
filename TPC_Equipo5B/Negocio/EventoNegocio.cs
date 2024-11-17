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
            List<Evento> listaEventos = new List<Evento>();

            //prueba
            ImagenNegocio imagenNegocio = new ImagenNegocio();

            try
            {
                datos.setearConsulta("SELECT e.Id, e.Codigo, e.Nombre, e.Descripcion, e.Lugar, e.Direccion, te.Id AS TipoEventoId, te.Descripcion, e.Fecha, e.CantidadEntradas, i.ImagenUrl \r\nFROM Eventos e \r\nINNER JOIN TiposEvento te ON e.IdTipoEvento = te.Id \r\nLEFT JOIN Imagenes i ON e.Id = i.IdEvento \r\nORDER BY e.Fecha ASC");
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
                            lugar = (string)datos.Lector["Lugar"],
                            direccion = (string)datos.Lector["Direccion"],
                            tipoEvento = new TipoEvento
                            {
                                id = (int)datos.Lector["TipoEventoId"], // Asignar el ID
                                descripcion = datos.Lector["Descripcion"] != DBNull.Value ? (string)datos.Lector["Descripcion"] : string.Empty
                            },
                            fecha = (DateTime)datos.Lector["Fecha"],
                            //precioEntrada = (decimal)datos.Lector["PrecioEntrada"],
                            entradasDisponibles = (int)datos.Lector["CantidadEntradas"],
                            imagenes = new List<Imagen>()

                        };

                        listaEventos.Add(aux);
                    }
                    if (datos.Lector["ImagenUrl"] != DBNull.Value)
                    {
                        if (aux.imagenes == null)
                        {
                            aux.imagenes = new List<Imagen>();
                        }
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

        public Evento EventoBuscar(int id)
        {
            try
            {
                datos.setearConsulta("SELECT e.Id, e.Codigo, e.Nombre, e.Descripcion, e.Lugar, e.Direccion, te.Id AS TipoEventoId, te.Descripcion, e.Fecha, e.CantidadEntradas, i.ImagenUrl " +
                                     "FROM Eventos e " +
                                     "INNER JOIN TiposEvento te ON e.IdTipoEvento = te.Id " +
                                     "LEFT JOIN Imagenes i ON e.Id = i.IdEvento " +
                                     "WHERE e.Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Evento evento = new Evento
                    {
                        id = (int)datos.Lector["Id"],
                        codigo = (string)datos.Lector["Codigo"],
                        nombre = (string)datos.Lector["Nombre"],
                        descripcion = (string)datos.Lector["Descripcion"],
                        lugar = (string)datos.Lector["Lugar"],
                        direccion = (string)datos.Lector["Direccion"],
                        tipoEvento = new TipoEvento
                        {
                            id = (int)datos.Lector["TipoEventoId"],
                            descripcion = datos.Lector["Descripcion"] != DBNull.Value ? (string)datos.Lector["Descripcion"] : string.Empty
                        },
                        fecha = (DateTime)datos.Lector["Fecha"],
                        entradasDisponibles = (int)datos.Lector["CantidadEntradas"],
                        imagenes = new List<Imagen>()
                    };
                    
                    if (datos.Lector["ImagenUrl"] != DBNull.Value)
                    {
                        evento.imagenes.Add(new Imagen { IdEvento = evento.id, Url = (string)datos.Lector["ImagenUrl"] });
                    }

                    return evento;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar evento: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



        //ABM Eventos
        public void agregar(Evento evento)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                // Inserta el evento en la tabla Eventos
                datos.setearConsulta("INSERT INTO Eventos (Codigo, Nombre, Descripcion, Lugar, Direccion, IdTipoEvento, CantidadEntradas, Fecha) " +
                                     "VALUES (@Codigo, @Nombre, @Descripcion, @Lugar, @Direccion, @IdTipoEvento, @CantidadEntradas, @Fecha); " +
                                     "SELECT SCOPE_IDENTITY();");

                datos.setearParametro("@Codigo", evento.codigo);
                datos.setearParametro("@Nombre", evento.nombre);
                datos.setearParametro("@Descripcion", evento.descripcion);
                datos.setearParametro("@Lugar", evento.lugar);
                datos.setearParametro("@Direccion", evento.direccion);
                datos.setearParametro("@IdTipoEvento", evento.tipoEvento.id);
                datos.setearParametro("@CantidadEntradas", evento.entradasDisponibles);
                datos.setearParametro("@Fecha", evento.fecha);

                // Ejecutar el primer INSERT y obtener el ID del evento generado
                int idEvento = datos.ejecutarScalar(); // Esta función debe devolver el ID generado

                // Ahora inserta la imagen en la tabla Imagenes usando el ID del evento
                datos.setearConsulta("INSERT INTO Imagenes (IdEvento, ImagenUrl) VALUES (@IdEvento, @ImagenUrl)");
                datos.setearParametro("@IdEvento", idEvento);
                datos.setearParametro("@ImagenUrl", evento.imagenUrl);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el evento: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void ModificarEvento(Evento evento, int id)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("UPDATE Eventos SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, Fecha = @Fecha, IdTipoEvento = @IdTipoEvento, Lugar = @Lugar, Direccion = @Direccion, CantidadEntradas = @CantidadEntradas WHERE Id = @Id");
                datos.setearParametro("@Codigo", evento.codigo);
                datos.setearParametro("@Nombre", evento.nombre);
                datos.setearParametro("@Descripcion", evento.descripcion);
                datos.setearParametro("@Fecha", evento.fecha);
                datos.setearParametro("@IdTipoEvento", evento.tipoEvento.id);
                datos.setearParametro("@Lugar", evento.lugar);
                datos.setearParametro("@Direccion", evento.direccion);
                datos.setearParametro("@CantidadEntradas", evento.entradasDisponibles);
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar evento: " + ex.Message);
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

        public bool CodigoEventoExistente(string codigo)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Eventos WHERE Codigo = @codigo");
                datos.setearParametro("@codigo", codigo);
                datos.ejecutarLectura();

                if (datos.Lector.Read() && (int)datos.Lector[0] >0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar el código de evento: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<Entrada> carrito(List<List<int>> lista)
        {
            PrecioNegocio precioNegocio = new PrecioNegocio();

            List<Evento> listaEventos = listarEventos();
            List<Entrada> carrito = new List<Entrada>();

            bool b;
            foreach (List<int> l in lista)
            {
                b = false;
                foreach (Evento evt in listaEventos)
                {
                    if (evt.id == l[0])
                    {
                        Entrada entrada = new Entrada();
                        entrada.evento = evt;
                        entrada.precio = precioNegocio.buscarPrecio(l[2]);
                        carrito.Add(entrada);
                    }
                }

            }
            return carrito;
        }
        /*
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
        }*/

        public List<int> listarIdFavoritos(int idusuario)
        {
            try
            {
                List<int> idFav = new List<int>();
                List<Evento> favoritos = new List<Evento>();
                datos.setearConsulta("SELECT IdEvento from Favoritos where IdUsuario = @id");
                datos.setearParametro("@id", idusuario);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    idFav.Add((int)datos.Lector["IdEvento"]);
                }

                return idFav;
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

        public List<Evento> listarFavoritos(List<int> lista)
        {
            List<Evento> eventos = new List<Evento>();
            foreach (int id in lista)
            {
                Evento aux = buscarEvento(id);
                eventos.Add(aux);
            }
            return eventos;
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

