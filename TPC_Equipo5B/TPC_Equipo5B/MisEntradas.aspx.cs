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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((List<int>)Session["var"] != null)
            {
                EventoNegocio eventoNegocio = new EventoNegocio();
                List<Evento> carrito = eventoNegocio.carrito((List<int>)Session["var"]);
                rptArticulos.DataSource = carrito;
                rptArticulos.DataBind();
            }
        }

        public int cantidad(object id)
        {
            int cont = 0;
            foreach(int item in (List<int>)Session["var"])
            {
                if (item == (int)id)
                {
                    cont++;
                }
            }
            return cont;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}