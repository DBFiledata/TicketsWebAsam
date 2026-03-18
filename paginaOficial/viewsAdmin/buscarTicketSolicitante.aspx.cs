using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsAdmin
{
    public partial class buscarTicketSolicitante : Page
    {
    	private BaseDatos odbusuario;

    	protected Panel panelBuscar;

    	protected TextBox id;

    	protected Button btnBuscar;

    	protected Panel panelInfo;

    	protected Label Label6;

    	protected DropDownList listEstado;

    	protected Button btnfiltrar;

    	protected GridView listTickets;

    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (!User.Identity.IsAuthenticated)
    		{
    			Response.Redirect("~/Login.aspx");
    		}
    		else if ((string)Session["type"] != "6")
    		{
    			Session.Abandon();
    			Session.Clear();
    			FormsAuthentication.SignOut();
    			Response.Redirect("~/login.aspx");
    		}
    	}

    	protected void btnBuscar_Click(object sender, EventArgs e)
    	{
    		if (id.Text != string.Empty)
    		{
    			panelInfo.Visible = true;
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.ListaTicketSolicitante(id.Text);
    			listTickets.DataSource = ds.Tables[0];
    			listTickets.DataBind();
    			panelBuscar.Visible = false;
    			btnBuscar.Enabled = false;
    		}
    	}

    	protected void btnfiltrar_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		if (id.Text != string.Empty)
    		{
    			if (Convert.ToInt32(listEstado.SelectedIndex) > 0)
    			{
    				DataSet ds = odbusuario.filtroTicketSolicitante(id.Text, Convert.ToInt32(listEstado.Text));
    				listTickets.DataSource = ds.Tables[0];
    				listTickets.DataBind();
    			}
    			else
    			{
    				DataSet ds2 = odbusuario.ListaTicketSolicitante(id.Text);
    				listTickets.DataSource = ds2.Tables[0];
    				listTickets.DataBind();
    			}
    		}
    	}
    }

}
