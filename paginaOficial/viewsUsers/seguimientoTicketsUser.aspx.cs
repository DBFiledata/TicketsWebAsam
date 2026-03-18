using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsUsers
{
    public partial class seguimientoTicketsUser : Page
    {
    	private BaseDatos odbusuario;

    	protected ScriptManager ScriptManager1;

    	protected UpdatePanel UpdatePanel1;

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
    		else if ((string)Session["type"] != "5")
    		{
    			Session.Abandon();
    			Session.Clear();
    			FormsAuthentication.SignOut();
    			Response.Redirect("~/login.aspx");
    		}
    		else if (!Page.IsPostBack)
    		{
    			CargarTickets();
    		}
    	}

    	private void CargarTickets()
    	{
    		odbusuario = new BaseDatos();
    		DataSet ds = odbusuario.ListaTicketUsuario(User.Identity.Name);
    		if (ds != null && ds.Tables.Count > 0)
    		{
    			listTickets.DataSource = ds.Tables[0];
    			listTickets.DataBind();
    		}
    	}

    	protected void btnfiltrar_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		if ((listEstado.SelectedIndex > 0) & (listEstado.SelectedIndex < 5))
    		{
    			DataSet ds = odbusuario.filtroTicketUsuario(User.Identity.Name, Convert.ToInt32(listEstado.Text));
    			if (ds != null && ds.Tables.Count > 0)
    			{
    				listTickets.DataSource = ds.Tables[0];
    				listTickets.DataBind();
    			}
    		}
    		else
    		{
    			CargarTickets();
    		}
    	}

    	protected void listTickets_PageIndexChanging(object sender, GridViewPageEventArgs e)
    	{
    		listTickets.PageIndex = e.NewPageIndex;
    		btnfiltrar_Click(null, null);
    	}
    }
}
