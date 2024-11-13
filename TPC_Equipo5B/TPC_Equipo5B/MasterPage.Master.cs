using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TPC_Equipo5B
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ActualizarEstadoBtn();
            }
        }

        private void ActualizarEstadoBtn()
        {
            if (UserAutenticado())
            {
                btnLog.Text = "Logout";
                btnRegistrarse.Visible = false;

                lblnombreU.Text = Session["nombre"].ToString().ToUpper();
                lblnombreU.Visible = true;
            }
            else
            {
                btnLog.Text = "Login";
                btnRegistrarse.Visible = true;

                lblnombreU.Text = "";
                lblnombreU.Visible = false;
            }
        }

        protected void EntrarSalir(object sender, EventArgs e)
        {
            try
            {
                if (UserAutenticado())
                {
                    Session.Abandon();
                    Session.Remove("usuario");

                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        protected void Registro(object sender, EventArgs e)
        {
            Response.Redirect("Registrarse.aspx");
        }

        public bool UserAutenticado()
        {
            return Session["usuario"] != null;
        }
    }
}