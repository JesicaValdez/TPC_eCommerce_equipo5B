using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listar()
        {
            AccesoDB datos = new AccesoDB();
            List<Cliente> lista = new List<Cliente>();

            try
            {
                datos.setearConsulta("Select IdCliente, Dni, Nombre, Apellido, fechaNacimiento, Telefono FROM Clientes");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.Dni = (string)datos.Lector["Dni"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.fechaNacimiento = (DateTime)datos.Lector["fechaNacimiento"];
                    aux.Telefono = (string)datos.Lector["Telefono"];

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

        public void agregarCliente(Cliente nuevo, int idUsuario)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("INSERT INTO Clientes (IDUsuario, DNI, Nombre, Apellido, fechaNacimiento, Telefono) VALUES (@IDUsuario, @DNI, @Nombre, @Apellido, @fechaNacimiento, @Telefono)");
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.setearParametro("@DNI", nuevo.Dni);
                datos.setearParametro("Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@fechaNacimiento", nuevo.fechaNacimiento);
                datos.setearParametro("@Telefono", nuevo.Telefono);
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

        public Cliente obtenerCliente(int user)
        {
            AccesoDB dato = new AccesoDB();
            Cliente cliente = new Cliente();

            try
            {
                dato.setearConsulta("SELECT DNI, Nombre, Apellido, fechaNacimiento, Telefono FROM Clientes WHERE IDUsuario = @IDUsuario");
                dato.setearParametro("@IDUsuario", user);

                dato.ejecutarLectura();

                if (dato.Lector.Read())
                {
                    cliente.Dni = dato.Lector["DNI"].ToString();
                    cliente.Nombre = dato.Lector["Nombre"].ToString();
                    cliente.Apellido = dato.Lector["Apellido"].ToString();
                    cliente.fechaNacimiento = DateTime.Parse(dato.Lector["fechaNacimiento"].ToString());
                    cliente.Telefono = dato.Lector["Telefono"].ToString();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dato.cerrarConexion();
            }

            return cliente;
        }

        public int obtenerIdClientePorUsuario(int idUsuario)
        {
            AccesoDB dato = new AccesoDB();
            int idCliente = 0;

            try
            {
                dato.setearConsulta("SELECT IdCliente FROM Clientes WHERE IdUsuario = @IdUsuario");
                dato.setearParametro("@IdUsuario", idUsuario);
                dato.ejecutarLectura();

                if (dato.Lector.Read())
                {
                    idCliente = (int)dato.Lector["IdCliente"];
                }
                return idCliente;
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

        public void modificarCliente(Cliente cliente, int id)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("UPDATE Clientes SET Dni = @Dni, Nombre = @Nombre, Apellido = @Apellido, fechaNacimiento = @fechaNacimiento, Telefono = @Telefono WHERE IdCliente = @IdCliente");

                datos.setearParametro("@Dni", cliente.Dni);
                datos.setearParametro("@Nombre", cliente.Nombre);
                datos.setearParametro("@Apellido", cliente.Apellido);
                datos.setearParametro("@fechaNacimiento", cliente.fechaNacimiento);
                datos.setearParametro("@Telefono", cliente.Telefono);
                datos.setearParametro("@IdCliente", id);

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

        public void BajaCliente(int id)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("UPDATE Clientes set Estado = 0 WHERE IDUsuario = @id");
                datos.setearParametro("@id", id);
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

        public bool DniExistente(string dni)
        {
            AccesoDB dato = new AccesoDB();

            try
            {
                dato.setearConsulta("SELECT COUNT(*) FROM Clientes WHERE DNI = @DNI");
                dato.setearParametro("@DNI", dni);

                dato.ejecutarLectura();

                if (dato.Lector.Read())
                {
                    int cant = Convert.ToInt32(dato.Lector[0]);
                    return cant > 0;
                }

                return false;
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

        public Cliente buscarCliente(int id)
        {
            AccesoDB dato = new AccesoDB();
            try
            {
                Cliente cliente = new Cliente();
                List<Cliente> listaCliente = listar();
                foreach (Cliente clt in listaCliente)
                {
                    if (clt.IdCliente == id)
                    {
                        cliente = clt;
                    }
                }
                return cliente;

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
    }
}




