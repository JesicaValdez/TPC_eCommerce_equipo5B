using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                            txtNombreEntrada.Text = precio.tipoEntrada;
                            txtPrecio.Text = precio.precio.ToString();
                            txtCantidad.Text = precio.cantidadEntradas.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
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
                    }
                    else if (modo == "agregar")
                    {
                        // Lógica para agregar
                        int idEvento = int.Parse(Request.QueryString["id"]);
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
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
