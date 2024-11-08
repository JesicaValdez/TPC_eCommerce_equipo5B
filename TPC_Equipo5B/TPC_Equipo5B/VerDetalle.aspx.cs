using Negocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace TPC_Equipo5B
{
    public partial class VerDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                EventoNegocio eventoNegocio = new EventoNegocio();
                List<Evento> evento = new List<Evento>();
                evento.Add(eventoNegocio.buscarEvento((int)Session["id"]));
                detalle.DataSource = evento;
                detalle.DataBind();

                

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            LinkButton btn1 = (LinkButton)sender;
            int eventId = Int32.Parse(btn1.CommandArgument);
            List<int> carritoid = new List<int>();
            List<string> carritotipo = new List<string>();
            if ((List<int>)Session["carritoid"] == null)
            {
                carritoid.Add(eventId);
                //carritotipo.Add(ddlEntradas.SelectedItem.Text);
                Session["carritoid"] = carritoid;
                //Session["carritotipo"] = carritotipo;
            }
            else
            {
                carritoid = (List<int>)Session["carritoid"];
                //carritotipo = (List<string>)Session["carritotipo"];
                carritoid.Add(eventId);
                //carritotipo.Add(ddlEntradas.SelectedItem.Text);
                Session["carritoid"] = carritoid;
                //Session["carritotipo"] = carritotipo;
            }
        }
    }
}