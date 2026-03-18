using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsAdmin
{
    public partial class statusTecnicos : Page
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

    	protected Label lblIdArea;

    	protected Label lblNombreArea;

    	protected Label lblTipoArea;

    	protected Button AsignarArea;

    	protected Label lblIdLiberar;

    	protected Label lblNombreLiberar;

    	protected Label lblTipoLiberar;

    	protected Button btnFinalizar;

	protected Label lblIdDisponibilidad;

	protected Label lblNombreDisponibilidad;

	protected Label lblTipoDisponibilidad;

	protected DropDownList ddlDisponibilidad;

	protected TextBox txtFechaRetorno;

	protected Button btnGuardarDisponibilidad;

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
    			// Ejecutar proceso de retorno automático
    			odbusuario.procesarRetornoAutomaticoDisponibilidad();
    			// Cargar GridView
    		GridView1.DataSource = odbusuario.filtroAsignarEstatusTecnico(null, null, 0);
    			GridView1.DataBind();
    		}
    	}

    	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		try
    		{
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
    			if (e.CommandName.Equals("finalizarVacaciones", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr4 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion4 = gvr4.Cells[1].Text.ToString().Trim();
    				Session["cedula"] = eleccion4;
    				string[] datos4 = new string[6];
    				datos4 = odbusuario.infoCuenta(eleccion4);
    				lblIdLiberar.Text = datos4[0];
    				lblNombreLiberar.Text = datos4[1] + " " + datos4[2];
    				lblTipoLiberar.Text = datos4[5];
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModalFinalizarVacaciones()", addScriptTags: true);
    			}
    			if (e.CommandName.Equals("Area", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr5 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion5 = gvr5.Cells[1].Text.ToString().Trim();
    				Session["cedula"] = eleccion5;
    				string[] datos5 = new string[6];
    				datos5 = odbusuario.infoCuenta(eleccion5);
    				lblIdArea.Text = datos5[0];
    				lblNombreArea.Text = datos5[1] + " " + datos5[2];
    				lblTipoArea.Text = datos5[5];
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModalArea()", addScriptTags: true);
    			}
    			if (e.CommandName.Equals("editarDisponibilidad", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr6 = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
    				string eleccion6 = gvr6.Cells[1].Text.ToString().Trim();
    				Session["cedula"] = eleccion6;
    				string[] datos6 = new string[6];
    				datos6 = odbusuario.infoCuenta(eleccion6);
    				lblIdDisponibilidad.Text = datos6[0];
    				lblNombreDisponibilidad.Text = datos6[1] + " " + datos6[2];
    				lblTipoDisponibilidad.Text = datos6[5];
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModalEditarDisponibilidad()", addScriptTags: true);
    			}
    		}
    		catch (Exception)
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "mostrarAlerta('Error al ingresar al proceso', 'danger');", addScriptTags: true);
    		}
    	}

    	protected void btnAsignarPermiso_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		if (odbusuario.darPermisos((string)Session["cedula"]))
    		{
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.muestraAsignarEstatusTecnico();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    			ScriptManager.RegisterStartupScript(this, GetType(), "pop", "mostrarAlerta('Técnico asignado al área exitosamente', 'success');", addScriptTags: true);
    		}
    		else
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "pop", "mostrarAlerta('No se pudo asignar al área', 'danger');", addScriptTags: true);
    		}
    	}

    	protected void btnAsignarArea_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		if (odbusuario.AsignarArea((string)Session["cedula"]))
    		{
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.muestraAsignarEstatusTecnico();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    			ScriptManager.RegisterStartupScript(this, GetType(), "pop", "mostrarAlerta('Técnico asignado al área exitosamente', 'success');", addScriptTags: true);
    		}
    		else
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "pop", "mostrarAlerta('No se pudo asignar al área', 'danger');", addScriptTags: true);
    		}
    	}

    	protected void btnAsignarReserva_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		if (odbusuario.darReserva((string)Session["cedula"]))
    		{
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.muestraAsignarEstatusTecnico();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    		}
    		else
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "pop", "mostrarAlerta('No se pudo completar la asignación de reserva', 'danger');", addScriptTags: true);
    		}
    	}

    	protected void btnAsignarVacacion_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		if (odbusuario.darVacaciones((string)Session["cedula"]))
    		{
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.muestraAsignarEstatusTecnico();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    		}
    		else
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "pop", "mostrarAlerta('No se pudo completar la asignación de vacaciones', 'danger');", addScriptTags: true);
    		}
    	}

    	protected void btnFinalizar_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		if (odbusuario.finalizarVacaciones((string)Session["cedula"]))
    		{
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.muestraAsignarEstatusTecnico();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    		}
    		else
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "pop", "mostrarAlerta('No se pudo finalizar las vacaciones', 'danger');", addScriptTags: true);
    		}
    	}

    	protected void btnGuardarDisponibilidad_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		int idDisponibilidad = Convert.ToInt32(ddlDisponibilidad.SelectedValue);
		DateTime? fechaRetorno = null;
		
		// Solo capturar fecha de retorno para estados temporales: Ocupado(2), Permiso(3), Vacaciones(4), Reserva(5), Trabajo Programado(7), T.Compensatorio(9)
		if ((idDisponibilidad == 2 || idDisponibilidad == 3 || idDisponibilidad == 4 || 
		     idDisponibilidad == 5 || idDisponibilidad == 7 || idDisponibilidad == 9) && !string.IsNullOrEmpty(txtFechaRetorno.Text))
		{
			fechaRetorno = DateTime.Parse(txtFechaRetorno.Text);
		}
		
		if (odbusuario.actualizarDisponibilidad((string)Session["cedula"], idDisponibilidad, fechaRetorno))
		{
			odbusuario = new BaseDatos();
			DataSet ds = odbusuario.muestraAsignarEstatusTecnico();
			GridView1.DataSource = ds.Tables[0];
			GridView1.DataBind();
			
			string mensaje = fechaRetorno.HasValue 
				? "Disponibilidad actualizada. Retorno automático programado para: " + fechaRetorno.Value.ToString("dd/MM/yyyy HH:mm")
				: "Disponibilidad actualizada exitosamente";
			
			ScriptManager.RegisterStartupScript(this, GetType(), "pop", "mostrarAlerta('" + mensaje + "', 'success');", addScriptTags: true);
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
    				DataSet ds = odbusuario.filtroAsignarEstatusTecnico(datos[0], datos[1], Convert.ToInt32(listTipo.Text));
    				GridView1.DataSource = ds.Tables[0];
    				GridView1.DataBind();
    			}
    			else
    			{
    				DataSet ds2 = odbusuario.filtroAsignarEstatusTecnico(datos[0], null, Convert.ToInt32(listTipo.Text));
    				GridView1.DataSource = ds2.Tables[0];
    				GridView1.DataBind();
    			}
    		}
    		else if ((txtNombre.Text != string.Empty) & (listTipo.SelectedIndex == 0))
    		{
    			if ((datos[0] != null) & (datos[1] != string.Empty))
    			{
    				DataSet ds3 = odbusuario.filtroAsignarEstatusTecnico(datos[0], datos[1], Convert.ToInt32(listTipo.Text));
    				GridView1.DataSource = ds3.Tables[0];
    				GridView1.DataBind();
    			}
    			else
    			{
    				DataSet ds4 = odbusuario.filtroAsignarEstatusTecnico(datos[0], null, Convert.ToInt32(listTipo.Text));
    				GridView1.DataSource = ds4.Tables[0];
    				GridView1.DataBind();
    			}
    		}
    		else if ((txtNombre.Text == string.Empty) & (listTipo.SelectedIndex > 0) & (listTipo.SelectedIndex < 7))
    		{
    			DataSet ds5 = odbusuario.filtroAsignarEstatusTecnico(null, null, Convert.ToInt32(listTipo.Text));
    			GridView1.DataSource = ds5.Tables[0];
    			GridView1.DataBind();
    		}
    		else if ((txtNombre.Text == string.Empty) & (listTipo.SelectedIndex == 0))
    		{
    			DataSet ds6 = odbusuario.filtroAsignarEstatusTecnico(null, null, 0);
    			GridView1.DataSource = ds6.Tables[0];
    			GridView1.DataBind();
    		}
    	}
    }

}
