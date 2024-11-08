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
            List<Usuario> lista = new List<Usuario> ();

            try
            {
                dato.setearConsulta("Select IDUsuario, NombreUsuario, Email, Pass, TipoUsuario FROM Usuarios");
                dato.ejecutarLectura();

                while (dato.Lector.Read())
                {
                    Usuario aux = new Usuario ();

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

        public void agregarUsuario(Usuario nuevoUsuario)
        {

            try
            {
                AccesoDB dato = new AccesoDB();

                {
                    dato.setearConsulta("INSERT INTO Usuarios (NombreUsuario, Email, Pass, TipoUsuario) VALUES (@NombreUsuario, @Email, @Pass, @TipoUsuario");
                    dato.ejecutarLectura();

                    while (dato.Lector.Read())
                    {
                        dato.setearParametro("@NombreUsuario", nuevoUsuario.NombreUsuario);
                        dato.setearParametro("@Email", nuevoUsuario.Email);
                        dato.setearParametro("@Pass", nuevoUsuario.Pass);
                        dato.setearParametro("@TipoUsuario", nuevoUsuario.TipoUsuario);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el usuario: " + ex.Message);
            }
        }

        public void eliminarUser(int id)
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

            AccesoDB dato = new AccesoDB ();

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

    }
}
