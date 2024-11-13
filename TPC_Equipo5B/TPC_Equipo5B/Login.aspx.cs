using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPC_Equipo5B
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Ingresar(object sender, EventArgs e)
        {
            Dominio.Usuario usuario;
            UsuarioNegocio negocio = new UsuarioNegocio();

            int nroUser = 0;

            try
            {
                if (validarLogin())
                {
                    if (!negocio.UsuarioExistente(txt_User.Text))
                    {
                        Session.Add("error", "El usuario no existe. Debe REGISTRARSE");
                        Response.Redirect("Error.aspx", false);
                        return;
                    }

                    usuario = new Dominio.Usuario(txt_User.Text, txt_Pass.Text, nroUser);
                    bool logueadoExitosamente = negocio.loguear(usuario);
                    nroUser = (int)usuario.TipoUsuario;

                    if (logueadoExitosamente)
                    {
                        Session.Add("usuario", usuario);
                        Session.Add("IdUsuario", usuario.IdUsuario);
                        Session.Add("nombre", usuario.NombreUsuario);
                        Session.Add("email", usuario.Email);                      

                        switch (nroUser)
                        {
                            case 1:
                            case 2:
                                Response.Redirect("Default.aspx", false);
                                break;
                        }

                    }
                    else
                    {
                        Session.Add("error", "Usuario o password incorrectos");
                        Response.Redirect("Error.aspx", false);
                    }
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        private bool validarLogin()
        {
            bool valido = true;
            try
            {
                if (string.IsNullOrEmpty(txt_User.Text))
                {
                    lbl_errorU.Text = "ingrese dni";
                    lbl_errorU.Visible = true;
                    valido = false;
                }

                if (string.IsNullOrEmpty(txt_Pass.Text))
                {
                    lbl_errorP.Text = "ingrese contraseña";
                    lbl_errorP.Visible = true;
                    valido = false;
                }

                if (valido)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}