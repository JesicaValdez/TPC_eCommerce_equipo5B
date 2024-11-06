using Dominio;
using System;
using System.Collections.Generic;
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
                dato.setearConsulta("Select IDUsuario, NombreUsuario, Email, Password, IDTipoUsuario FROM Usuarios");
                dato.ejecutarLectura();

                while (dato.Lector.Read())
                {
                    Usuario aux = new Usuario ();

                    aux.IdUsuario = (int)dato.Lector["IDUsuario"];
                    aux.NombreUsuario = (string)dato.Lector["NombreUsuario"];
                    aux.Email = (string)dato.Lector["Email"];
                    aux.Pass = (string)dato.Lector["Password"];
                    aux.TipoUsuario = (TipoUsuario)dato.Lector["IDTipoUsuario"];

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
