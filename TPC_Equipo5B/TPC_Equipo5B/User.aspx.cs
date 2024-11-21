using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Negocio;
using System.Text.RegularExpressions;

namespace TPC_Equipo5B
{
    public partial class Usuario : System.Web.UI.Page
    {
        ClienteNegocio negocio = new ClienteNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                
            }

            if (Session["usuario"] != null)
            {
                lblemailU.Text = Session["email"].ToString().ToUpper();

                //campos autocompletados modificar
                int id = (int)Session["IdUsuario"];

                Cliente cliente = negocio.obtenerCliente(id);

                if (cliente != null)
                {
                    txtb_dni.Text = cliente.Dni;
                    txtb_Nombre.Text = cliente.Nombre;
                    txtb_Apellido.Text = cliente.Apellido;
                    txtb_FechaNacimiento.Text = cliente.fechaNacimiento.ToString("yyyy-MM-dd");
                    txtb_Telefono.Text = cliente.Telefono;
                }

            }
            else
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Error.aspx");
            }
        }

        protected void btn_clickEditar(object sener, EventArgs e)
        {
            try
            {
                if (validarEditar())
                {
                    return;
                }

                bool dniEncontrado = negocio.DniExistente(txtb_dni.Text);

                if (dniEncontrado)
                {
                    lblDni.Text = "El DNI ingresado ya se encuentra en uso";
                    lblDni.Visible = true;
                    return;
                }

                if (Session["IdUsuario"] != null)
                {
                    int id = (int)Session["IdUsuario"];
                    int nroCliente = negocio.obtenerIdClientePorUsuario(id);


                    if (nroCliente != 0)
                    {
                        string dni = txtb_dni.Text;
                        string nombre = txtb_Nombre.Text;
                        string apellido = txtb_Apellido.Text;
                        DateTime fecha = Convert.ToDateTime(txtb_FechaNacimiento.Text);
                        string telefono = txtb_Telefono.Text;

                        Cliente clienteModificado = new Cliente
                        {
                            Dni = dni,
                            Nombre = nombre,
                            Apellido = apellido,
                            fechaNacimiento = fecha,
                            Telefono = telefono
                        };

                        negocio.modificarCliente(clienteModificado, nroCliente);

                        Session.Add("exito", "Ha editado su cuenta con exito.");
                        Response.Redirect("Exito.aspx", false);
                    }
                    else
                    {
                        Session.Add("error", "No se encontró el cliente asociado a este usuario.");
                        Response.Redirect("Error.aspx", false);
                    }
                }
                else
                {
                    Session.Add("error", "No se encontró el usuario");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void btn_EditarPass(object sender, EventArgs e)
        {
            try
            {
                if (validarCamposPass())
                {
                    return;
                }
                if (!PassCoinciden(txt_PassNuevo.Text, txt_PassNuevoConfirmar.Text))
                {
                    lbl_passNuevoConfirmar.Text = "Las contraseñas no coinciden";
                    lbl_passNuevoConfirmar.Visible = true;
                    return;
                }

                UsuarioNegocio negocio = new UsuarioNegocio();

                if (Session["usuario"] != null)
                {
                    int id = (int)Session["IdUsuario"];

                    string pass = txt_PassNuevoConfirmar.Text;

                    Dominio.Usuario pasModificado = new Dominio.Usuario
                    {
                        Pass = pass,
                    };

                    negocio.ModificarPass(pasModificado, id);

                    Session.Add("exito", "Ha cambiado su contraseña con exito.");
                    Response.Redirect("Exito.aspx", false);

                }
                else
                {
                    Session.Add("error", "No se encontró el usuario");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void click_elimarUser(object sender, EventArgs e)
        {
            ClienteNegocio negocioCliente = new ClienteNegocio();
            UsuarioNegocio negocioUser = new UsuarioNegocio();

            try
            {
                if (Session["IdUsuario"] != null)
                {
                    int id = int.Parse(Session["IdUsuario"].ToString());

                    negocioCliente.BajaCliente(id);
                    negocioUser.eliminarUser(id);

                    Session.Add("exito", "Ha borrado su cuenta con exito.");
                    Response.Redirect("Exito.aspx", false);
                }
                else
                {
                    Session.Add("error", "No se encontró el usuario");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        protected void Desconectarse(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Session.Abandon();
                Session.Remove("usuario");

                Response.Redirect("Default.aspx");
            }
        }
        ///validaciones para el form de editar
        private bool validarEditar()
        {
            bool valido = true;
            try
            {
                limpiar();

                if (dniValido())
                {
                    valido = false;
                }
                //validar nombre
                if (string.IsNullOrEmpty(txtb_Nombre.Text))
                {
                    lblNombre.Text = "ingrese nombre";
                    lblNombre.Visible = true;
                    valido = false;
                }
                //validar apellido
                if (string.IsNullOrEmpty(txtb_Apellido.Text))
                {
                    lblApellido.Text = "ingrese apellido";
                    lblApellido.Visible = true;
                    valido = false;
                }
                //validar fecha de naciemiento
                if (string.IsNullOrEmpty(txtb_FechaNacimiento.Text))
                {
                    lblfechaN.Text = "ingrese fecha de nacimiento";
                    lblfechaN.Visible = true;
                    valido = false;
                }
                //validar telefono
                if (string.IsNullOrEmpty(txtb_Telefono.Text))
                {
                    lblTel.Text = "ingrese numero de telefono";
                    lblTel.Visible = true;
                    valido = false;
                }

                return valido;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool dniValido()
        {
            if (string.IsNullOrEmpty(txtb_dni.Text))
            {
                lblDni.Text = "Ingrese un DNI";
                lblDni.Visible = true;
                return false;
            }
            if (txtb_dni.Text.Length != 8 || !txtb_dni.Text.All(char.IsDigit))
            {
                lblDni.Text = "Ingrese un DNI válido (8 dígitos)";
                lblDni.Visible = true;
                return false;
            }
            return true;
        }

        private void limpiar()
        {
            lblDni.Visible = lblNombre.Visible = lblApellido.Visible = lblfechaN.Visible =
            lblTel.Visible = false;
        }
        //validaciones para el cambio de contaseña
        private bool validarCamposPass() 
        {
            bool valido = true;
            try
            {
                limpiarCammpoPass();

                if (contraseniaValida())
                {
                    valido = false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return valido;
        }
        private bool PassCoinciden(string pass1, string pass2)
        {
            return pass1 == pass2;
        }
        private bool contraseniaValida()
        {
            if (string.IsNullOrEmpty(txt_PassNuevo.Text))
            {
                lbl_passNuevo.Text = "Ingrese una contraseña";
                lbl_passNuevo.Visible = true;
                return false;
            }

            if (!contrasenia(txt_PassNuevo.Text))
            {
                lbl_passNuevo.Text = "La contraseña debe tener al menos 8 caracteres, una mayúscula, una minúscula y un dígito";
                lbl_passNuevo.Visible = true;
                return false;
            }
            return true;
        }
        private bool contrasenia(string contraseña)
        {
            // Definimos el formato para la contraseña:
            // - Al menos una letra minúscula
            // - Al menos una letra mayúscula
            // - Al menos un dígito
            // - Longitud mínima de 8 caracteres
            string formato = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$";

            // Utilizamos Regex para validar la contraseña con el formato
            return Regex.IsMatch(contraseña, formato);
        }
        private void limpiarCammpoPass()
        {
            lbl_passNuevo.Visible = lbl_passNuevoConfirmar.Visible = false; 
        }
        protected void MostrarMisTikets(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0; // Mostrar vista de Mis Tikets
            EntradaNegocio entradaNegocio = new EntradaNegocio();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            try
            {
                int idcliente = clienteNegocio.obtenerIdClientePorUsuario((int)Session["IdUsuario"]);
                List<Entrada> listaEntradas = entradaNegocio.entradasporCliente(idcliente);
                rptEntradas.DataSource = listaEntradas;
                rptEntradas.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        protected void MostrarEditarCuenta(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1; // Mostrar vista de Editar Cuenta
        }

        protected void MostrarCambiarContrasena(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2; // Mostrar vista de Cambiar Contraseña
        }

        protected void MostrarEliminarCuenta(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3; // Mostrar vista de Elimiar Cuenta
        }
        
    }
}