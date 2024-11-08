using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC_Equipo5B
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Inicializamos la vista activa en Listado de Usuarios
                MultiViewAdmin.ActiveViewIndex = 0;
                
                    CargarUsuarios();
                    MostrarMensaje("Usuarios cargados correctamente.", true);
            }

        }

        // usuario
        protected void CargarUsuarios()
        {
            try
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                dgvUsuarios.DataSource = usuarioNegocio.listar();
                dgvUsuarios.DataBind();
                MostrarMensaje("Usuarios cargados correctamente.", true);
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar usuarios: " + ex.Message, false);
            }
        }

        public void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarUsuario.aspx");
        }

        public void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedDataKey != null)
            {
                int idUsuario = (int)dgvUsuarios.SelectedDataKey.Value;
                Response.Redirect($"ModificarUsuario.aspx?id={idUsuario}");
            }
            else
            {
                MostrarMensaje("Seleccione un usuario para modificar.", false);
            }

        }

        protected void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedDataKey != null)
            {
                int idUsuario = (int)dgvUsuarios.SelectedDataKey.Value;
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                usuarioNegocio.eliminarUser(idUsuario);
                CargarUsuarios(); // Refresca la lista después de eliminar
                MostrarMensaje("Usuario eliminado correctamente.", true);
            }
            else
            {
                MostrarMensaje("Seleccione un usuario para eliminar.", false);
            }
        }

        protected void dgvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idUsuario = (int)dgvUsuarios.SelectedDataKey.Value;
            Response.Redirect($"ModificarUsuario.aspx?id={idUsuario}");
        }

        protected void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            string criterio = txtBuscarUsuario.Text;
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            List<Dominio.Usuario> usuarios = usuarioNegocio.buscarUsuario(criterio);


            dgvUsuarios.DataSource = usuarios;
            dgvUsuarios.DataBind();
        }


        protected void VerListadoUsuarios(object sender, EventArgs e)
        {
            MultiViewAdmin.ActiveViewIndex = 0;
        }

        protected void MostrarGestionEventos(object sender, EventArgs e)
        {
            MultiViewAdmin.ActiveViewIndex = 1;
        }

        protected void MostrarReportes(object sender, EventArgs e)
        {
            MultiViewAdmin.ActiveViewIndex = 2;
        }

        // Botón de gestión de eventos
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int actionSelected = int.Parse(DropDownList2.SelectedValue);

            switch (actionSelected)
            {
                case 1: 
                    Response.Redirect("CrearEvento.aspx");
                    break;

                case 2: 
                    Response.Redirect("ModificarEvento.aspx");
                    break;

                case 3: 
                    Response.Redirect("EliminarEvento.aspx");
                    break;

                default:
                    MostrarMensaje("Acción no válida.", false);
                    break;
            }
        }


        // Método para generar reportes
        protected void GenerarReporte(object sender, EventArgs e)
        {
            int reporteSeleccionado = int.Parse(ddlReportes.SelectedValue);

            switch (reporteSeleccionado)
            {
                case 1:
                    panelReporte.Controls.Add(new LiteralControl("<p>Reporte de Usuarios generado.</p>"));
                    break;
                case 2:
                    panelReporte.Controls.Add(new LiteralControl("<p>Reporte de Eventos generado.</p>"));
                    break;
            }
        }

        // Método para cerrar sesión
        protected void CerrarSesion(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        private void MostrarMensaje(string mensaje, bool exito)
        {
            panelMessage.Visible = true;
            panelMessage.CssClass = exito ? "alert-success" : "alert-danger";
            panelMessage.Controls.Add(new LiteralControl(mensaje));
        }
    }
}