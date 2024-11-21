using Dominio;
using Negocio;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo5B
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                limpiarCampos();
                limpiarMensajes();
            }
        }

        protected void btn_ContactarClick(object sender, EventArgs e)
        {
            limpiarMensajes();
            if (validarFormulario())
            {
                Session.Add("exito", "Mensaje enviado con éxito.");
                Response.Redirect("Exito.aspx");
                limpiarCampos();
            }
        }

        private bool validarFormulario()
        {
            bool valido = true;

            //validar nombre
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                lblNombreError.Text = "Ingrese su nombre.";
                lblNombreError.Visible = true;
                valido = false;
            }
            else if (!validarSoloLetras(txtNombre.Text))
            {
                lblNombreError.Text = "El nombre solo debe contener caracteres alfabéticos";
                lblNombreError.Visible = true;
                valido = false;
            }

            //validar apellido
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                lblApellidoError.Text = "Ingrese su apellido.";
                lblApellidoError.Visible = true;
                valido = false;
            }
            else if (!validarSoloLetras(txtApellido.Text))
            {
                lblApellidoError.Text = "El apellido solo debe contener caracteres alfabéticos";
                lblApellidoError.Visible = true;
                valido = false;
            }

            //validar email
            if (!validarEmail(txtEmail.Text))
            {
                lblEmailError.Text = "Ingrese un email valido.";
                lblEmailError.Visible = true;
                valido = false;
            }

            // Validar teléfono
            if (!validarTelefono(txtTelefono.Text))
            {
                lblTelefonoError.Text = "Ingrese un teléfono válido (solo números, entre 7 y 15 dígitos).";
                lblTelefonoError.Visible = true;
                valido = false;
            }

            // Validar evento
            if (string.IsNullOrWhiteSpace(txtNombreEvento.Text))
            {
                lblEventoError.Text = "Ingrese el nombre del evento.";
                lblEventoError.Visible = true;
                valido = false;
            }

            // Validar mensaje
            if (string.IsNullOrWhiteSpace(txtMensaje.Text) || txtMensaje.Text.Length < 10)
            {
                lblMensajeError.Text = "El mensaje debe tener al menos 10 caracteres.";
                lblMensajeError.Visible = true;
                valido = false;
            }

            return valido;
        }

        private bool validarSoloLetras(string texto)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(texto, @"^[a-zA-Z]+$");
        }

        private bool validarEmail(string email)
        {
            try
            {
                var correo = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool validarTelefono(string telefono)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(telefono, @"^\d{7,15}$");
        }

        private void limpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtNombreEvento.Text = "";
            txtMensaje.Text = "";
        }

        private void limpiarMensajes()
        {
            lblNombreError.Visible = false;
            lblApellidoError.Visible = false;
            lblEmailError.Visible = false;
            lblTelefonoError.Visible = false;
            lblEventoError.Visible = false;
            lblMensajeError.Visible = false;

            lblErrorMessage.Visible = false;
            lblSuccessMessage.Visible = false;
        }

        private void MostrarMensaje(Label label, string mensaje)
        {
            label.Text = mensaje;
            label.Visible = true;
        }
    }
}

