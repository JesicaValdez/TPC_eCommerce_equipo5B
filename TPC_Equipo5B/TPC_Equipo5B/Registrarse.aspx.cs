using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_Equipo5B
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_clickRegistro(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocioU = new UsuarioNegocio();
                ClienteNegocio negocioC = new ClienteNegocio();

                if (validarRegistroVacio())
                {
                    return;
                }

                if (AceptarTerminos())
                {
                    lbl_Chek.Visible = false;

                    bool dniEncontrado = negocioC.DniExistente(txtdni.Text);

                    if (dniEncontrado)
                    {
                        lbl_Dni.Text = "El DNI ingresado ya se encuentra en uso";
                        lbl_Dni.Visible = true;
                        return;
                    }

                    bool userEcontrado = negocioU.UsuarioExistente(txtUser.Text);

                    if (userEcontrado)
                    {
                        lbl_Usuario.Text = "El Usuario ingresado ya se encuentra en uso";
                        lbl_Usuario.Visible = true;
                        return;
                    }

                    Dominio.Usuario nuevoUsuario = new Dominio.Usuario
                    {
                        NombreUsuario = txtUser.Text,
                        Email = txtEmail.Text,
                        Pass = txtPass.Text
                    };

                    int idUsuario = negocioU.agregarUsuario(nuevoUsuario);

                    Cliente nuevoCliente = new Cliente
                    {
                        Dni = txtdni.Text,
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        fechaNacimiento = Convert.ToDateTime(txtCalendarioFN.Text),
                        Telefono = txtTelefono.Text,
                    };

                    negocioC.agregarCliente(nuevoCliente, idUsuario);
                }
                else
                {
                    lbl_Chek.Text = "Debe aceptar terminos y condiciones";
                    lbl_Chek.Visible = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool validarRegistroVacio()
        {
            bool valido = true;
            try
            {
                limpiar();
                //validar dni
                if (dniValido())
                {
                    valido = false;
                }

                //validar nombre
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    lbl_Nombre.Text = "ingrese nombre";
                    lbl_Nombre.Visible = true;
                    valido = false;
                }

                //validar apellido
                if (string.IsNullOrEmpty(txtApellido.Text))
                {
                    lbl_Apellido.Text = "ingrese apellido";
                    lbl_Apellido.Visible = true;
                    valido = false;
                }

                //validar fecha de naciemiento
                if (string.IsNullOrEmpty(txtCalendarioFN.Text))
                {
                    lbl_FechaN.Text = "ingrese fecha de nacimiento";
                    lbl_FechaN.Visible = true;
                    valido = false;
                }

                //validar telefono
                if (string.IsNullOrEmpty(txtTelefono.Text))
                {
                    lbl_tel.Text = "ingrese numero de telefono";
                    lbl_tel.Visible = true;
                    valido = false;
                }

                //validar email
                if (!emailValido())
                {
                    valido = false;
                }

                //validar usuario
                if (string.IsNullOrEmpty(txtUser.Text))
                {
                    lbl_Usuario.Text = "ingrese un usuario";
                    lbl_Usuario.Visible = true;
                    valido = false;
                }

                //validar contaseña
                if (contraseniaValida())
                {
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
            if (string.IsNullOrEmpty(txtdni.Text))
            {
                lbl_Dni.Text = "Ingrese un DNI";
                lbl_Dni.Visible = true;
                return false;
            }
            if (txtdni.Text.Length != 8 || !txtdni.Text.All(char.IsDigit))
            {
                lbl_Dni.Text = "Ingrese un DNI válido (8 dígitos)";
                lbl_Dni.Visible = true;
                return false;
            }
            return true;
        }

        private bool emailValido()
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                lbl_Email.Text = "Ingrese un email";
                lbl_Email.Visible = true;
                return false;
            }
            if (!email(txtEmail.Text))
            {
                lbl_Email.Text = "Ingrese un email válido";
                lbl_Email.Visible = true;
                return false;
            }
            return true;
        }

        private bool contraseniaValida()
        {
            if (string.IsNullOrEmpty(txtPass.Text))
            {
                lbl_Pass.Text = "Ingrese una contraseña";
                lbl_Pass.Visible = true;
                return false;
            }
            if (!contrasenia(txtPass.Text))
            {
                lbl_Pass.Text = "La contraseña debe tener al menos 8 caracteres, una mayúscula, una minúscula y un dígito";
                lbl_Pass.Visible = true;
                return false;
            }
            return true;
        }


        private bool email(string email)
        {
            // Expresión regular para un correo electrónico válido
            string formato = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            // Utilizamos Regex.IsMatch para verificar si el email cumple con el formato
            return Regex.IsMatch(email, formato);
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

        private bool AceptarTerminos()
        {
            if (checkCondiciones.Checked == true)
            {
                return true;
            }           
                
            return false;            
        }

        private void limpiar()
        {
            lbl_Dni.Visible = lbl_Nombre.Visible = lbl_Apellido.Visible = lbl_FechaN.Visible =
            lbl_tel.Visible = lbl_Email.Visible = lbl_Usuario.Visible = lbl_Pass.Visible = false;
        }
    }
}