using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo5B
{
    public partial class ModificarPrecio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN))
                {
                    Session.Add("error", "No tiene nivel admin para acceder a esta pagina.");
                    Response.Redirect("Error.aspx", false);
                }

                if (!IsPostBack && Request.QueryString["id"] != null && Request.QueryString["modo"] != null)
                {

                    string modo = Request.QueryString["modo"];

                    if (modo == "agregar")
                    {
                        // Lógica para agregar entrada
                        int idEvento = int.Parse(Request.QueryString["id"]); // Captura el id del evento
                        EventoNegocio eventoNegocio = new EventoNegocio();
                        Evento seleccionado = eventoNegocio.EventoBuscar(idEvento);

                        if (seleccionado != null)
                        {
                            txtEventos.Text = seleccionado.nombre; // Mostrar el nombre del evento 
                            txtEventos.ReadOnly = true; // Bloquear el campo del nombre del evento
                            lbl_Disponibilidad.Text = "Capacidad disponible: " + seleccionado.entradasDisponibles.ToString();
                            lbl_Disponibilidad.Visible = true;
                        }
                    }
                    else if (modo == "modificar")
                    {
                        // Lógica para modificar precio
                        int idPrecio = int.Parse(Request.QueryString["id"]); // Captura el id del precio
                        PrecioNegocio precioNegocio = new PrecioNegocio();
                        Precio precio = precioNegocio.obtenerPrecio(idPrecio);

                        if (precio != null)
                        {
                            txtEventos.Text = precio.idEvento.ToString();
                            txtEventos.ReadOnly = true; // Bloquear el campo del nombre del evento
                            txtNombreEntrada.Text = precio.tipoEntrada;
                            txtPrecio.Text = precio.precio.ToString();
                            txtCantidad.Text = precio.cantidadEntradas.ToString();

                            BtnPrecio.Text = "Modificar Precio";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblResultado.Text = "Ocurrió un error: " + ex.Message;
                lblResultado.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(!validarForm())
                {
                    return;
                }

                PrecioNegocio precioNegocio = new PrecioNegocio();
                EventoNegocio eventoNegocio = new EventoNegocio();

                if (Request.QueryString["id"] != null && Request.QueryString["modo"] != null)
                {
                    string modo = Request.QueryString["modo"];

                    if (modo == "modificar")
                    {
                        // Lógica para modificar
                        int idPrecio = int.Parse(Request.QueryString["id"]);
                        int evento = int.Parse(txtEventos.Text);
                        Precio precioMod = new Precio
                        {
                            idEvento = evento,
                            tipoEntrada = txtNombreEntrada.Text,
                            cantidadEntradas = int.Parse(txtCantidad.Text),
                            precio = decimal.Parse(txtPrecio.Text)
                        };

                        Evento capacidadMod = new Evento
                        {
                            entradasDisponibles = int.Parse(txtCantidad.Text)
                        };

                        precioNegocio.modificarPrecio(precioMod, idPrecio);
                        eventoNegocio.modificarCapacidad(capacidadMod, evento);
                        Session.Add("exito", "EL precio se modifico con exito");
                    }
                    else if (modo == "agregar")
                    {
                        // Lógica para agregar
                        int idEvento = int.Parse(Request.QueryString["id"]);
                        Evento evento = eventoNegocio.EventoBuscar(idEvento);

                        int cantidadDisponible = evento.entradasDisponibles;
                        int cantidadIngresada = int.Parse(txtCantidad.Text);

                        if (cantidadIngresada > cantidadDisponible)
                        {
                            lblResultado.Text = "No hay suficientes entradas disponibles.";
                            lblResultado.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        Precio nuevoPrecio = new Precio
                        {
                            idEvento = idEvento,
                            tipoEntrada = txtNombreEntrada.Text,
                            precio = decimal.Parse(txtPrecio.Text),
                            cantidadEntradas = int.Parse(txtCantidad.Text)
                        };

                        Evento actualizarCapacidad = new Evento
                        {
                            entradasDisponibles = int.Parse(txtCantidad.Text)
                        };

                        precioNegocio.agregarPrecio(nuevoPrecio);
                        eventoNegocio.modificarCapacidad(actualizarCapacidad, idEvento);
                        Session.Add("exito", "EL precio se agrego con exito");
                        Response.Redirect("Exito.aspx");
                    }
                }

                Session.Add("exito", "Precio guardado correctamente.");
                Response.Redirect("Exito.aspx");
            }
            catch (Exception ex)
            {
                lblResultado.Text = "Ocurrió un error: " + ex.Message;
                lblResultado.ForeColor = System.Drawing.Color.Red;
                lblResultado.Visible = true;
            }
        }


        private bool validarForm()
        {
            bool esValido = true;

            // Validaciones de campos vacíos
            if (string.IsNullOrEmpty(txtNombreEntrada.Text) || !System.Text.RegularExpressions.Regex.IsMatch(txtNombreEntrada.Text, @"^[a-zA-Z\s]+$"))
            {
                lblNombreEntradaError.Text = "El nombre de la entrada no puede estar vacío.";
                lblNombreEntradaError.ForeColor = System.Drawing.Color.Red;
                lblNombreEntradaError.Visible = true;

                esValido = false;
            }
            else
            {
                lblNombreEntradaError.Text = string.Empty;
                lblNombreEntradaError.Visible = false;
            }

            if (string.IsNullOrEmpty(txtPrecio.Text) || !decimal.TryParse(txtPrecio.Text, out decimal precio) || precio < 0)
            {
                lblPrecioError.Text = "Debe ingresar un precio válido.";
                lblPrecioError.ForeColor = System.Drawing.Color.Red;
                lblPrecioError.Visible = true;
                esValido = false;
            }
            else
            {
                lblPrecioError.Text = string.Empty;
                lblPrecioError.Visible = false;
            }

            
            if (string.IsNullOrEmpty(txtCantidad.Text) || !int.TryParse(txtCantidad.Text, out int cantidad) || cantidad < 0)
            {
                lblCantidadError.Text = "Debe ingresar una cantidad válida.";
                lblCantidadError.ForeColor = System.Drawing.Color.Red;
                lblCantidadError.Visible = true;
                esValido = false;
            }
            else
            {
                lblCantidadError.Text = string.Empty;
                lblCantidadError.Visible = false;
            }

            return esValido;
        }



        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

    }
}
