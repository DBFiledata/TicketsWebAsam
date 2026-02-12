using System;
using System.Data;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsTecnicos
{
    public partial class registros : Page
    {
    	private BaseDatos odbusuario;

    	protected ScriptManager ScriptManager1;

    	protected UpdatePanel UpdatePanel1;

    	protected Label Label6;

    	protected DropDownList listEstado;

    	protected Label Label1;

    	protected TextBox txtSolicitanteNombres;

    	protected Label Label2;

    	protected TextBox txtSolicitanteApellidos;

    	protected Label Label7;

    	protected TextBox txtDesde;

    	protected Label Label8;

    	protected TextBox TxtHasta;

    	protected Button Button1;

    	protected GridView listTickets;

    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (!User.Identity.IsAuthenticated)
    		{
    			Response.Redirect("~/Login.aspx");
    		}
    		else if (((string)Session["type"] != "1") & ((string)Session["type"] != "2") & ((string)Session["type"] != "3") & ((string)Session["type"] != "4") & ((string)Session["type"] != "9") & ((string)Session["type"] != "10"))
    		{
    			Session.Abandon();
    			Session.Clear();
    			FormsAuthentication.SignOut();
    			Response.Redirect("~/login.aspx");
    		}
    		else if (!Page.IsPostBack)
    		{
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.listaTicketTecnico2((string)Session["id"]);
    			listTickets.DataSource = ds.Tables[0];
    			listTickets.DataBind();
    		}
    	}

    	protected void btnfiltrar_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		int estado = (((listEstado.SelectedIndex > 0) & (listEstado.SelectedIndex < 9)) ? Convert.ToInt32(listEstado.SelectedValue) : 0);
    		string nombre = ((!(txtSolicitanteNombres.Text != string.Empty)) ? "" : txtSolicitanteNombres.Text);
    		string apellido = ((!(txtSolicitanteApellidos.Text != string.Empty)) ? "" : txtSolicitanteApellidos.Text);
    		string desde = ((!(txtDesde.Text != string.Empty)) ? "0000-00-00" : txtDesde.Text);
    		string hasta = ((!(TxtHasta.Text != string.Empty)) ? "0000-00-00" : TxtHasta.Text);
    		DataSet ds = odbusuario.filtroTicketTecnico2(estado, nombre, apellido, desde, hasta);
    		listTickets.DataSource = ds.Tables[0];
    		listTickets.DataBind();
    	}

    	protected void btnReporte_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		int estado = (((listEstado.SelectedIndex > 0) & (listEstado.SelectedIndex < 9)) ? Convert.ToInt32(listEstado.SelectedValue) : 0);
    		string nombre = ((!(txtSolicitanteNombres.Text != string.Empty)) ? "" : txtSolicitanteNombres.Text);
    		string apellido = ((!(txtSolicitanteApellidos.Text != string.Empty)) ? "" : txtSolicitanteApellidos.Text);
    		string desde = ((!(txtDesde.Text != string.Empty)) ? "0000-00-00" : txtDesde.Text);
    		string hasta = ((!(TxtHasta.Text != string.Empty)) ? "0000-00-00" : TxtHasta.Text);
    		DataSet ds = odbusuario.filtroTicketTecnico2(estado, nombre, apellido, desde, hasta);
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
    		listTickets.DataSource = ds.Tables[0];
    		listTickets.DataBind();
    	}

    	protected void listTickets_PageIndexChanging(object sender, GridViewPageEventArgs e)
    	{
    		listTickets.PageIndex = e.NewPageIndex;
    		btnfiltrar_Click(null, null);
    	}
    }

}
