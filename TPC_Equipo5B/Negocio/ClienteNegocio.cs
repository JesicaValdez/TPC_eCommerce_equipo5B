using Dominio;
using System;
using System.Collections.Generic;
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
                datos.setearConsulta("Select IdCliente, Dni, Nombre, Apellido, fechaNacimiento, Telefono, EmailPropio FROM Clientes");
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
                    aux.EmailPropio = (string)datos.Lector["EmailPropio"];

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

        public void agregarCliente(Cliente nuevo)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("INSERT INTO Clientes (DNI, Nombre, Apellido, fechaNacimiento, Telefono, EmailPropio) VALUES (@DNI, @Nombre, @Apellido, @fechaNacimiento, @Telefono, @EmailPropio)");

                datos.setearParametro("@DNI", nuevo.Dni);
                datos.setearParametro("Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@fechaNacimiento", nuevo.fechaNacimiento);
                datos.setearParametro("@Telefono", nuevo.Telefono);
                datos.setearParametro("@EmailPropio", nuevo.EmailPropio);

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

        public void modificarCliente(Cliente cliente)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("UPDATE Clientes SET Dni = @Dni, Nombre = @Nombre, Apellido = @Apellido, fechaNacimiento = @fechaNacimiento, Telefono = @Telefono, EmailPropio = @EmailPropio");

                datos.setearParametro("@Dni", cliente.Dni);
                datos.setearParametro("@Nombre", cliente.Nombre);
                datos.setearParametro("@Apellido", cliente.Apellido);
                datos.setearParametro("@fechaNacimiento", cliente.fechaNacimiento);                
                datos.setearParametro("@Telefono", cliente.Telefono);
                datos.setearParametro("@EmailPropio", cliente.EmailPropio);

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

        public void eliminarCliente(int id)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("DELETE FROM Clientes WHERE IdCliente = @id");
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
    }
}
