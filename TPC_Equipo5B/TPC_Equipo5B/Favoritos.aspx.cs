using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo5B
{
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            EventoNegocio eventoNegocio = new EventoNegocio();
            List<int> favs = eventoNegocio.listarIdFavoritos((int)Session["IdUsuario"]);
            List<Evento> favoritos = eventoNegocio.listarFavoritos(favs);
            rptArticulos.DataSource = favoritos;
            rptArticulos.DataBind();
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            LinkButton btn2 = (LinkButton)sender;
            Session.Add("id", Int32.Parse(btn2.CommandArgument));
            Response.Redirect("VerDetalle.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LinkButton btn1 = (LinkButton)sender;
            EventoNegocio eventoNegocio = new EventoNegocio();
            eventoNegocio.eliminarFavorito((int)Session["IdUsuario"], Int32.Parse(btn1.CommandArgument));
            Response.Redirect("Favoritos.aspx");
        }
    }
}