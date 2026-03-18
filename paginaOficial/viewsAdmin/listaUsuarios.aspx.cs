using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsAdmin
{
    public partial class listaUsuarios : Page
    {
    	private BaseDatos odbusuario;

    	protected Label Label6;

    	protected DropDownList listTipo;

    	protected Label Label1;

    	protected TextBox txtNombre;

    	protected Button btnfiltrar;

    	protected GridView GridView1;

    	protected Label Label11;

    	protected Label lblIdInfo;

    	protected Label Label13;

    	protected Label lblNombreInfo;

    	protected Label Label19;

    	protected Label lblEmailInfo;

    	protected Label Label21;

    	protected Label lblTelefonoInfo;

    	protected Label Label25;

    	protected Label lblTipoInfo;

    	protected Label Label2;

    	protected TextBox txtIdEditar;

    	protected Label Label4;

    	protected TextBox txtNombreEditar;

    	protected Label Label3;

    	protected TextBox txtApellidoEditar;

    	protected Label Label9;

    	protected TextBox txtEmailEditar;

    	protected Label Label12;

    	protected TextBox txtTelefonoEditar;

    	protected Label Label5;

    	protected DropDownList listTipoEditar;

    	protected Button btnEditar;

    	protected Label lblerror;

    	protected Label lblIdEliminar;

    	protected Label lblNombreEliminar;

    	protected Button btnEiminaruenta;

    	protected Button btnCancelar;

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
    			DataSet ds = odbusuario.ListaTotal();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    		}
    	}

    	protected void btnfiltrar_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		string texto = txtNombre.Text + " ";
    		string[] datos = texto.Split(' ');
    		if ((txtNombre.Text != string.Empty) & (listTipo.SelectedIndex > 0) & (listTipo.SelectedIndex < 9))
    		{
    			if ((datos[1] != null) & (datos[1] != string.Empty))
    			{
    				DataSet ds = odbusuario.filtroUsuario(datos[0], datos[1], Convert.ToInt32(listTipo.Text));
    				GridView1.DataSource = ds.Tables[0];
    				GridView1.DataBind();
    			}
    			else
    			{
    				DataSet ds2 = odbusuario.filtroUsuario(datos[0], null, Convert.ToInt32(listTipo.Text));
    				GridView1.DataSource = ds2.Tables[0];
    				GridView1.DataBind();
    			}
    		}
    		else if ((txtNombre.Text != string.Empty) & (listTipo.SelectedIndex == 0))
    		{
    			if ((datos[0] != null) & (datos[1] != string.Empty))
    			{
    				DataSet ds3 = odbusuario.filtroUsuario(datos[0], datos[1], Convert.ToInt32(listTipo.Text));
    				GridView1.DataSource = ds3.Tables[0];
    				GridView1.DataBind();
    			}
    			else
    			{
    				DataSet ds4 = odbusuario.filtroUsuario(datos[0], null, Convert.ToInt32(listTipo.Text));
    				GridView1.DataSource = ds4.Tables[0];
    				GridView1.DataBind();
    			}
    		}
    		else if ((txtNombre.Text == string.Empty) & (listTipo.SelectedIndex > 0) & (listTipo.SelectedIndex < 9))
    		{
    			DataSet ds5 = odbusuario.filtroUsuario(null, null, Convert.ToInt32(listTipo.Text));
    			GridView1.DataSource = ds5.Tables[0];
    			GridView1.DataBind();
    		}
    		else if ((txtNombre.Text == string.Empty) & (listTipo.SelectedIndex == 0))
    		{
    			DataSet ds6 = odbusuario.filtroUsuario(null, null, 0);
    			GridView1.DataSource = ds6.Tables[0];
    			GridView1.DataBind();
    		}
    	}

    	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    	{
    		try
    		{
    			odbusuario = new BaseDatos();
    			if (e.CommandName.Equals("info", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion = gvr.Cells[1].Text.ToString().Trim();
    				Session["cedula"] = eleccion;
    				string[] datos = new string[6];
    				datos = odbusuario.infoCuenta(eleccion);
    				lblIdInfo.Text = datos[0];
    				lblNombreInfo.Text = datos[1] + " " + datos[2];
    				lblEmailInfo.Text = datos[3];
    				lblTelefonoInfo.Text = datos[4];
    				lblTipoInfo.Text = datos[5];
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModalInfo()", addScriptTags: true);
    			}
    			if (e.CommandName.Equals("editar", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr2 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion2 = gvr2.Cells[1].Text.ToString().Trim();
    				Session["cedula"] = eleccion2;
    				string[] datos2 = new string[6];
    				datos2 = odbusuario.infoCuenta(eleccion2);
    				txtIdEditar.Text = datos2[0];
    				txtNombreEditar.Text = datos2[1];
    				txtApellidoEditar.Text = datos2[2];
    				txtEmailEditar.Text = datos2[3];
    				txtTelefonoEditar.Text = datos2[4];
    				listTipoEditar.ClearSelection();
    				listTipoEditar.Items.FindByValue(datos2[6]).Selected = true;
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModalEditar()", addScriptTags: true);
    			}
    			if (e.CommandName.Equals("eliminar", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr3 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion3 = gvr3.Cells[1].Text.ToString().Trim();
    				Session["cedula"] = eleccion3;
    				string[] datos3 = new string[6];
    				datos3 = odbusuario.infoCuenta(eleccion3);
    				lblIdEliminar.Text = datos3[0];
    				lblNombreEliminar.Text = datos3[1] + " " + datos3[2];
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModalEliminar()", addScriptTags: true);
    			}
    		}
    		catch (Exception)
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Erorr al ingresar al proceso');", addScriptTags: true);
    		}
    	}

    	protected void btnEiminaruenta_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		if (odbusuario.EliminarUsuario((string)Session["cedula"]))
    		{
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.ListaTotal();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('usuario eliminado satisfactoriamente');", addScriptTags: true);
    		}
    		else
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('no se pudo eliminar al usuario');", addScriptTags: true);
    		}
    	}

    	protected void btnEditar_Click(object sender, EventArgs e)
    	{
    		lblerror.Visible = false;
    		odbusuario = new BaseDatos();
    		if (odbusuario.ActualizarUsuario((string)Session["cedula"], txtIdEditar.Text, txtNombreEditar.Text, txtApellidoEditar.Text, txtEmailEditar.Text, txtTelefonoEditar.Text, Convert.ToInt32(listTipoEditar.SelectedValue)))
    		{
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.ListaTotal();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    			ScriptManager.RegisterStartupScript(this, GetType(), "pop", "alert('usuario actualizado satisfactoriamente');", addScriptTags: true);
    		}
    		else
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "pop", "alert('la actualizacion no se a podido completar');", addScriptTags: true);
    		}
    	}
    }

}
