using System;
using System.Data;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsUsers
{
    public partial class seguimientoGeneralTicketsUser : Page
    {
    	private BaseDatos odbusuario;

    	protected ScriptManager ScriptManager1;

    	protected UpdatePanel UpdatePanel1;

    	protected Label Label6;

    	protected DropDownList listEstado;

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
    		DataSet ds = odbusuario.listatickets();
    		if (ds != null && ds.Tables.Count > 0)
    		{
    			listTickets.DataSource = ds.Tables[0];
    			listTickets.DataBind();
    		}
    	}

    	protected void btnfiltrar_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		int estado = (((listEstado.SelectedIndex > 0) & (listEstado.SelectedIndex < 9)) ? Convert.ToInt32(listEstado.SelectedValue) : 0);
    		int area = (((listAreas.SelectedIndex > 0) & (listAreas.SelectedIndex < 9)) ? Convert.ToInt32(listAreas.SelectedValue) : 0);
    		string desde = ((!(txtDesde.Text != string.Empty)) ? "0000-00-00" : txtDesde.Text);
    		string hasta = ((!(TxtHasta.Text != string.Empty)) ? "0000-00-00" : TxtHasta.Text);
    		DataSet ds = odbusuario.filtrolistaTicket(estado, area, desde, hasta);
    		if (ds != null && ds.Tables.Count > 0)
    		{
    			listTickets.DataSource = ds.Tables[0];
    			listTickets.DataBind();
    		}
    	}

    	protected void btnReporte_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		int estado = (((listEstado.SelectedIndex > 0) & (listEstado.SelectedIndex < 9)) ? Convert.ToInt32(listEstado.SelectedValue) : 0);
    		int area = (((listAreas.SelectedIndex > 0) & (listAreas.SelectedIndex < 9)) ? Convert.ToInt32(listAreas.SelectedValue) : 0);
    		string desde = ((!(txtDesde.Text != string.Empty)) ? "0000-00-00" : txtDesde.Text);
    		string hasta = ((!(TxtHasta.Text != string.Empty)) ? "0000-00-00" : TxtHasta.Text);
    		DataSet ds = odbusuario.filtrolistaTicket(estado, area, desde, hasta);
    		GridView grid = new GridView();
    		grid.DataSource = ds.Tables[0];
    		grid.DataBind();
    		Response.ClearContent();
    		Response.AddHeader("content-disposition", "attachment; filename=reporte.xls" + DateTime.Now.ToString("dd-MM-yy hh-mm-ss"));
    		Response.ContentType = "application/exel";
    		StringWriter sw = new StringWriter();
    		HtmlTextWriter htw = new HtmlTextWriter(sw);
    		grid.RenderControl(htw);
    		Response.Write(sw.ToString());
    		Response.End();
    	}

    	protected void listTickets_PageIndexChanging(object sender, GridViewPageEventArgs e)
    	{
    		listTickets.PageIndex = e.NewPageIndex;
    		btnfiltrar_Click(null, null);
    	}
    }
}
