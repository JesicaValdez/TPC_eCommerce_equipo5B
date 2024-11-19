using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using static System.Collections.Specialized.BitVector32;
using System.Linq.Expressions;
using System.Diagnostics;

namespace TPC_Equipo5B
{
    public partial class CrearEvento : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmaEliminacion = false;

            try
            {
                if (!IsPostBack)
                {

                    //cargamos los desplegables 
                    TipoEventoNegocio tipoEventoNegocio = new TipoEventoNegocio();
                    ddlTipoEvento.DataSource = tipoEventoNegocio.listarTipos();
                    List<TipoEvento> lista = tipoEventoNegocio.listarTipos();
                    ddlTipoEvento.DataValueField = "id";
                    ddlTipoEvento.DataTextField = "descripcion";
                    ddlTipoEvento.DataBind();

                }

                //configuración si estamos modificando un evento
                if (!IsPostBack && Request.QueryString["id"] != null)
                {
                    EventoNegocio eventoNegocio = new EventoNegocio();
                    ImagenNegocio imagenNegocio = new ImagenNegocio();
                    int idEvento = int.Parse(Request.QueryString["id"]);
                    Evento seleccionado = eventoNegocio.EventoBuscar(idEvento);

                    if (seleccionado != null)
                    {
                        //precarga de los campos originales
                        txtCodigoEvento.Text = seleccionado.codigo;
                        txtNombreEvento.Text = seleccionado.nombre;
                        txtDescripcionEvento.Text = seleccionado.descripcion;
                        txtLugarEvento.Text = seleccionado.lugar;
                        txtDireccionEvento.Text = seleccionado.direccion;
                        txtCantEntradas.Text = seleccionado.entradasDisponibles.ToString();
                        txtFechaEvento.Text = seleccionado.fecha.ToString("yyyy-MM-dd");

                        //precargo desplegable de tipos de evento   
                        ddlTipoEvento.SelectedValue = seleccionado.tipoEvento.id.ToString();

                        //precargo imagen del evento
                        string imagenUrl = imagenNegocio.precargarImagen(idEvento);
                        if (!string.IsNullOrEmpty(imagenUrl))
                        {
                            txtImagenEvento.Text = imagenUrl;
                            imgEvento.ImageUrl = imagenUrl;
                        }

                        //cambio el texto del botón
                        btnCrearEvento.Text = "Modificar Evento";
                    }
                    else
                    {
                        lblResultado.Text = "Evento no encontrado.";
                        lblResultado.CssClass = "alert-danger";
                    }
                }

            }
            catch (Exception ex)
            {
                lblResultado.Text = "Error al cargar la página " + ex.Message;
                lblResultado.CssClass = "alert-danger";
                throw;
            }
        }

        private void limpiarCampos()
        {
            txtCodigoEvento.Text = "";
            txtNombreEvento.Text = "";
            txtDescripcionEvento.Text = "";
            txtLugarEvento.Text = "";
            txtDireccionEvento.Text = "";
            ddlTipoEvento.SelectedIndex = 0;
            txtCantEntradas.Text = "";
            txtImagenEvento.Text = "";
            txtFechaEvento.Text = "";
            //txtPrecioEvento.Text = "";
        }

        protected void txtImagenEvento_TextChanged(object sender, EventArgs e)
        {
            imgEvento.ImageUrl = txtImagenEvento.Text;
        }

        protected void btnCrearEvento_Click(object sender, EventArgs e)
        {
            try
            {
                ImagenNegocio imagenNegocio = new ImagenNegocio();
                EventoNegocio eventoNegocio = new EventoNegocio();
                string codigoEvento = txtCodigoEvento.Text;

                // Validar que el código del evento no exista
                if (Request.QueryString["id"] == null && eventoNegocio.CodigoEventoExistente(codigoEvento))
                {
                    lblResultado.Text = "El código de evento ya existe. Por favor, elige otro código.";
                    lblResultado.CssClass = "alert-danger";
                    return;
                }


                //si estamos modificando un evento
                if (Request.QueryString["id"] != null)
                {

                    Evento evento = new Evento();
                    {
                        evento.codigo = codigoEvento;
                        evento.nombre = txtNombreEvento.Text;
                        evento.descripcion = txtDescripcionEvento.Text;
                        evento.lugar = txtLugarEvento.Text;
                        evento.direccion = txtDireccionEvento.Text;
                        evento.tipoEvento = new TipoEvento();
                        evento.tipoEvento.id = int.Parse(ddlTipoEvento.SelectedValue);
                        evento.entradasDisponibles = txtCantEntradas.Text == "" ? 0 : int.Parse(txtCantEntradas.Text);
                        evento.fecha = DateTime.Parse(txtFechaEvento.Text);
                        evento.imagenUrl = txtImagenEvento.Text;
                    }

                    int idEvento = int.Parse(Request.QueryString["id"]);
                    eventoNegocio.ModificarEvento(evento, idEvento);
                    imagenNegocio.modificarImagen(evento, idEvento);


                    lblResultado.Text = "Evento modificado correctamente.";
                    lblResultado.CssClass = "alert-success";
                    Response.Redirect("Admin.aspx");

                }
                else
                {
                    crearEvento();
                    lblResultado.Text = "Evento creado correctamente.";
                    lblResultado.CssClass = "alert-success";

                }

            }
            catch (Exception ex)
            {
                lblResultado.Text = "Error al crear evento: " + ex.Message;
                lblResultado.CssClass = "alert-danger";
                throw;
            }

        }

        private void crearEvento()
        {
            try
            {
                ImagenNegocio imagenNegocio = new ImagenNegocio();
                Evento evento = new Evento();
                EventoNegocio eventoNegocio = new EventoNegocio();

                evento.codigo = txtCodigoEvento.Text;
                evento.nombre = txtNombreEvento.Text;
                evento.descripcion = txtDescripcionEvento.Text;
                evento.lugar = txtLugarEvento.Text;
                evento.direccion = txtDireccionEvento.Text;
                evento.tipoEvento = new TipoEvento();
                evento.tipoEvento.id = int.Parse(ddlTipoEvento.SelectedValue);
                evento.entradasDisponibles = txtCantEntradas.Text == "" ? 0 : int.Parse(txtCantEntradas.Text);
                evento.fecha = DateTime.Parse(txtFechaEvento.Text);
                evento.imagenUrl = txtImagenEvento.Text;

                eventoNegocio.agregar(evento);
                imagenNegocio.agregarImagen(evento);

               
            }
            catch (Exception ex)
            {
                lblResultado.Text = "Error al crear evento: " + ex.Message;
                lblResultado.CssClass = "alert-danger";
                throw;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;

            if (Request.QueryString["id"] != null)
            {
                EventoNegocio eventoNegocio = new EventoNegocio();
                int idEvento = int.Parse(Request.QueryString["id"].ToString());
                eventoNegocio.eliminarEvento(idEvento);
                lblResultado.Text = "Evento eliminado correctamente.";
                lblResultado.CssClass = "alert-success";
                Response.Redirect("Eventos.aspx", false);
            }

        }  

    }
}