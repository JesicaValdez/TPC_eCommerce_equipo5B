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
            if ((List<int>)Session["carritoid"] != null)
            {
                EventoNegocio eventoNegocio = new EventoNegocio();
                List<Evento> carrito = eventoNegocio.carrito((List<int>)Session["carritoid"]);
                rptArticulos.DataSource = carrito;
                rptArticulos.DataBind();
            }
            Label1.Text = subtotal().ToString();
        }

        public int cantidad(object id)
        {
            int cont = 0;
            foreach(int item in (List<int>)Session["carritoid"])
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
            LinkButton btn1 = (LinkButton)sender;
            List<int> carrito = new List<int>();
            carrito = (List<int>)Session["carritoid"];
            int id = Int32.Parse(btn1.CommandArgument);
            carrito.Remove(id);
            Session["carritoid"] = carrito;
            Response.Redirect("MisEntradas.aspx");
        }

        
        private decimal subtotal()
        {
            decimal subtotal = 0;
            if ((List<int>)Session["carritoid"] != null)
            {
                EventoNegocio eventoNegocio = new EventoNegocio();
                List<Evento> carrito = eventoNegocio.carrito((List<int>)Session["carritoid"]);
                foreach (Evento evt in carrito)
                {
                    subtotal += precio(evt.id) * cantidad(evt.id);
                }
            }
            return subtotal;
        }

        public decimal precio(object id)
        {
            decimal precio = 0;
            EventoNegocio eventoNegocio = new EventoNegocio();
            precio = eventoNegocio.buscarPrecio((int)id, 1);
            return precio;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            decimal sub = subtotal();
            decimal cds = subtotal() / 10;
            decimal total = sub + cds;
            Session.Add("subtotal", sub);
            Session.Add("costoservicio", cds);
            Session.Add("total", total);
            Response.Redirect("Pago.aspx");
        }
    }
}