using Negocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.Services.Description;

namespace TPC_Equipo5B
{
    public partial class VerDetalle : System.Web.UI.Page
    {
        public ImagenNegocio negocioImagen = new ImagenNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] != null)
                {
                    EventoNegocio eventoNegocio = new EventoNegocio();
                    List<Evento> evento = new List<Evento>();
                    evento.Add(eventoNegocio.buscarEvento((int)Session["id"]));
                    detalle.DataSource = evento;
                    detalle.DataBind();

                    PrecioNegocio precioNegocio = new PrecioNegocio();
                    List<Precio> precio = precioNegocio.listarporEvento((int)Session["id"]);
                    ddlEntradas.DataSource = precio;
                    ddlEntradas.DataTextField = "tipoEntrada";
                    ddlEntradas.DataValueField = "idPrecio";
                    ddlEntradas.DataBind();
                    ddlEntradas.Items.Insert(0, new ListItem("Tipo de entrada", "0"));
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            bool b = false;
            List<List<int>> carritoid = new List<List<int>>();
            PrecioNegocio precioNegocio = new PrecioNegocio();
            Precio p = precioNegocio.buscarPrecio(Convert.ToInt32(ddlEntradas.SelectedValue));

            if (ddlEntradas.SelectedValue != "0")
            {
                if (p.cantidadEntradas - Int32.Parse(DropDownList1.SelectedValue) >= 0)
                {
                    if ((List<List<int>>)Session["carritoid"] == null)
                    {
                        List<int> lista = new List<int>();
                        lista.Add((int)Session["id"]);
                        lista.Add(Int32.Parse(DropDownList1.SelectedValue));
                        int idprecio = Convert.ToInt32(ddlEntradas.SelectedValue);
                        lista.Add(idprecio);
                        carritoid.Add(lista);

                        Session["carritoid"] = carritoid;
                        Session.Add("exito", "Se agrego con exito al carrito");
                        Response.Redirect("Exito.aspx");
                        //Response.Write("<script>alert(' Se agrego al exitosamente al carrito ');</script>");

                    }
                    else
                    {

                        carritoid = (List<List<int>>)Session["carritoid"];
                        foreach (List<int> l in carritoid)
                        {
                            if (l[0] == (int)Session["id"] && l[2] == Convert.ToInt32(ddlEntradas.SelectedValue))
                            {
                                if (p.cantidadEntradas - (l[1] + Int32.Parse(DropDownList1.SelectedValue)) >= 0)
                                {
                                    l[1] += Int32.Parse(DropDownList1.SelectedValue);
                                    b = true;
                                }
                                else
                                {
                                    Session.Add("error", "No se pudo agregar al carrito, no quedan suficientes entradas de este tipo para este evento");
                                    Response.Redirect("Error.aspx");
                                }
                            }
                        }
                        if (b == false)
                        {

                            List<int> lista = new List<int>();
                            lista.Add((int)Session["id"]);
                            lista.Add(Int32.Parse(DropDownList1.SelectedValue));
                            lista.Add(Int32.Parse(ddlEntradas.SelectedValue));
                            carritoid.Add(lista);
                        }

                        Session["carritoid"] = carritoid;
                        Session.Add("exito", "Se agrego con exito al carrito");
                        Response.Redirect("Exito.aspx");
                        //Response.Write("<script>alert(' Se agrego exitosamente al carrito ');</script>");

                    }
                }
                else
                {
                    Session.Add("error", "No se pudo agregar al carrito, no quedan suficientes entradas de este tipo para este evento");
                    Response.Redirect("Error.aspx");
                }
            }
        }

        public string entradas()
        {
            string precios = "";
            PrecioNegocio precioNegocio = new PrecioNegocio();
            List<Precio> lista = precioNegocio.listarporEvento((int)Session["id"]);
            foreach (Precio precio in lista)
            {
                precios = precios + "\r\n" + precio.tipoEntrada + " " + precio.precio.ToString() + " - ";
            }
            return precios;
        }
    }
}