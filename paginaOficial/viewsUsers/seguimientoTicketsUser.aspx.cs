using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace paginaOficial.viewsUsers
{
    public partial class seguimientoTicketsUser : System.Web.UI.Page
    {
        Controlers.BaseDatos odbusuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                odbusuario = new Controlers.BaseDatos();
                DataSet ds = odbusuario.ListaTicketUsuario(User.Identity.Name);
                this.listTickets.DataSource = ds.Tables[0];
                this.listTickets.DataBind();
            }
            else
            {

            }

        }
        
        protected void btnfiltrar_Click(object sender, EventArgs e)
        {
            odbusuario = new Controlers.BaseDatos();
            if (listEstado.SelectedIndex > 0 & listEstado.SelectedIndex < 6)
            {
                DataSet ds = odbusuario.filtroTicketUsuario(User.Identity.Name, Convert.ToInt32(listEstado.Text));
                this.listTickets.DataSource = ds.Tables[0];
                this.listTickets.DataBind();

            }
            else
            {
                odbusuario = new Controlers.BaseDatos();
                DataSet ds = odbusuario.ListaTicketUsuario(User.Identity.Name);
                this.listTickets.DataSource = ds.Tables[0];
                this.listTickets.DataBind();
            }
        }
    }
}