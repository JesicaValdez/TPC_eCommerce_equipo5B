using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_Equipo5B
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN))
            {
                Session.Add("error", "No tenes permiso para ingresar a esta pantalla.");
                Response.Redirect("Error.aspx", false);
            }

            if (!IsPostBack)
            {
                // Inicializamos la vista activa en Listado de Usuarios
                MultiViewAdmin.ActiveViewIndex = 0;

                CargarUsuarios();
                MostrarMensaje("Usuarios cargados correctamente.", true);
            }

            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                List<Evento> eventoTemp = (List<Evento>)Session["eventos"];
                Evento seleccionado = eventoTemp.Find(x => x.id == id);
                //textId.Text = seleccionado.id.ToString();
                //txtId.ReadOnly = true;

            }

        }

        // Usuario
        protected void CargarUsuarios()
        {
            try
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                dgvUsuarios.DataSource = usuarioNegocio.listar();
                dgvUsuarios.DataBind();

            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar usuarios: " + ex.Message, false);
            }
        }

        //Cliente
        protected void CargarClientes()
        {
            try
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                dgvClientes.DataSource = clienteNegocio.listar();
                dgvClientes.DataBind();
                MostrarMensaje("Clientes cargados correctamente.", true);
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar clientes: " + ex.Message, false);
            }
        }

        //Botones de Busqueda
        public void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                string usuario = txtBuscarUsuario.Text.Trim();

                List<Dominio.Usuario> usuariosBuscados = usuarioNegocio.buscarUsuario(usuario);

                if (usuariosBuscados != null && usuariosBuscados.Count > 0)
                {
                    dgvUsuarios.DataSource = usuariosBuscados;
                    dgvUsuarios.DataBind();
                    MostrarMensaje("Usuarios encontrados.", true);
                }
                else
                {
                    MostrarMensaje("No se encontraron usuarios con ese criterio.", false);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al buscar usuario: " + ex.Message, false);
            }
        }


        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                Cliente clienteBuscado = new Cliente();

                int cliente = int.Parse(txtClientes.Text);
                clienteBuscado = clienteNegocio.buscarCliente(cliente);

                if (clienteBuscado != null && clienteBuscado.IdCliente != 0)
                {
                    List<Cliente> listaClientes = new List<Cliente>();
                    listaClientes.Add(clienteBuscado);
                    dgvClientes.DataSource = listaClientes;
                    dgvClientes.DataBind();
                    MostrarMensaje("Usuario encontrado.", true);
                }
                else
                {
                    MostrarMensaje("Por favor, ingrese un ID de cliente válido.", false);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al buscar Cliente: " + ex.Message, false);
            }
        }

        public void btnBuscarEvento_Click(object sender, EventArgs e)
        {
            //busqueda de evento por codigo
            try
            {
                EventoNegocio eventoNegocio = new EventoNegocio();
                Evento eventoBuscado = new Evento();

                int codigoEvento = int.Parse(txtBuscarEvento.Text);
                eventoBuscado = eventoNegocio.buscarEvento(codigoEvento);

                if (eventoBuscado != null && eventoBuscado.id != 0)
                {
                    List<Evento> listaEventos = new List<Evento>();
                    listaEventos.Add(eventoBuscado);
                    dgvEventos.DataSource = listaEventos;
                    dgvEventos.DataBind();
                    MostrarMensaje("Evento encontrado.", true);
                }
                else
                {
                    MostrarMensaje("Por favor, ingrese un ID de evento válido.", false);

                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al buscar evento: " + ex.Message, false);
            }
        }

        // Evento -  Botón de gestión de eventos
        protected void CargarEventos()
        {
            try
            {
                EventoNegocio eventoNegocio = new EventoNegocio();
                dgvEventos.DataSource = eventoNegocio.listarEventos();
                dgvEventos.DataBind();
                MostrarMensaje("Eventos cargados correctamente.", true);
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar eventos: " + ex.Message, false);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = ((Button)sender).CommandArgument;
                Response.Redirect("CrearEvento.aspx?id=" + id);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
            }
        }

        protected void btnEliminarEvento_Click(Object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(((Button)sender).CommandArgument);

                EventoNegocio eventoNegocio = new EventoNegocio();
                eventoNegocio.eliminarEvento(id);


                MostrarMensaje("Evento eliminado correctamente.", true);
                CargarUsuarios();
            }
            catch (Exception)
            {
                Session.Add("error", "Error al intentar eliminar el evento seleccionado");
                Response.Redirect("Error.aspx", false);

            }
        }

        //VENTANAS
        protected void VerListadoUsuarios(object sender, EventArgs e)
        {
            MultiViewAdmin.ActiveViewIndex = 0;
        }
        protected void VerListadoClientes(object sender, EventArgs e)
        {
            MultiViewAdmin.ActiveViewIndex = 1;
            CargarClientes();
        }

        protected void MostrarGestionEventos(object sender, EventArgs e)
        {
            MultiViewAdmin.ActiveViewIndex = 2;
            CargarEventos();
        }

        //Gestion Precios
        protected void GestionPrecios(object sender, EventArgs e)
        {
            MultiViewAdmin.ActiveViewIndex = 3;
            CargarNombreEventos();
        }

        protected void CargarNombreEventos()
        {
            try
            {
                EventoNegocio eventoNegocio = new EventoNegocio();
                List<Evento> lista = eventoNegocio.listarEventos();

                if (lista != null && lista.Count > 0)
                {
                    ddlEventos.DataSource = lista;
                    ddlEventos.DataTextField = "nombre";
                    ddlEventos.DataValueField = "id";
                    ddlEventos.DataBind();
                    MostrarMensaje("Seleccione un evento para ver entradas y precios disponible.", false);
                }
                else
                {
                    MostrarMensaje("No se encontraron eventos para cargar.", false);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar eventos: " + ex.Message, false);
            }
        }
        protected void ddlEventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int eventoId = int.Parse(ddlEventos.SelectedValue);
                EventoNegocio eventoNegocio = new EventoNegocio();
                Evento eventoSeleccionado = eventoNegocio.buscarEvento(eventoId);
                PrecioNegocio eventoPrecio = new PrecioNegocio();

                if (eventoSeleccionado != null)
                {
                    int cantidad = eventoSeleccionado.entradasDisponibles;

                    if (cantidad > 0)
                    {
                        // Si hay entradas disponibles
                        lblEntradasDisponibles.Text = "Capacidad disponible: " + cantidad.ToString();
                        var preciosLista = eventoPrecio.listarporEvento(eventoId);

                        if (preciosLista != null && preciosLista.Count > 0)
                        {
                            dgvPrecios.DataSource = preciosLista;
                            dgvPrecios.DataBind();
                            MostrarMensaje("Sección precios cargado correctamente.", true);
                        }
                        else
                        {
                            MostrarMensaje("No se encontraron precios para cargar.", false);
                        }

                        BtnPrecio.Enabled = true;
                        BtnPrecio.CommandArgument = eventoId.ToString();
                    }
                    else
                    {
                        // Si no hay entradas disponibles
                        var preciosLista = eventoPrecio.listarporEvento(eventoId);

                        lblEntradasDisponibles.Text = "No hay capacidad disponibles para agregar entradas a este evento.";
                        dgvPrecios.DataSource = preciosLista;
                        dgvPrecios.DataBind();
                        BtnPrecio.Enabled = false;
                    }
                }
                else
                {
                    // Si no se encontró el evento
                    lblEntradasDisponibles.Text = "No se encontró el evento seleccionado.";
                    BtnPrecio.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar entradas disponibles: " + ex.Message, false);
            }
        }

        protected void btnPrecio_Click(object sender, EventArgs e)
        {
            try
            {
                //Recuperar el commandargument del boton
                string eventoId = ((Button)sender).CommandArgument;
                // Determinar el modo (puede ser "agregar" o "modificar")
                string modo = "agregar";
                // Redirigir a la página con los parámetros id y modo
                Response.Redirect($"CrearPrecio.aspx?id={eventoId}&modo={modo}");
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
            }
            //aqui falta un mensaje que se hizo correctamente
        }

        protected void btnModificarPrecio_Click(object sender, EventArgs e)
        {
            try
            {
                //Recuperar el commandargument del boton
                string eventoId = ((Button)sender).CommandArgument;
                // Determinar el modo (puede ser "agregar" o "modificar")
                string modo = "modificar";
                // Redirigir a la página con los parámetros id y modo
                Response.Redirect($"CrearPrecio.aspx?id={eventoId}&modo={modo}");
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
            }
            //aqui falta un mensaje que se hizo correctamente
        }

        protected void btnEliminarPrecio_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(((Button)sender).CommandArgument);

                PrecioNegocio precioNegocio = new PrecioNegocio();
                precioNegocio.eliminarPrecio(id);


                MostrarMensaje("Precio del evento eliminado correctamente.", true);
            }
            catch (Exception)
            {
                Session.Add("error", "Error al intentar eliminar el precio seleccionado");
                Response.Redirect("Error.aspx", false);

            }
        }
        //REPORTES
        protected void MostrarReportes(object sender, EventArgs e)
        {
            MultiViewAdmin.ActiveViewIndex = 5;
            // AGREGAR LOGICA PARA VER REPORTES / GENERARLOS
        }

        // Reportes
        protected void ddlReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtén el valor seleccionado
            string selectedValue = ddlReportes.SelectedValue;

            // Resetea la visibilidad de todos los paneles
            pnlUsuarioFiltro.Visible = false;
            pnlEventosFiltro.Visible = false;
            pnlComprasFiltro.Visible = false;
            pnlRecaudacionFiltro.Visible = false;

            // Activa el panel correspondiente
            switch (selectedValue)
            {
                case "1": // Reporte de Usuarios
                    pnlUsuarioFiltro.Visible = true;
                    break;
                case "2": // Reporte de Eventos
                    pnlEventosFiltro.Visible = true;
                    break;
                case "3": // Reporte de Compras
                    pnlComprasFiltro.Visible = true;
                    break;
                case "4": // Recaudación
                    pnlRecaudacionFiltro.Visible = true;
                    break;
                default:
                    // No mostrar ningún panel
                    break;
            }
        }


        // Método para cerrar sesión
        protected void CerrarSesion(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        private void MostrarMensaje(string mensaje, bool exito)
        {
            panelMessage.Visible = true;
            panelMessage.CssClass = exito ? "alert-success" : "alert-danger";
            panelMessage.Controls.Add(new LiteralControl(mensaje));
        }


        protected void CargarCompras()
        {
            try
            {
                CompraNegocio compraNegocio = new CompraNegocio();
                dgvCompras.DataSource = compraNegocio.listarCompras();
                dgvCompras.DataBind();
                MostrarMensaje("Compras cargadas correctamente.", true);
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar compras: " + ex.Message, false);
            }
        }

        protected void btnAnular_Click(object sender, EventArgs e)
        {
            
            CompraNegocio compraNegocio = new CompraNegocio();
            compraNegocio.bajaCompra(int.Parse(((Button)sender).CommandArgument));
            MostrarMensaje("Compra dada de baja correctamente.", true);
            CargarCompras();
        }

        protected void GestionCompras(object sender, EventArgs e)
        {
            MultiViewAdmin.ActiveViewIndex = 4;
            CargarCompras();
        }
    }
}