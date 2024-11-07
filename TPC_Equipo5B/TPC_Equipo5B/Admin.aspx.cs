using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            }

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

        // Método para ver usuarios dados de alta en el sistema
        protected void ListadoCLientes(object sender, EventArgs e)
        {

            Response.Redirect("VerListado.aspx");
        }

        // Método para agregar un nuevo evento
        protected void AgregarEvento(object sender, EventArgs e)
        {

            Response.Redirect("CrearEvento.aspx");
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
            Session.Abandon();
            Response.Redirect("Login.aspx"); // Redirige a la página de inicio de sesión
        }
    }
}