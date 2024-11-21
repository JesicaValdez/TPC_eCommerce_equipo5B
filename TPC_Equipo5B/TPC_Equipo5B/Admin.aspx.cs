using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                    ddlEventos.Items.Insert(0, new ListItem("Eventos", "0"));
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
                        CargarPrecios(eventoId);
                        BtnPrecio.Enabled = true;
                        BtnPrecio.CommandArgument = eventoId.ToString();
                    }
                    else
                    {
                        lblEntradasDisponibles.Text = "No hay capacidad disponibles para agregar entradas a este evento.";
                        CargarPrecios(eventoId);
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

        protected void CargarPrecios(int eventoId)
        {
            try
            {
                PrecioNegocio precioNegocio = new PrecioNegocio();
                var preciosLista = precioNegocio.listarporEvento(eventoId);

                if (preciosLista != null && preciosLista.Count > 0)
                {
                    dgvPrecios.DataSource = preciosLista;
                    dgvPrecios.DataBind();
                    MostrarMensaje(" Precios cargados correctamente.", true);
                }
                else
                {
                    dgvPrecios.DataSource = null;
                    dgvPrecios.DataBind();
                    MostrarMensaje(" No se encontraron precios para cargar.", false);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar precios: " + ex.Message, false);
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
            MostrarMensaje("Precio creado correctamente.", true);
            Response.Redirect("Exito.aspx");
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
            MostrarMensaje("Precio modificado correctamente.", true);
            Response.Redirect("Exito.aspx");
        }

        protected void btnEliminarPrecio_Click(object sender, EventArgs e)
        {
            try
            {
                int idPrecio = int.Parse(((Button)sender).CommandArgument);
                int eventoId = int.Parse(ddlEventos.SelectedValue); //obtengo el ID del evento seleccionado

                PrecioNegocio precioNegocio = new PrecioNegocio();
                precioNegocio.eliminarPrecio(idPrecio);


                MostrarMensaje("Precio del evento eliminado correctamente.", true);
                CargarPrecios(eventoId);

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

        protected void ddlReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = ddlReportes.SelectedValue;

            ResetUserControls();
            ResetCompraControls();
            ResetRecaudacionControls();

            pnlUsuarioFiltro.Visible = false;
            pnlEventosFiltro.Visible = false;
            pnlComprasFiltro.Visible = false;
            pnlRecaudacionFiltro.Visible = false;
            
            switch (selectedValue)
            {
                case "1": // Reporte de Cliente
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
            }
        }
        //CLIENTE
        protected void ddlUsuarioFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {            
            string select = ddlUsuarioFiltro.SelectedValue;

            txtMes.Visible = false;
            txtAnio.Visible = false;
            txtCompraCl.Visible = false;

            btn_reporte1.Visible = false;
            btn_reporte2.Visible = false;
            btn_reporte3.Visible = false;

            switch (select)
            {
                case "1":
                    txtMes.Visible = true;
                    txtAnio.Visible = true;
                    btn_reporte1.Visible = true;
                    break;
                case "2":
                    txtAnio.Visible = true;
                    btn_reporte2.Visible = true;
                    break;
                case "3":
                    txtCompraCl.Visible = true;
                    btn_reporte3.Visible = true;
                    break;
            }
        }

        protected void click_btnReporteCL1(object sender, EventArgs e)
        {
            ReporteNegocio reporte = new ReporteNegocio();

            int mes = 0;
            int anio = 0;

            if (int.TryParse(txtMes.Text, out mes) && int.TryParse(txtAnio.Text, out anio))
            {
                List<Compra> compras = reporte.ReporteMes(mes, anio);

                if (compras != null && compras.Count > 0)
                {
                    gvClientes1.DataSource = compras;
                    gvClientes1.DataBind();
                }
                else
                {
                    lblError.Text = "No se encontraron compras para este mes y año.";
                }
            }
            else
            {
                lblError.Text = "Por favor, ingrese un mes y un año válidos.";
            }
        }
        protected void click_btnReporteCL2(object sender, EventArgs e)
        {
            ReporteNegocio reporte = new ReporteNegocio();

            int anio = 0;

            if (int.TryParse(txtAnio.Text, out anio))
            {
                List<Compra> compras = reporte.ReporteAnio(anio);

                if (compras != null && compras.Count > 0)
                {
                    gvClientes2.DataSource = compras;
                    gvClientes2.DataBind();
                }
                else
                {
                    lblError.Text = "No se encontraron compras para este año.";
                }
            }
            else
            {
                lblError.Text = "Por favor, ingrese un año válidos.";
            }
        }

        protected void click_btnReporteCL3(object sender, EventArgs e)
        {
            ReporteNegocio reporte = new ReporteNegocio();

            int id = 0;

            if (int.TryParse(txtCompraCl.Text, out id))
            {
                List<Compra> comprasCliente = reporte.CompraCliente(id);

                if (comprasCliente != null && comprasCliente.Count > 0)
                {
                    gvClientes3.DataSource = comprasCliente;
                    gvClientes3.DataBind();
                }
                else
                {
                    lblError.Text = "No se encontraron compras para este cliente.";
                }
            }
            else
            {
                lblError.Text = "Por favor, ingrese un id válido.";
            }
        }

        //COMPRAS
        protected void ddlComprasFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = ddlComprasFiltro.SelectedValue;

            txtDiaC.Visible = false;
            txtMesC.Visible = false;
            txtAnioC.Visible = false;
            btn_reporteC1.Visible = false;
            btn_reporteC2.Visible = false;
            btn_reporteC3.Visible = false;

            switch (select)
            {
                case "1":
                    txtDiaC.Visible = true;
                    txtMesC.Visible = true;
                    txtAnioC.Visible = true;
                    btn_reporteC1.Visible = true;
                    break;
                case "2":
                    txtMesC.Visible = true;
                    txtAnioC.Visible = true;
                    btn_reporteC2.Visible = true;
                    break;
                case "3":
                    txtAnioC.Visible = true;
                    btn_reporteC3.Visible = true;
                    break;
            }
        }

        protected void click_btnReporteCM1(object sender, EventArgs e)
        {
            ReporteNegocio reporte = new ReporteNegocio();

            int dia = 0;
            int mes = 0;
            int anio = 0;

            if (int.TryParse(txtDiaC.Text, out dia) && int.TryParse(txtMesC.Text, out mes) && int.TryParse(txtAnioC.Text, out anio))
            {
                List<Compra> comprasCliente = reporte.CompraPorDia(dia, mes, anio);

                if (comprasCliente != null && comprasCliente.Count > 0)
                {
                    gvCompra1.DataSource = comprasCliente;
                    gvCompra1.DataBind();
                }
                else
                {
                    lblError.Text = "No hay compras realizada en esta fecha.";
                }
            }
            else
            {
                lblError.Text = "Por favor, ingrese un dia, mes y año valido.";
            }

        }

        protected void click_btnReporteCM2(object sender, EventArgs e)
        {

        }
        protected void click_btnReporteCM3(object sender, EventArgs e)
        {

        }
        //RECAUDACION
        protected void ddlRecaudacionFiltro_Changed(object sender, EventArgs e)
        {
            string select = ddlRecaudacionFiltro.SelectedValue;

            txtDiaR.Visible = false;
            txtMesR.Visible = false;
            txtAnioR.Visible = false;
            btn_reporteR1.Visible = false;
            btn_reporteR2.Visible = false;
            btn_reporteR3.Visible = false;

            switch (select)
            {
                case "1":
                    txtDiaR.Visible = true;
                    txtMesR.Visible = true;
                    txtAnioR.Visible = true;
                    btn_reporteR1.Visible = true;
                    break;
                case "2":                    
                    txtMesR.Visible = true;
                    txtAnioR.Visible = true;
                    btn_reporteR2.Visible = true;
                    break;
                case "3":                    
                    txtAnioR.Visible = true;
                    btn_reporteR3.Visible = true;
                    break;
            }
        }
        protected void click_btnReporteR1(object sender, EventArgs e)
        {
            ReporteNegocio reporte = new ReporteNegocio();

            int dia = 0;
            int mes = 0;
            int anio = 0;

            if (int.TryParse(txtDiaR.Text, out dia) && int.TryParse(txtMesR.Text, out mes) && int.TryParse(txtAnioR.Text, out anio))
            {
                List<Compra> comprasCliente = reporte.RecaudacionPorDia(dia, mes, anio);

                if (comprasCliente != null && comprasCliente.Count > 0)
                {
                    gvRecaudacion1.DataSource = comprasCliente;
                    gvRecaudacion1.DataBind();
                }
                else
                {
                    lblError.Text = "No hay recaudaciones para esta fecha.";
                }
            }
            else
            {
                lblError.Text = "Por favor, ingrese un dia, mes y año valido.";
            }

        }
        protected void click_btnReporteR2(object sender, EventArgs e)
        {

        }
        protected void click_btnReporteR3(object sender, EventArgs e)
        {

        }
        private void ResetUserControls()
        {
            ddlUsuarioFiltro.SelectedValue = "0";

            txtMes.Visible = false;
            txtAnio.Visible = false;
            txtCompraCl.Visible = false;

            btn_reporte1.Visible = false;
            btn_reporte2.Visible = false;
            btn_reporte3.Visible = false;
        }

        private void ResetCompraControls()
        {
            ddlComprasFiltro.SelectedValue = "0";

            txtDiaC.Visible = false;
            txtMesC.Visible = false;
            txtAnioC.Visible = false;

            btn_reporteC1.Visible = false;
            btn_reporteC2.Visible = false;
            btn_reporteC3.Visible = false;
        }

        private void ResetRecaudacionControls()
        {
            ddlRecaudacionFiltro.SelectedValue = "0";

            txtDiaR.Visible = false;
            txtMesR.Visible = false;
            txtAnioR.Visible = false;

            btn_reporteR1.Visible = false;
            btn_reporteR2.Visible = false;
            btn_reporteR3.Visible = false;
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

        //Compras
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