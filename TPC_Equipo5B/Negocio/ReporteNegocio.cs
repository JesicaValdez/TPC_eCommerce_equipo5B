using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ReporteNegocio
    {
        //PARA REPORTE CLIENTE
        public List<Compra> ReporteMes(int mes, int anio)
        {
            List<Compra> lista = new List<Compra>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("SELECT C.IdCliente as id, C.Nombre as nombre, C.Apellido as apellido, CMP.FechaCompra as fecha, CMP.MontoTotal as monto FROM Clientes C JOIN Compra CMP ON C.IdCliente = CMP.IdCliente WHERE YEAR(CMP.FechaCompra) = @Anio AND MONTH(CMP.FechaCompra) = @Mes ORDER BY CMP.FechaCompra DESC");
                datos.setearParametro("@Anio", anio);
                datos.setearParametro("@Mes", mes);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente
                    {
                        IdCliente = (int)datos.Lector["id"],
                        Nombre = (string)datos.Lector["nombre"],
                        Apellido = (string)datos.Lector["apellido"]
                    };

                    Compra auxCompra = new Compra
                    {
                        fechaCompra = (DateTime)datos.Lector["fecha"],
                        montoTotal = (decimal)datos.Lector["monto"],
                        cliente = aux // Asocia el cliente a la compra
                    };

                    lista.Add(auxCompra); // Agrega la compra con el cliente asociado a la lista
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }

        public List<Compra> ReporteAnio(int anio)
        {
            List<Compra> lista = new List<Compra>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("SELECT C.IdCliente as id, C.Nombre as nombre, C.Apellido as apellido, CMP.FechaCompra as fecha, CMP.MontoTotal as monto FROM Clientes C JOIN Compra CMP ON C.IdCliente = CMP.IdCliente WHERE YEAR(CMP.FechaCompra) = @Anio ORDER BY CMP.FechaCompra DESC");
                datos.setearParametro("@Anio", anio);
                
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente
                    {
                        IdCliente = (int)datos.Lector["id"],
                        Nombre = (string)datos.Lector["nombre"],
                        Apellido = (string)datos.Lector["apellido"]
                    };

                    Compra auxCompra = new Compra
                    {
                        fechaCompra = (DateTime)datos.Lector["fecha"],
                        montoTotal = (decimal)datos.Lector["monto"],
                        cliente = aux 
                    };

                    lista.Add(auxCompra); 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }

        public List<Compra> CompraCliente(int id)
        {
            List<Compra> lista = new List<Compra>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("SELECT CL.Nombre as nombre, CL.Apellido as apellido, CMP.FechaCompra as fecha, CMP.CantidadEntradas as cantidad, CMP.MontoTotal as monto, E.Nombre as evento, CMP.TipoEntrada as tipo FROM Compra CMP JOIN Eventos E ON CMP.IdEvento = E.Id JOIN Clientes CL ON CMP.IdCliente = CL.IdCliente WHERE CMP.IdCliente = @IdCliente ORDER BY CMP.FechaCompra DESC;");
                datos.setearParametro("@IdCliente", id);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente
                    {                        
                        Nombre = (string)datos.Lector["nombre"],
                        Apellido = (string)datos.Lector["apellido"]
                    };

                    Evento eventoAux = new Evento
                    {
                        nombre = (string)datos.Lector["evento"]
                    };

                    Compra auxCompra = new Compra
                    {
                        fechaCompra = (DateTime)datos.Lector["fecha"],
                        cantidadEntradas = (int)datos.Lector["cantidad"],
                        montoTotal = (decimal)datos.Lector["monto"],
                        tipoEntrada = (string)datos.Lector["tipo"],
                        cliente = aux,
                        evento = eventoAux
                    };

                    lista.Add(auxCompra);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }

        //REPORTE COMPRAS REALIZADAS

        public List<Compra> CompraPorDia(int dia, int mes, int anio)
        {
            List<Compra> lista = new List<Compra>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("SELECT FechaCompra AS fecha, COUNT(IdCompra) AS TotalCompras FROM Compra WHERE YEAR(FechaCompra) =  @Anio AND MONTH(FechaCompra) = @Mes AND DAY(FechaCompra) = @Dia GROUP BY FechaCompra");
                datos.setearParametro("@Dia", dia);
                datos.setearParametro("@Mes", mes);
                datos.setearParametro("@Anio", anio);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {                   

                    Compra auxCompra = new Compra
                    {
                        fechaCompra = (DateTime)datos.Lector["fecha"],
                        cantidadEntradas = (int)datos.Lector["TotalCompras"]                        
                    };

                    lista.Add(auxCompra);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }

        //REPORTE RECAUDACION
        public List<Compra> RecaudacionPorDia(int dia, int mes, int anio)
        {
            List<Compra> lista = new List<Compra>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("SELECT CMP.FechaCompra AS fecha, SUM(CMP.MontoTotal) AS recaudacion FROM Compra CMP WHERE YEAR(CMP.FechaCompra) = @Anio AND MONTH(CMP.FechaCompra) = @Mes AND DAY(CMP.FechaCompra) = @Dia GROUP BY CMP.FechaCompra");
                datos.setearParametro("@Dia", dia);
                datos.setearParametro("@Mes", mes);
                datos.setearParametro("@Anio", anio);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    Compra auxCompra = new Compra
                    {
                        fechaCompra = (DateTime)datos.Lector["fecha"],
                        montoTotal = (decimal)datos.Lector["recaudacion"]
                    };

                    lista.Add(auxCompra);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }

    }
}
