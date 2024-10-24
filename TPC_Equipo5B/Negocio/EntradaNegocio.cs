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

        public List<Entrada> listarEntradas(int idCliente)
        {
            List<Entrada> lista = new List<Entrada>();

            try
            {
                datos.setearConsulta("");
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
                    Entrada aux = new Entrada();
                    

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
