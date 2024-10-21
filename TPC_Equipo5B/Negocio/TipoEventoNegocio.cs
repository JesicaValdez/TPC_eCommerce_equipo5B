using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class TipoEventoNegocio
    {
        AccesoDB datos = new AccesoDB();
        public List<TipoEvento> listarTipos()
        {
            List<TipoEvento> lista = new List<TipoEvento>();
            try
            {
                datos.setearConsulta("SELECT * FROM TiposEvento");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TipoEvento aux = new TipoEvento();
                    aux.id = (int)datos.Lector["Id"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];

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
    }
}
