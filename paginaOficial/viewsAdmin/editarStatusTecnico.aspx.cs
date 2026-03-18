using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsAdmin
{
    public partial class editarStatusTecnico : Page
    {
    	private BaseDatos odbusuario;

    	protected Label lblId;

    	protected Label lblNombre;

    	protected Label lblTipo;

    	protected Button btnFinalizar;

    	protected Label Label6;

    	protected DropDownList listTipo;

    	protected Label Label1;

    	protected TextBox txtNombre;

    	protected Button btnfiltrar;

    	protected GridView GridView1;

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
    			DataSet ds = odbusuario.muestraEditarEstatusTecnico();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    		}
    	}

    	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    	{
    		try
    		{
    			odbusuario = new BaseDatos();
    			if (e.CommandName.Equals("finalizarVacaciones", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion = gvr.Cells[1].Text.ToString().Trim();
    				Session["cedula"] = eleccion;
    				string[] datos = new string[6];
    				datos = odbusuario.infoCuenta(eleccion);
    				lblId.Text = datos[0];
    				lblNombre.Text = datos[1] + " " + datos[2];
    				lblTipo.Text = datos[5];
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModalFinalizarVacaciones()", addScriptTags: true);
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
    		if (odbusuario.finalizarVacaciones((string)Session["cedula"]))
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "pop", "alert('Vacaciones finalizadas satisfactoriamente');", addScriptTags: true);
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.muestraEditarEstatusTecnico();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    		}
    		else
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "pop", "alert('Finalizacion de vacaciones no se a podido completar');", addScriptTags: true);
    		}
    	}

    	protected void btnfiltrar_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		string texto = txtNombre.Text + " ";
    		string[] datos = texto.Split(' ');
    		if ((txtNombre.Text != string.Empty) & (listTipo.SelectedIndex > 0) & (listTipo.SelectedIndex < 7))
    		{
    			if ((datos[1] != null) & (datos[1] != string.Empty))
    			{
    				DataSet ds = odbusuario.filtroEditarEstatusTecnico(datos[0], datos[1], Convert.ToInt32(listTipo.Text));
    				GridView1.DataSource = ds.Tables[0];
    				GridView1.DataBind();
    			}
    			else
    			{
    				DataSet ds2 = odbusuario.filtroEditarEstatusTecnico(datos[0], null, Convert.ToInt32(listTipo.Text));
    				GridView1.DataSource = ds2.Tables[0];
    				GridView1.DataBind();
    			}
    		}
    		else if ((txtNombre.Text != string.Empty) & (listTipo.SelectedIndex == 0))
    		{
    			if ((datos[0] != null) & (datos[1] != string.Empty))
    			{
    				DataSet ds3 = odbusuario.filtroEditarEstatusTecnico(datos[0], datos[1], Convert.ToInt32(listTipo.Text));
    				GridView1.DataSource = ds3.Tables[0];
    				GridView1.DataBind();
    			}
    			else
    			{
    				DataSet ds4 = odbusuario.filtroEditarEstatusTecnico(datos[0], null, Convert.ToInt32(listTipo.Text));
    				GridView1.DataSource = ds4.Tables[0];
    				GridView1.DataBind();
    			}
    		}
    		else if ((txtNombre.Text == string.Empty) & (listTipo.SelectedIndex > 0) & (listTipo.SelectedIndex < 7))
    		{
    			DataSet ds5 = odbusuario.filtroEditarEstatusTecnico(null, null, Convert.ToInt32(listTipo.Text));
    			GridView1.DataSource = ds5.Tables[0];
    			GridView1.DataBind();
    		}
    		else if ((txtNombre.Text == string.Empty) & (listTipo.SelectedIndex == 0))
    		{
    			DataSet ds6 = odbusuario.filtroEditarEstatusTecnico(null, null, 0);
    			GridView1.DataSource = ds6.Tables[0];
    			GridView1.DataBind();
    		}
    	}
    }

}
