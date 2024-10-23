using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo5B
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void MostrarMisTikets(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0; // Mostrar vista de Mis Tikets
        }

        protected void MostrarEditarCuenta(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1; // Mostrar vista de Editar Cuenta
        }

        protected void MostrarCambiarContrasena(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2; // Mostrar vista de Cambiar Contraseña
        }

        protected void Desconectarse(object sender, EventArgs e)
        {
            
        }
    }
}