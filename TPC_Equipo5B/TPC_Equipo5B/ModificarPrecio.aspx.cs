using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
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
                if (!IsPostBack && Request.QueryString["id"] != null)
                {
                    PrecioNegocio precioNegocio = new PrecioNegocio();
                    int idPrecio = int.Parse(Request.QueryString["id"]);
                    Precio seleccionado = precioNegocio.buscarPrecio(idPrecio);

                    if (seleccionado != null)
                    {
                        //precarga de los campos originales
                        txtNombreEntrada.Text = seleccionado.tipoEntrada;
                        txtCantidad.Text = seleccionado.cantidadEntradas.ToString();
                        txtPrecio.Text = seleccionado.precio.ToString();

                    }
                    else
                    {
                        Console.WriteLine("Evento no encontrado.");

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex.Message);
                throw;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idPrecio = int.Parse(Request.QueryString["id"]);
                PrecioNegocio precioNegocio = new PrecioNegocio();
                Precio precioMod = new Precio();
                {
                    precioMod.tipoEntrada = txtNombreEntrada.Text;
                    precioMod.cantidadEntradas = int.Parse(txtCantidad.Text);
                    precioMod.precio = int.Parse(txtPrecio.Text);
                }

                precioNegocio.modificarPrecio(precioMod);
                Response.Redirect("Admin.aspx");
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }

       

    }
}
