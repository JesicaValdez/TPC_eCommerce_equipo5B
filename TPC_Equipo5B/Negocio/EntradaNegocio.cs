using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EntradaNegocio
    {
        private List<Entrada> listaEntradas = new List<Entrada>();

        AccesoDB datos = new AccesoDB();

        public EntradaNegocio()
        {
            datos = new AccesoDB();
        }

        public List<Entrada> entradasporCliente(int idcliente)
        {
            EventoNegocio eventoNegocio = new EventoNegocio();
            List<Evento> listaEventos = eventoNegocio.listarEventos();
            PrecioNegocio precioNegocio = new PrecioNegocio();
            List<Precio> listaPrecios = precioNegocio.listarPrecios();

            AccesoDB datos = new AccesoDB();
            List<Entrada> lista = new List<Entrada>();

            try
            {
                datos.setearConsulta("select e.IdEntrada, e.IdEvento, e.TipoEntrada, e.Precio from Entrada e inner join Compra c on e.IdCompra = c.IdCompra where c.IdCliente = @idcliente");
                datos.setearParametro("@idcliente", idcliente);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Entrada aux = new Entrada();
                    foreach (Evento evt in listaEventos)
                    {
                        if (evt.id == (int)datos.Lector["IdEvento"])
                        {
                            aux.evento = evt;
                        }
                    }
                    aux.IdEntrada = (int)datos.Lector["IdEntrada"];
                    aux.precio.tipoEntrada = (string)datos.Lector["TipoEntrada"];
                    aux.precio.precio = (decimal)datos.Lector["Precio"];

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

        public int cargarEntrada(int idevento, string tipoentrada, decimal precio, int idcompra)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("INSERT INTO Entrada(IdEvento, TipoEntrada, Precio, IdCompra, Estado) OUTPUT inserted.IdEntrada VALUES (@idEvento, @tipoEntrada, @precio, @idcompra, 1)");
                datos.setearParametro("@idEvento", idevento);
                datos.setearParametro("@tipoEntrada", tipoentrada);
                datos.setearParametro("@precio", precio);
                datos.setearParametro("@idcompra", idcompra);
                return datos.ejecutarScalar();
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
