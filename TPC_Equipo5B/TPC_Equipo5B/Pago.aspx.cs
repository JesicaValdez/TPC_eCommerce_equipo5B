using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_Equipo5B
{
    public partial class Pago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                //Response.Redirect("Login.aspx");
            }
            if (Session["subtotal"] != null)
            {
                Label5.Text = Session["subtotal"].ToString();
                Label6.Text = Session["costoservicio"].ToString();
                Label7.Text = Session["total"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}