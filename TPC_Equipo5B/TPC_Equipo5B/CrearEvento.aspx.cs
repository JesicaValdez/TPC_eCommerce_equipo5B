using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using static System.Collections.Specialized.BitVector32;

namespace TPC_Equipo5B
{
    public partial class CrearEvento : System.Web.UI.Page
    {
        private List<Sector> Sectores = new List<Sector>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TipoEventoNegocio tipoEventoNegocio = new TipoEventoNegocio();
                ddlTipoEvento.DataSource = tipoEventoNegocio.listarTipos();
                ddlTipoEvento.DataTextField = "descripcion";
                ddlTipoEvento.DataValueField = "id";
                ddlTipoEvento.DataBind();
            }

        }

        protected void btnCrearEvento_Click(object sender, EventArgs e)
        {
            Evento evento = new Evento();

            evento.nombre = txtNombreEvento.Text;
            evento.descripcion = txtDescripcionEvento.Text;
            evento.fecha = DateTime.Parse(txtFechaEvento.Text);
            evento.codigo = txtCodigoEvento.Text;
            evento.imagenes = new List<Imagen>();
            evento.imagenes.Add(new Imagen { Url = txtImagenEvento.Text });
            evento.entradasDisponibles = int.Parse(txtEntradasDisponibles.Text);
            evento.tipoEvento = new TipoEvento { id = int.Parse(ddlTipoEvento.SelectedValue) };


            EventoNegocio eventoNegocio = new EventoNegocio();
            eventoNegocio.agregar(evento);

            Response.Redirect("Admin.aspx");
        
        
        }
    }
}