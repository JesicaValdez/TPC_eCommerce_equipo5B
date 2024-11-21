using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_Equipo5B
{
    public partial class Pago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debe iniciar secion para poder continuar con la compra");
                Response.Redirect("Error.aspx");
            }
            if (Session["subtotal"] != null)
            {
                Label5.Text = Session["subtotal"].ToString();
                Label6.Text = Session["costoservicio"].ToString();
                Label7.Text = Session["total"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EventoNegocio eventoNegocio = new EventoNegocio();
            PrecioNegocio precioNegocio = new PrecioNegocio();
            CompraNegocio compraNegocio = new CompraNegocio();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            EntradaNegocio entradaNegocio = new EntradaNegocio();
            EmailService emailService = new EmailService();
            if (CheckBox1.Checked)
            {
                if ((List<List<int>>)Session["carritoid"] != null)
                {
                    foreach (List<int> l in (List<List<int>>)Session["carritoid"])
                    {
                        int idcliente = clienteNegocio.obtenerIdClientePorUsuario((int)Session["IdUsuario"]);
                        Evento evt = eventoNegocio.buscarEvento(l[0]);
                        Precio prc = precioNegocio.buscarPrecio(l[2]);
                        decimal total = prc.precio * l[1] * 110 / 100;
                        int idcompra = compraNegocio.cargarCompra(evt.id, idcliente, prc.tipoEntrada, l[1], total);
                        List<int> lista = new List<int>();
                        for (int i = 0; i < l[1]; i++)
                        {
                            int id = entradaNegocio.cargarEntrada(evt.id, prc.tipoEntrada, prc.precio, idcompra);
                            lista.Add(id);
                        }
                        precioNegocio.descontarEntradas(l[2], l[1]);
                        string ids = idsEntradas(lista);
                        string cuerpo = "Felicidades! \r\nSe concreto la compra de tus entradas para " + evt.nombre + "\r\nEl id de tu compra es: " + idcompra + "\r\nLos id de tus entradas son: " + ids + "\r\nPrecio total: " + total.ToString() + "\r\nFecha: " + evt.fecha.ToString();
                        emailService.armarCorreo((string)Session["email"], "Compra Exitosa", cuerpo);
                        emailService.enviarEmail();
                        
                        //Response.Write("<script>alert(' ¡LA COMPRA SE REALIZO CON EXITO! ');</script>");
                    }
                    Session.Add("exito", "¡LA COMPRA SE REALIZO CON EXITO!");
                    Response.Redirect("Exito.aspx");
                }
            }
            else
            {
                lblTerminos.Visible = true;
            }
        }

        public string idsEntradas(List<int> l)
        {
            string ids = "";
            for(int i = 0; i < l.Count(); i++)
            {
                ids = ids + " - " + l[i].ToString();
            }
            return ids;
        }
    }
}