﻿using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
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
                MostrarError(ex.Message);
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

            var html = new System.Text.StringBuilder();

            if (listaImagenes.Count == 0)
            {
                html.Append("<div class='carousel-item active'><img src='https://www.shutterstock.com/image-vector/default-ui-image-placeholder-wireframes-600nw-1037719192.jpg' class='d-block w-100' alt='Imagen no disponible'></div>");
            }
            else
            {
                bool primeraImagen = true;

                // Genera HTML del carrusel con las imágenes obtenidas
                foreach (var img in listaImagenes)
                {
                    string claseActiva = primeraImagen ? "active" : "";
                    html.AppendFormat("<div class='carousel-item {0}'><img src='{1}' class='d-block w-100' alt='Imagen del evento'></div>", claseActiva, img.Url);
                    primeraImagen = false;
                }
            }
            return html.ToString();
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
                MostrarError(ex.Message);
            }
        }

        private void MostrarError(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "');</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito.aspx");
        }

        protected void ButtonFavorite_Click(object sender, EventArgs e)
        {
            LinkButton btnFavorite = (LinkButton)sender;
            int eventId = Int32.Parse(btnFavorite.CommandArgument);
            AgregarEventoAlCarrito(eventId);
        }

        private void AgregarEventoAlCarrito(int eventId)
        {
            List<int> carrito = new List<int>();
            if ((List<int>)Session["var"] == null)
            {
                carrito.Add(eventId);
                Session["var"] = carrito;
            }
            else
            {
                carrito = (List<int>)Session["var"];
                carrito.Add(eventId);
                Session["var"] = carrito;
            }
            //Response.Redirect("MisEntradas.aspx?eventId=" + eventId);
        }

    }
}
