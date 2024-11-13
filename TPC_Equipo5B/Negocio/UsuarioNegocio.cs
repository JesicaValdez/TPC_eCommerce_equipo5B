using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool loguear(Usuario usuario)
        {
            AccesoDB dato = new AccesoDB();

            try
            {
                dato.setearConsulta("SELECT IDUsuario,  Email, TipoUsuario FROM Usuarios Where NombreUsuario = @user and Pass = @pass");
                dato.setearParametro("@user", usuario.NombreUsuario);
                dato.setearParametro("@pass", usuario.Pass);

                dato.ejecutarLectura();

                while (dato.Lector.Read())
                {
                    usuario.IdUsuario = (int)dato.Lector["IDUsuario"];
                    usuario.Email = (string)dato.Lector["Email"];
                    usuario.TipoUsuario = (int)(dato.Lector["TipoUsuario"]) == 1 ? TipoUsuario.ADMIN : TipoUsuario.CLIENTE;
                    return true;
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
        public List<Usuario> listar()
        {
            AccesoDB dato = new AccesoDB();
            List<Usuario> lista = new List<Usuario>();

            try
            {
                dato.setearConsulta("Select IDUsuario, NombreUsuario, Email, Pass, TipoUsuario FROM Usuarios");
                dato.ejecutarLectura();

                while (dato.Lector.Read())
                {
                    Usuario aux = new Usuario();

                    aux.IdUsuario = (int)dato.Lector["IDUsuario"];
                    aux.NombreUsuario = (string)dato.Lector["NombreUsuario"];
                    aux.Email = (string)dato.Lector["Email"];
                    aux.Pass = (string)dato.Lector["Pass"];
                    aux.TipoUsuario = (TipoUsuario)dato.Lector["TipoUsuario"];

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
                dato.cerrarConexion();
            }
        }

        public int agregarUsuario(Usuario nuevoUsuario)
        {

            try
            {
                AccesoDB dato = new AccesoDB();

                {
                    dato.setearProcedimiento("SP_INSERTAR_USER");

                    dato.setearParametro("@NombreUsuario", nuevoUsuario.NombreUsuario);
                    dato.setearParametro("@Email", nuevoUsuario.Email);
                    dato.setearParametro("@Pass", nuevoUsuario.Pass);

                    return dato.ejecutarScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el usuario: " + ex.Message);
            }
        }

        public List<Usuario> buscarUsuario(string criterio)
        {
            AccesoDB dato = new AccesoDB();
            List<Usuario> lista = new List<Usuario>();

            try
            {
                dato.setearConsulta("Select IDUsuario, NombreUsuario, Email, Pass, TipoUsuario FROM Usuarios WHERE NombreUsuario LIKE @criterio OR Email LIKE @criterio");
                dato.setearParametro("@criterio", "%" + criterio + "%");
                dato.ejecutarLectura();

                while (dato.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    {
                        aux.IdUsuario = (int)dato.Lector["IDUsuario"];
                        aux.NombreUsuario = (string)dato.Lector["NombreUsuario"];
                        aux.Email = (string)dato.Lector["Email"];
                        aux.Pass = (string)dato.Lector["Pass"];
                        aux.TipoUsuario = (TipoUsuario)dato.Lector["TipoUsuario"];
                    }
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
                dato.cerrarConexion();
            }
        }

        public void eliminarUser(int id)
        {
            AccesoDB dato = new AccesoDB();

            try
            {
                dato.setearConsulta("DELETE FROM Usuarios WHERE IDUsuario = @id");
                dato.setearParametro("@id", id);
                dato.ejecutarAccion();
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

        public bool UsuarioExistente(string user)
        {
            AccesoDB dato = new AccesoDB();

            try
            {
                dato.setearConsulta("SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @NombreUsuario");
                dato.setearParametro("@NombreUsuario", user);

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

        public void ModificarPass(Usuario usuario, int id) 
        {
            AccesoDB dato = new AccesoDB();

            try
            {
                dato.setearConsulta("UPDATE Usuarios SET Pass = @Pass WHERE IDUsuario = @IDUsuario");
                dato.setearParametro("@Pass", usuario.Pass);
                dato.setearParametro("@IDUsuario", id);

                dato.ejecutarAccion();
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
