using Negocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
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

            try
            {
                Usuario nuevoUsuario = new Usuario
                {
                    NombreUsuario = nombreUsuario,
                    Email = email,
                    Pass = pass,
                    TipoUsuario = tipoUsuario
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
            panelMessage.CssClass = exito ? "alert-success" : "alert-danger";
            panelMessage.Controls.Add(new LiteralControl(mensaje));
        }
    }
}