using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            if ((List<List<int>>)Session["carritoid"] != null)
            {
                EventoNegocio eventoNegocio = new EventoNegocio();
                List<Entrada> carrito = eventoNegocio.carrito((List<List<int>>)Session["carritoid"]);
                rptArticulos.DataSource = carrito;
                rptArticulos.DataBind();
            }
            Label1.Text = subtotal().ToString();

        }

        public int cantidad(object idevento, object idprecio)
        {
            int cont = 0;
            foreach(List<int> l in (List<List<int>>)Session["carritoid"])
            {
                if (l[0] == (int)idevento && l[2] == (int)idprecio)
                {
                    cont = l[1];
                }
            }
            return cont;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LinkButton btn1 = (LinkButton)sender;
            List<List<int>> carrito = (List<List<int>>)Session["carritoid"];
            foreach (List<int> l in carrito)
            {
                if (l[2] == Int32.Parse(btn1.CommandArgument))
                {
                    if (l[1] == 1)
                    {
                        carrito.Remove(l);
                        break;
                    }
                    else
                    {
                        l[1] -= 1;
                        break;
                    }
                }
            }
            Session["carritoid"] = carrito;
            Response.Redirect("MisEntradas.aspx");
        }

        
        private decimal subtotal()
        {
            decimal subtotal = 0;
            PrecioNegocio precioNegocio = new PrecioNegocio();
            if ((List<List<int>>)Session["carritoid"] != null)
            {
                List<List<int>> carrito = (List<List<int>>)Session["carritoid"];
                foreach (List<int> l in carrito)
                {
                    decimal precio = precioNegocio.buscarPrecio(l[2]).precio;
                    subtotal += l[1]*precio;
                }
            }
            return subtotal;
        }
        /*
        public decimal precio(object id)
        {
            decimal precio = 0;
            PrecioNegocio precioNegocio = new PrecioNegocio();
            foreach (List<int> l in (List<List<int>>)Session["carritoid"])
            {
                if (l[0] == (int)id)
                {
                    cont = l[1];
                }
            }
            return cont;
            precio = precioNegocio.buscarPrecio((int)id);
            return precio;
        }*/

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