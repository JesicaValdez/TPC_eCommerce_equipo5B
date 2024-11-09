﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo5B
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                calendarioUser.Visible = false;
            }
        }

        protected void selecChangedUser(object sender, EventArgs e)
        {
            txtCalendario.Text = calendarioUser.SelectedDate.ToShortDateString();
        }

        protected void calendarClickUser(object sender, EventArgs e)
        {
            if (calendarioUser.Visible)
            {
                calendarioUser.Visible = false;
            }
            else
            {
                calendarioUser.Visible = true;
            }
        }

        protected void MostrarMisTikets(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0; // Mostrar vista de Mis Tikets
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

        protected void Desconectarse(object sender, EventArgs e)
        {
            
        }
    }
}