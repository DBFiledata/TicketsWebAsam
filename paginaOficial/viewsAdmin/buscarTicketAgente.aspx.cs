using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace paginaOficial.viewsAdmin
{
    public partial class buscarTicketAgente : System.Web.UI.Page
    {
        Controlers.BaseDatos odbusuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (id.Text != string.Empty)
            {
                this.panelInfo.Visible = true;
                odbusuario = new Controlers.BaseDatos();
                DataSet ds = odbusuario.ListaTicketUsuario(id.Text);
                this.listTickets.DataSource = ds.Tables[0];
                this.listTickets.DataBind();
                this.panelBuscar.Visible = false;
                this.btnBuscar.Enabled = false;
            }
            else
            {

            }
        }

        protected void btnfiltrar_Click(object sender, EventArgs e)
        {
            odbusuario = new Controlers.BaseDatos();
            if (id.Text != string.Empty)
            { 
            if ( Convert.ToInt32(listEstado.SelectedIndex) > 0)
            {
                DataSet ds = odbusuario.filtroTicketUsuario(id.Text, Convert.ToInt32(listEstado.Text));
                this.listTickets.DataSource = ds.Tables[0];
                this.listTickets.DataBind();

            }
            else
            {
                DataSet ds = odbusuario.ListaTicketUsuario(id.Text);
                this.listTickets.DataSource = ds.Tables[0];
                this.listTickets.DataBind();
            }
            }
        }
    }
}