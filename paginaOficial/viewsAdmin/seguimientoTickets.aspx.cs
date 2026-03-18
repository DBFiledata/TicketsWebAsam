using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsAdmin
{
    public partial class seguimientoTickets : Page
    {
    	private BaseDatos odbusuario;

    	protected ScriptManager ScriptManager1;

    	protected UpdatePanel UpdatePanel1;

    	protected Label Label6;

    	protected DropDownList listEstado;

    	protected DropDownList DropDownList1;

    	protected DropDownList list;

    	protected DropDownList niij;

    	protected DropDownList listAreas;

    	protected Label Label7;

    	protected TextBox txtDesde;

    	protected Label Label8;

    	protected TextBox TxtHasta;

    	protected Button Button1;

    	protected Button btnReporte;

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
    		else if (!Page.IsPostBack)
    		{
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.listatickets();
    			listTickets.DataSource = ds.Tables[0];
    			listTickets.DataBind();
    		}
    	}

    	protected void btnfiltrar_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		if ((listEstado.SelectedIndex > 0) & (listEstado.SelectedIndex < 6))
    		{
    			DataSet ds = odbusuario.filtroTicketUsuario(User.Identity.Name, Convert.ToInt32(listEstado.Text));
    			listTickets.DataSource = ds.Tables[0];
    			listTickets.DataBind();
    		}
    		else
    		{
    			odbusuario = new BaseDatos();
    			DataSet ds2 = odbusuario.ListaTicketUsuario(User.Identity.Name);
    			listTickets.DataSource = ds2.Tables[0];
    			listTickets.DataBind();
    		}
    	}
    }

}
