using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> buscarimagenes(int idEvento)
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("SELECT IdEvento, ImagenUrl FROM IMAGENES WHERE IdEvento = @IdEvento");
                datos.setearParametro("@IdEvento", idEvento);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    Imagen aux = new Imagen();
                    aux.IdEvento = (int)datos.Lector["IdEvento"];
                    aux.Url = (string)datos.Lector["ImagenUrl"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar imágenes: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregarImagen(Evento nuevo)
        {
            AccesoDB datos = new AccesoDB();
            EventoNegocio eventoNegocio = new EventoNegocio();

            try
            {
                Evento evento = eventoNegocio.listarEventos().Last();
                int idEvento = evento.id;

                datos.setearConsulta("insert into IMAGENES (IdEvento, ImagenUrl) \r\n values (@IdEvento, @ImagenUrl)");
                datos.setearParametro("@IdEvento", idEvento);
                datos.setearParametro("@ImagenUrl", nuevo.imagenUrl);
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

        public void modificarImagen(Evento modificado)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("UPDATE INTO IMAGENES(ImagenUrl WHERE @IdEvento = IdEvento)");
                datos.setearParametro("@ImagenUrl", modificado.imagenUrl);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
