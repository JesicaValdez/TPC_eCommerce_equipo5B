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
                List<Evento> eventoTemp = (List<Evento>) Session["eventos"];
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
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario usuarioBuscado = null;

            string usuario = txtBuscarUsuario.Text;
            List<Dominio.Usuario> usuariosBuscados = usuarioNegocio.buscarUsuario(usuario);

            if (usuarioBuscado != null && usuariosBuscados.Count > 0)
            {
                List<Usuario> listaUsuarios = new List<Usuario>();
                listaUsuarios.Add(usuarioBuscado);
                dgvUsuarios.DataSource = listaUsuarios;
                dgvUsuarios.DataBind();
                MostrarMensaje("Usuario encontrado.", true);
            }
            else
            {
                MostrarMensaje("Por favor, ingrese un Id de usuario válido.", false);
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
                    dgvUsuarios.DataSource = listaClientes;
                    dgvUsuarios.DataBind();
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
                eventoBuscado = eventoNegocio.EventoBuscar(codigoEvento);

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
                    MostrarMensaje ("Por favor, ingrese un ID de evento válido.", false);
                    
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al buscar evento: " + ex.Message, false);
            }
        }

        // Evento
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

        protected void ButtonM_Click(object sender, EventArgs e)
        {
            try
            {
                   string id = ((Button)sender).CommandArgument;
                
                   Session.Add("EventoID", id);
                   Response.Redirect("CrearEvento.aspx");

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

        protected void dgvEventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obtenerDato = dgvEventos.SelectedRow.Cells[0].Text;
            var id = dgvEventos.SelectedDataKey.Value.ToString();
            Response.Redirect("CrearEvento.aspx?id=" + id);
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

        protected void MostrarReportes(object sender, EventArgs e)
        {
            MultiViewAdmin.ActiveViewIndex = 3;
        }

        // Botón de gestión de eventos

        protected void btnModificar_Click (object sender, EventArgs e)
        {
            //Modificar el evento con el idEvento
            Response.Redirect("CrearEvento.aspx");
            
        }

        // Método para generar reportes
        protected void GenerarReporte(object sender, EventArgs e)
        {
            int reporteSeleccionado = int.Parse(ddlReportes.SelectedValue);

            switch (reporteSeleccionado)
            {
                case 1:
                    panelReporte.Controls.Add(new LiteralControl("<p>Reporte de Usuarios generado.</p>"));
                    break;
                case 2:
                    panelReporte.Controls.Add(new LiteralControl("<p>Reporte de Eventos generado.</p>"));
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
    }
}