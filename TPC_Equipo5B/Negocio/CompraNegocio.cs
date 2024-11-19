using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CompraNegocio
    {

        private AccesoDB datos = new AccesoDB();


        public List<Compra> listarCompras()
        {
            EventoNegocio eventoNegocio = new EventoNegocio();
            List<Evento> listaEventos = eventoNegocio.listarEventos();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            List<Cliente> listaClientes = clienteNegocio.listar();

            AccesoDB datos = new AccesoDB();
            List<Compra> lista = new List<Compra>();

            try
            {
                datos.setearConsulta("select IdCompra, IdCliente, IdEvento, TipoEntrada, CantidadEntradas, FechaCompra, MontoTotal, Estado from Compra");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Compra aux = new Compra();
                    foreach (Evento evt in listaEventos)
                    {
                        if (evt.id == (int)datos.Lector["IdEvento"])
                        {
                            aux.evento = evt;
                        }
                    }
                    foreach (Cliente clt in listaClientes)
                    {
                        if (clt.IdCliente == (int)datos.Lector["IdCliente"])
                        {
                            aux.cliente = clt;
                        }
                    }
                    aux.idCompra = (int)datos.Lector["IdCompra"];
                    aux.tipoEntrada = (string)datos.Lector["TipoEntrada"];
                    aux.cantidadEntradas = (int)datos.Lector["CantidadEntradas"];
                    aux.montoTotal = (decimal)datos.Lector["MontoTotal"];
                    aux.fechaCompra = (DateTime)datos.Lector["FechaCompra"];
                    aux.estado = (bool)datos.Lector["Estado"];
                    if(aux.estado)
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


        public int cargarCompra(int idevento, int idcliente, string tipoentrada, int cantidad, decimal total)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("INSERT INTO Compra(IdCliente, IdEvento, TipoEntrada, FechaCompra, CantidadEntradas, MontoTotal, estado) OUTPUT inserted.IdCompra VALUES (@idCliente, @idEvento, @tipoentrada, GETDATE(), @cantidad, @total, 1)");
                datos.setearParametro("@idCliente", idcliente);
                datos.setearParametro("@idEvento", idevento);
                datos.setearParametro("@tipoentrada", tipoentrada);
                datos.setearParametro("@cantidad", cantidad);
                datos.setearParametro("@total", total);

                return datos.ejecutarScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar la compra: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void bajaCompra(int idcompra)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("update Compra set Estado = 0 where IdCompra = @id");
                datos.setearParametro("@id", idcompra);
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

        public void modificarCompra(Compra compra)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("update Compra set IdCliente = @idcliente, IdEvento = @idevento, TipoEntrada = @tipoentrada, CantidadEntradas = @cantidad, FechaCompra = @fecha, MontoTotal = @monto, Estado = @estado where IdCompra = @idcompra");

                datos.setearParametro("@idcliente", compra.cliente.IdCliente);
                datos.setearParametro("@idevento", compra.evento.id);
                datos.setearParametro("@tipoentrada", compra.tipoEntrada);
                datos.setearParametro("@cantidad", compra.cantidadEntradas);
                datos.setearParametro("@fecha", compra.fechaCompra);
                datos.setearParametro("@monto", compra.montoTotal);
                datos.setearParametro("@estado", compra.estado);
                datos.setearParametro("@idcompra", compra.idCompra);

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
