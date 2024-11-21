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
using System.Data;
using System.Data.SqlClient;

namespace TPC_Equipo5B
{
    public partial class CrearEvento : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN))
            {
                Session.Add("error", "No tiene nivel admin para acceder a esta pagina.");
                Response.Redirect("Error.aspx", false);
            }


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

                limpiarMensajes();

                // Realiza la validación del formulario
                if (validarFormulario())
                {


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
                    limpiarCampos();
                    Response.Redirect("Admin.aspx");
                }
            }
            catch (Exception ex)
            {
                lblResultado.Text = "Error al crear o modificar evento: " + ex.Message;
                lblResultado.CssClass = "alert-danger";
                lblResultado.Visible = true;
                
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


        private bool validarFormulario()
        {
            bool valido = true;

            // Validar nombre de evento
            if (string.IsNullOrEmpty(txtNombreEvento.Text))
            {
                lblNombreEventoError.Text = "Ingrese el nombre del evento.";
                lblNombreEventoError.Visible = true;
                valido = false;
            }
            

            // Validar descripción de evento
            if (string.IsNullOrEmpty(txtDescripcionEvento.Text)  || !System.Text.RegularExpressions.Regex.IsMatch(txtDescripcionEvento.Text, @"^[a-zA-Z\s]+$"))
            {
                lblDescripcionError.Text = "Ingrese una descripción del evento.";
                lblDescripcionError.Visible = true;
                valido = false;
            }

            // Validar lugar de evento
            if (string.IsNullOrEmpty(txtLugarEvento.Text)  || !System.Text.RegularExpressions.Regex.IsMatch(txtLugarEvento.Text, @"^[a-zA-Z\s]+$"))
            {
                lblLugarError.Text = "Ingrese el lugar del evento.";
                lblLugarError.Visible = true;
                valido = false;
            }

            // Validar fecha del evento
            if (string.IsNullOrEmpty(txtFechaEvento.Text) || !DateTime.TryParse(txtFechaEvento.Text, out _));
            {
                lblFechaEventoError.Text = "Ingrese una fecha válida.";
                lblFechaEventoError.Visible = true;
                return false;
            }

            // Validar cantidad de entradas
            if (string.IsNullOrEmpty(txtCantEntradas.Text) || !int.TryParse(txtCantEntradas.Text, out int cantEntradas) || cantEntradas <= 0)
            {
                lblCantEntradasError.Text = "Ingrese una cantidad válida de entradas.";
                lblCantEntradasError.Visible = true;
                valido = false;
            }

        }


            // Validar imagen de evento
            private bool validarImagen(TextBox txtImagen, Label lblError)
        {
            if (!string.IsNullOrEmpty(txtImagen.Text) && !validarUrl(txtImagen.Text))
            {
                lblError.Text = "Ingrese una URL de imagen válida.";
                lblError.Visible = true;
                return false;
            }


            return true; 
        }

        //validar URL
        private bool validarUrl(string url)
        {
            Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
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
                try
                {
                    EventoNegocio eventoNegocio = new EventoNegocio();
                    int idEvento = int.Parse(Request.QueryString["id"].ToString());
                    eventoNegocio.eliminarEvento(idEvento);
                    lblResultado.Text = "Evento eliminado correctamente.";
                    lblResultado.CssClass = "alert-success";
                    Response.Redirect("Eventos.aspx", false);
                }
                catch(Exception ex)
                {
                    lblResultado.Text = "Error al eliminar el evento: " + ex.Message;
                    lblResultado.CssClass = "alert-danger";
                }
            }

        }  

        private void limpiarMensajes()
        {
            lblNombreEventoError.Visible = false;
            lblDescripcionError.Visible = false;
            lblLugarError.Visible = false;
            lblFechaEventoError.Visible = false;
            lblCantEntradasError.Visible = false;
            lblImagenEventoError.Visible = false;
            lblResultado.Visible = false;
        }

        private void MostrarMensaje(Label label, string mensaje)
        {
            label.Text = mensaje;
            label.Visible = true;
        }

    }
}