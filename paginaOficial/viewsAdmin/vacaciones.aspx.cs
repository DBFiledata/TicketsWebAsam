using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsAdmin
{
    public partial class vacaciones : Page
    {
    	private BaseDatos odbusuario;

    	protected Label lblIdPermiso;

    	protected Label lblNombrePermiso;

    	protected Label lblTipoPermiso;

    	protected Button Button1;

    	protected Label lblIdReserva;

    	protected Label lblNombreReserva;

    	protected Label lblTipoReserva;

    	protected Button Button2;

    	protected Label lblIdVacaciones;

    	protected Label lblNombreVacaciones;

    	protected Label lblTipo;

    	protected Button btnAsignar;

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
    			DataSet ds = odbusuario.ListaSinVacaciones();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    		}
    	}

    	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    	{
    		try
    		{
    			odbusuario = new BaseDatos();
    			if (e.CommandName.Equals("permisos", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion = gvr.Cells[1].Text.ToString().Trim();
    				Session["cedula"] = eleccion;
    				string[] datos = new string[6];
    				datos = odbusuario.infoCuenta(eleccion);
    				lblIdPermiso.Text = datos[0];
    				lblNombrePermiso.Text = datos[1] + " " + datos[2];
    				lblTipoPermiso.Text = datos[5];
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModalPermisos()", addScriptTags: true);
    			}
    			if (e.CommandName.Equals("reservas", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr2 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion2 = gvr2.Cells[1].Text.ToString().Trim();
    				Session["cedula"] = eleccion2;
    				string[] datos2 = new string[6];
    				datos2 = odbusuario.infoCuenta(eleccion2);
    				lblIdReserva.Text = datos2[0];
    				lblNombreReserva.Text = datos2[1] + " " + datos2[2];
    				lblTipoReserva.Text = datos2[5];
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModalReservas()", addScriptTags: true);
    			}
    			if (e.CommandName.Equals("vacaciones", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr3 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion3 = gvr3.Cells[1].Text.ToString().Trim();
    				Session["cedula"] = eleccion3;
    				string[] datos3 = new string[6];
    				datos3 = odbusuario.infoCuenta(eleccion3);
    				lblIdVacaciones.Text = datos3[0];
    				lblNombreVacaciones.Text = datos3[1] + " " + datos3[2];
    				lblTipo.Text = datos3[5];
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModalVacaciones()", addScriptTags: true);
    			}
    		}
    		catch (Exception)
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Erorr al ingresar al proceso');", addScriptTags: true);
    		}
    	}

    	protected void btnAsignarPermiso_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		if (odbusuario.darPermisos((string)Session["cedula"]))
    		{
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.ListaSinPermiso();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    			ScriptManager.RegisterStartupScript(this, GetType(), "pop", "alert('Permiso asignado satisfactoriamente');", addScriptTags: true);
    		}
    		else
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "pop", "alert('asignacion de permiso no se a podido completar');", addScriptTags: true);
    		}
    	}

    	protected void btnAsignarReserva_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		if (odbusuario.darReserva((string)Session["cedula"]))
    		{
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.ListaSinReserva();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    			ScriptManager.RegisterStartupScript(this, GetType(), "pop", "alert('El usuario fue asignado a Reserva satisfactoriamente');", addScriptTags: true);
    		}
    		else
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "pop", "alert('asignacion de Reserva no se a podido completar');", addScriptTags: true);
    		}
    	}

    	protected void btnAsignarVacacion_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		if (odbusuario.darVacaciones((string)Session["cedula"]))
    		{
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.ListaSinVacaciones();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    			ScriptManager.RegisterStartupScript(this, GetType(), "pop", "alert('Vacaciones asignadas satisfactoriamente');", addScriptTags: true);
    		}
    		else
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "pop", "alert('asignacion de vacaciones no se a podido completar');", addScriptTags: true);
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
    				DataSet ds = odbusuario.filtroSinVacaciones(datos[0], datos[1], Convert.ToInt32(listTipo.Text));
    				GridView1.DataSource = ds.Tables[0];
    				GridView1.DataBind();
    			}
    			else
    			{
    				DataSet ds2 = odbusuario.filtroSinVacaciones(datos[0], null, Convert.ToInt32(listTipo.Text));
    				GridView1.DataSource = ds2.Tables[0];
    				GridView1.DataBind();
    			}
    		}
    		else if ((txtNombre.Text != string.Empty) & (listTipo.SelectedIndex == 0))
    		{
    			if ((datos[0] != null) & (datos[1] != string.Empty))
    			{
    				DataSet ds3 = odbusuario.filtroSinVacaciones(datos[0], datos[1], Convert.ToInt32(listTipo.Text));
    				GridView1.DataSource = ds3.Tables[0];
    				GridView1.DataBind();
    			}
    			else
    			{
    				DataSet ds4 = odbusuario.filtroSinVacaciones(datos[0], null, Convert.ToInt32(listTipo.Text));
    				GridView1.DataSource = ds4.Tables[0];
    				GridView1.DataBind();
    			}
    		}
    		else if ((txtNombre.Text == string.Empty) & (listTipo.SelectedIndex > 0) & (listTipo.SelectedIndex < 7))
    		{
    			DataSet ds5 = odbusuario.filtroSinVacaciones(null, null, Convert.ToInt32(listTipo.Text));
    			GridView1.DataSource = ds5.Tables[0];
    			GridView1.DataBind();
    		}
    		else if ((txtNombre.Text == string.Empty) & (listTipo.SelectedIndex == 0))
    		{
    			DataSet ds6 = odbusuario.filtroSinVacaciones(null, null, 0);
    			GridView1.DataSource = ds6.Tables[0];
    			GridView1.DataBind();
    		}
    	}
    }

}
