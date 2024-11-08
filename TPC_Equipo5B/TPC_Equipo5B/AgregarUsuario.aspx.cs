using Negocio;
using Dominio;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo5B
{
    public partial class AgregarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtNombreUsuario.Value;  
            string email = txtEmail.Value;  
            string pass = txtPass.Value;  
            string tipoUsuario = ddlTipoUsuario.Value;

            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
            {
                MostrarMensaje("Por favor, complete todos los campos.", false);
                return;
            }

            try
            {
                Dominio.Usuario nuevoUsuario = new Dominio.Usuario
                {
                    NombreUsuario = nombreUsuario,
                    Email = email,
                    Pass = pass,
                    TipoUsuario = tipoUsuario == "Admin" ? TipoUsuario.ADMIN : TipoUsuario.CLIENTE
                };

                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                usuarioNegocio.agregarUsuario(nuevoUsuario);

                MostrarMensaje("Usuario agregado correctamente.", true);
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al agregar usuario: " + ex.Message, false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

        private void MostrarMensaje(string mensaje, bool exito)
        {
            panelMessage.Visible = true;
            panelMessage.Controls.Clear();
            panelMessage.CssClass = exito ? "alert-success" : "alert-danger";
            panelMessage.Controls.Add(new LiteralControl(mensaje));
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
