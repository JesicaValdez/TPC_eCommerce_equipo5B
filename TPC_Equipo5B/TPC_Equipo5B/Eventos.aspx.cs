using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_Equipo5B
{
    public partial class Eventos : System.Web.UI.Page
    {
        public List<Evento> listaEventos { get; set; }
        public ImagenNegocio negocioImagen = new ImagenNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            EventoNegocio eventoNegocio = new EventoNegocio();

            if (!IsPostBack)
            {
                CargarEventos();
                CargarTiposEventos();
            }
        }

        private void CargarEventos()
        {
            EventoNegocio eventoNegocio = new EventoNegocio();
            try
            {
                List<Evento> listaEventos = eventoNegocio.listarEventos();
                rptArticulos.DataSource = listaEventos;
                rptArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void CargarTiposEventos()
        {
            TipoEventoNegocio tipoEventoNegocio = new TipoEventoNegocio();
            try
            {
                List<TipoEvento> listaTipos = tipoEventoNegocio.listarTipos();
                ddlEventos.DataSource = listaTipos;
                ddlEventos.DataTextField = "descripcion";
                ddlEventos.DataValueField = "id";
                ddlEventos.DataBind();
                ddlEventos.Items.Insert(0, new ListItem("Todos", "0"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        protected string GenerarImagenes(object idEvento)
        {
            int id = Convert.ToInt32(idEvento);
            ImagenNegocio negocioImagen = new ImagenNegocio();
            List<Dominio.Imagen> listaImagenes = negocioImagen.buscarimagenes(id);

            // Verificar si la lista de imágenes contiene datos
            if (listaImagenes == null || listaImagenes.Count == 0)
            {
                Console.WriteLine("No se encontraron imágenes para el evento con ID: " + id);
            }
            else
            {
                Console.WriteLine("Se encontraron " + listaImagenes.Count + " imágenes para el evento con ID: " + id);
            }

            string html = "";
            bool primeraImagen = true;
            foreach (var img in listaImagenes)
            {
                string claseActiva = primeraImagen ? "active" : "";
                html += $"<div class='carousel-item {claseActiva}'><img src='{img.Url}' class='d-block w-100' alt='...'></div>";
                primeraImagen = false;
            }

            // Si no hay imágenes, muestra una imagen por defecto
            if (listaImagenes.Count == 0)
            {
                html += "<div class='carousel-item active'><img src='https://www.shutterstock.com/image-vector/default-ui-image-placeholder-wireframes-600nw-1037719192.jpg' class='d-block w-100' alt='Imagen no disponible'></div>";
            }

            // Imprimir el HTML generado para depuración
            Console.WriteLine("HTML generado: " + html);

            return html;
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            EventoNegocio eventoNegocio = new EventoNegocio();
            List<Evento> lista;

            try
            {
                if (ddlEventos.SelectedItem.Text == "Todos")
                {
                    lista = eventoNegocio.listarEventos();
                }
                else
                {
                    int idTipo = Convert.ToInt32(ddlEventos.SelectedValue); // Usar el ID en lugar de la descripción
                    lista = eventoNegocio.filtrarportipo(idTipo);
                }

                // Eliminar duplicados basados en el ID del evento
                lista = lista.GroupBy(ev => ev.id).Select(g => g.First()).ToList();

                rptArticulos.DataSource = lista;
                rptArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            LinkButton btn2 = (LinkButton)sender;
            Session.Add("id", Int32.Parse(btn2.CommandArgument));
            Response.Redirect("VerDetalle.aspx");
        }

        protected void ButtonFavorite_Click(object sender, EventArgs e)
        {

            
        }

        

    }
}
