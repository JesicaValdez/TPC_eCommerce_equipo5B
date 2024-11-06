using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo5B
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                calendarioFN.Visible = false;
            }

        }

        protected void calendarioSChanged(object sender, EventArgs e) 
        {
            txtCalendarioFN.Text = calendarioFN.SelectedDate.ToShortDateString();
        }

        protected void calendarClick(object sender, EventArgs e) 
        {
            if (calendarioFN.Visible) 
            {
                calendarioFN.Visible = false;
            }
            else
            {
                calendarioFN.Visible = true;
            }
        }

    }
}