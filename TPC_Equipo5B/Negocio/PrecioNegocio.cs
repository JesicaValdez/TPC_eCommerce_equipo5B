﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PrecioNegocio
    {
        private List<Precio> listaPrecios = new List<Precio>();

        AccesoDB datos = new AccesoDB();

        public PrecioNegocio()
        {
            datos = new AccesoDB();
        }

        public List<Precio> listarPrecios()
        {
            List<Precio> lista = new List<Precio>();

            try
            {
                datos.setearConsulta("select IDPrecio, IdEvento, TipoEntrada, Precio, Cantidad from PreciosEntradas");
                
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
                    Precio aux = new Precio();
                    aux.idPrecio = (int)datos.Lector["IDPrecio"];
                    aux.idEvento = (int)datos.Lector["IdEvento"];
                    aux.tipoEntrada = (string)datos.Lector["TipoEntrada"];
                    aux.precio = (decimal)datos.Lector["Precio"];
                    aux.cantidadEntradas = (int)datos.Lector["Cantidad"];

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

        public List<Precio> listarporEvento(int id)
        {
            try
            {
                
                List<Precio> listaPrecios = listarPrecios();
                List<Precio> listanueva = new List<Precio>();
                foreach (Precio prc in listaPrecios)
                {
                    if (prc.idEvento == id)
                    {
                        listanueva.Add(prc);
                    }
                }
                return listanueva;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Precio buscarPrecio(int idprecio)
        {
            try
            {
                Precio precio = new Precio();
                List<Precio> listaPrecios = listarPrecios();
                
                foreach (Precio prc in listaPrecios)
                {
                    if (prc.idPrecio == idprecio)
                    {
                        precio = prc;
                    }
                }
                return precio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void descontarEntradas(int idprecio, int cantidad)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("UPDATE PreciosEntradas SET Cantidad = Cantidad - @cantidad WHERE IDPrecio = @idprecio");

                datos.setearParametro("@cantidad", cantidad);
                datos.setearParametro("@idprecio", idprecio);
                

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
