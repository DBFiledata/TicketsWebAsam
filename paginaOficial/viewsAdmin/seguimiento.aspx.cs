using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsAdmin
{
    public partial class seguimiento : Page
    {
    	private BaseDatos odbusuario;

    	protected Label Label6;

    	protected DropDownList listTipo;

    	protected Label Label1;

    	protected TextBox txtNombre;

    	protected Button btnfiltrar;

    	protected GridView GridView1;

    	protected Label lblIdReasignar;

    	protected Button btnReasignar;

    	protected Label lblIdFinalizar;

    	protected Button btnFinalizar;

    	protected Label lblTecnico;

    	protected Label lblcedulaTecnico;

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
    			DataSet ds = odbusuario.listaTicketSegumiento();
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
    			DataSet ds = odbusuario.filtroTicketSegumiento(Convert.ToInt32(listTipo.Text));
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
    				Session["segimiento"] = eleccion;
    				lblIdFinalizar.Text = eleccion;
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModalFinalizar()", addScriptTags: true);
    			}
    			if (e.CommandName.Equals("reasignar", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr2 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion2 = gvr2.Cells[1].Text.ToString().Trim();
    				Session["segimiento"] = eleccion2;
    				lblIdReasignar.Text = eleccion2;
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModalReasignar()", addScriptTags: true);
    			}
    		}
    		catch (Exception)
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Erorr al ingresar al proceso');", addScriptTags: true);
    		}
    	}

    	protected void btnReasignar_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		try
    		{
    			DataSet TiCket = odbusuario.reasignarTicketSeguimiento(Convert.ToInt32((string)Session["segimiento"]));
    			string desc = Convert.ToString(TiCket.Tables[2].Rows[0]["descr"]);
    			string[] datos = new string[6];
    			datos = odbusuario.infoCuenta(desc);
    			string nombreTecnico = datos[1] + " " + datos[2];
    			if (TiCket != null || desc != null)
    			{
    				lblTecnico.Text = nombreTecnico;
    				lblcedulaTecnico.Text = "Cedula: " + desc;
    				odbusuario = new BaseDatos();
    				DataSet ds = odbusuario.listaTicketSegumiento();
    				GridView1.DataSource = ds.Tables[0];
    				GridView1.DataBind();
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModalmodalReasignacion()", addScriptTags: true);
    			}
    			else
    			{
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('no se pudo reasignar el ticket');", addScriptTags: true);
    			}
    		}
    		catch (Exception ex)
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('no se pudo reasignar el ticket\n-Error:\n-" + ex.Message + "');", addScriptTags: true);
    		}
    	}

    	protected void btnFinalizar_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		if (odbusuario.cerrarTicket(Convert.ToInt32((string)Session["segimiento"]), ""))
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('se finalizo el ticket satisfactoriamente');", addScriptTags: true);
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.listaTicketSegumiento();
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
