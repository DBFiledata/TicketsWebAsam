using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsAdmin
{
    public partial class liberarTicketProgramado : Page
    {
    	private BaseDatos odbusuario;

    	protected Label Label6;

    	protected Label lblNumTicket;

    	protected Label Label9;

    	protected Label lblIdSolicitante;

    	protected Label Label11;

    	protected Label lblNombreSolicitante;

    	protected Label Label5;

    	protected TextBox txtProblema;

    	protected Label Label7;

    	protected TextBox txtDescripcion;

    	protected Label Label3;

    	protected Label lblfecha;

    	protected Label lblIdLiberar;

    	protected Label Label4;

    	protected DropDownList ListTipo;

    	protected Button btnConfirmar;

    	protected Button btnCancelar;

    	protected Label lblIdLiberado;

    	protected Label lblTecnico;

    	protected GridView listTicket;

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
    			DataSet ds = odbusuario.liberarTicketLista();
    			listTicket.DataSource = ds.Tables[0];
    			listTicket.DataBind();
    		}
    	}

    	protected void listTicket_RowCommand(object sender, GridViewCommandEventArgs e)
    	{
    		try
    		{
    			odbusuario = new BaseDatos();
    			if (e.CommandName.Equals("info", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion = gvr.Cells[1].Text.ToString().Trim();
    				Session["idticket"] = eleccion;
    				string[] datos = new string[13];
    				datos = odbusuario.buscarTicketNum(eleccion);
    				lblNumTicket.Text = datos[0];
    				lblIdSolicitante.Text = datos[1];
    				lblNombreSolicitante.Text = datos[2] + " " + datos[3];
    				txtProblema.Text = datos[10];
    				txtDescripcion.Text = datos[11];
    				lblfecha.Text = datos[16];
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModalInfo()", addScriptTags: true);
    			}
    			if (e.CommandName.Equals("liberar", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr2 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion2 = gvr2.Cells[1].Text.ToString().Trim();
    				Session["idticket"] = eleccion2;
    				string[] datos2 = new string[13];
    				datos2 = odbusuario.buscarTicketNum(eleccion2);
    				lblIdLiberar.Text = datos2[0];
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModalLiberarTicket()", addScriptTags: true);
    			}
    		}
    		catch (Exception)
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Erorr al ingresar al proceso');", addScriptTags: true);
    		}
    	}

    	protected void btnConfirmar_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		DataSet TiCket = odbusuario.liberarTicketProgramado(Convert.ToInt32((string)Session["idticket"]), Convert.ToInt32(ListTipo.SelectedValue));
    		string id = Convert.ToString(TiCket.Tables[1].Rows[0]["id"]);
    		string desc = Convert.ToString(TiCket.Tables[1].Rows[0]["descr"]);
    		if (TiCket != null || id == "-1")
    		{
    			lblIdLiberado.Text = Convert.ToString((string)Session["idticket"]);
    			lblTecnico.Text = id + " " + desc;
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.liberarTicketLista();
    			listTicket.DataSource = ds.Tables[0];
    			listTicket.DataBind();
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModalResultadoTicket()", addScriptTags: true);
    			ListTipo.ClearSelection();
    		}
    		else
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('no se pudo liberar el ticket');", addScriptTags: true);
    		}
    	}
    }

}
