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
    public partial class Eventos : System.Web.UI.Page
    {
        public List<Eventos> listaEventos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            EventoNegocio eventoNegocio = new EventoNegocio();
            TipoEventoNegocio tipoEvento = new TipoEventoNegocio();

            try
            {
                if (!IsPostBack)
                {
                    ddlEventos.DataSource = tipoEvento.listarTipos();
                    ddlEventos.DataBind();

                    List<Evento> lista = eventoNegocio.listarEventos();
                    rptArticulos.DataSource = lista;
                    rptArticulos.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EventoNegocio eventoNegocio = new EventoNegocio();
            List<Evento> lista = eventoNegocio.filtrarportipo(ddlEventos.SelectedItem.Text);
            rptArticulos.DataSource = lista;
            rptArticulos.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito.aspx");
        }
    }
}