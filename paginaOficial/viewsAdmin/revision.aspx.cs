using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsAdmin
{
    public partial class revision : Page
    {
    	private BaseDatos odbusuario;

    	protected Label Label6;

    	protected DropDownList listTipo;

    	protected Label Label1;

    	protected TextBox txtNombre;

    	protected Button btnfiltrar;

    	protected GridView GridView1;

    	protected Label lblIdFinalizar;

    	protected Button btnFinalizar;

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
    			DataSet ds = odbusuario.listaTicketsRevision();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    		}
    	}

    	protected void btnfiltrar_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		string texto = txtNombre.Text + " ";
    		string[] datos = texto.Split(' ');
    		if ((listTipo.SelectedIndex >= 0) & (listTipo.SelectedIndex <= 4))
    		{
    			DataSet ds = odbusuario.filtroTicketRevision(Convert.ToInt32(listTipo.Text));
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    		}
    		else
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Escoja el area del ticket');", addScriptTags: true);
    		}
    	}

    	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    	{
    		try
    		{
    			odbusuario = new BaseDatos();
    			if (e.CommandName.Equals("finalizar", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion = gvr.Cells[1].Text.ToString().Trim();
    				Session["revision"] = eleccion;
    				lblIdFinalizar.Text = eleccion;
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModalFinalizar()", addScriptTags: true);
    			}
    		}
    		catch (Exception)
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Erorr al ingresar al proceso');", addScriptTags: true);
    		}
    	}

    	protected void btnFinalizar_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		if (odbusuario.cerrarTicket(Convert.ToInt32((string)Session["revision"]), ""))
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('se finalizo el ticket satisfactoriamente');", addScriptTags: true);
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.listaTicketsRevision();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    		}
    		else
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('no se pudo finalizar el ticket');", addScriptTags: true);
    		}
    	}
    }

}
