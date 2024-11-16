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
                //Response.Redirect("Login.aspx");
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
            foreach (List<int> l in (List<List<int>>)Session["carritoid"])
            {
                int idcliente = clienteNegocio.obtenerIdClientePorUsuario((int)Session["IdUsuario"]);
                Evento evt = eventoNegocio.buscarEvento(l[0]);
                Precio prc = precioNegocio.buscarPrecio(l[2]);
                int idcompra = compraNegocio.cargarCompra(evt.id, idcliente, prc.tipoEntrada, l[1], prc.precio * l[1]*110/100);
                for(int i=0; i<l[1]; i++)
                {
                    entradaNegocio.cargarEntrada(evt.id, prc.tipoEntrada, prc.precio, idcompra);
                }
                precioNegocio.descontarEntradas(l[2], l[1]);
                Response.Write("<script>alert(' ¡LA COMPRA SE REALIZO CON EXITO! ');</script>");
            }
        }
    }
}