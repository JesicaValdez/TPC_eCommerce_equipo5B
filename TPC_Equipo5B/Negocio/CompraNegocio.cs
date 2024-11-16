using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CompraNegocio
    {

        private AccesoDB datos = new AccesoDB();


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
    }
}
