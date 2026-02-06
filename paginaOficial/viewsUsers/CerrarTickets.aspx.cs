using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using paginaOficial.Controlers;
using Telerik.Web.UI;

namespace paginaOficial.viewsUsers
{
    public partial class CerrarTickets : Page
    {
    	private BaseDatos odbusuario;

    	protected ScriptManager ScriptManager1;

    	protected UpdatePanel UpdatePanel1;

    	protected HiddenField HiddenField1;

    	protected ModalPopupExtender mpe;

    	protected HiddenField HiddenField2;

    	protected ModalPopupExtender mpeRevision;

    	protected HiddenField HiddenField3;

    	protected ModalPopupExtender mpeSeguimiento;

    	protected HiddenField HiddenField4;

    	protected ModalPopupExtender mpeReasignar;

    	protected HiddenField HiddenField5;

    	protected ModalPopupExtender mpeReasignado;

    	protected Timer Timer1;

    	protected Panel Panel1;

    	protected Button btnClose;

    	protected Label lblIdFinalizar;

    	protected Label Label1;

    	protected TextBox txtComent;

    	protected Button btnConfirmar;

    	protected Panel Panel2;

    	protected Button btnCloseRevision;

    	protected Label lblIdRevision;

    	protected Label Label2;

    	protected TextBox txtRevision;

    	protected Button btnConfirmarRevision;

    	protected Panel Panel3;

    	protected Button btnCloseSeguimiento;

    	protected Label lblIdSeguimiento;

    	protected Label Label3;

    	protected TextBox txtSegumiento;

    	protected Button btnConfirmarSegumiento;

    	protected Panel Panel4;

    	protected Button btnCloseReasignar;

    	protected Label lblIdReasignar;

    	protected Label Label4;

    	protected TextBox txtMotivoReasignacion;

    	protected RadMultiSelect RadMultiSelect1;

    	protected Button btnReasignar;

    	protected Panel Panel5;

    	protected Button btnCloseReasignado;

    	protected Label lblTecnico;

    	protected Label lblcedulaTecnico;

    	protected HiddenField HiddenField6;

    	protected ModalPopupExtender mpeReasignarArea;

    	protected Panel Panel6;

    	protected Button btnCloseReasignarArea;

    	protected Label lblIdReasignarArea;

    	protected Label Label5;

    	protected DropDownList ddlNuevaArea;

    	protected Label Label6;

    	protected TextBox txtMotivoReasignacionArea;

    	protected Button btnConfirmarReasignarArea;

    	protected GridView GridView1;

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
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.ListaTicketSinCierre();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    		}
    		else
    		{
    			Timer1.Enabled = true;
    		}
    	}

    	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    	{
    		try
    		{
    			odbusuario = new BaseDatos();
    			if (e.CommandName.Equals("cerrarTicket", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion = gvr.Cells[1].Text.ToString().Trim();
    				Session["idticket"] = eleccion;
    				string[] datos = new string[13];
    				datos = odbusuario.buscarTicketNum(eleccion);
    				lblIdFinalizar.Text = datos[0];
    				mpe.Show();
    				Timer1.Enabled = false;
    			}
    			if (e.CommandName.Equals("revisionTicket", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr2 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion2 = gvr2.Cells[1].Text.ToString().Trim();
    				Session["idticket"] = eleccion2;
    				string[] datos2 = new string[13];
    				datos2 = odbusuario.buscarTicketNum(eleccion2);
    				lblIdRevision.Text = datos2[0];
    				mpeRevision.Show();
    				Timer1.Enabled = false;
    			}
    			if (e.CommandName.Equals("seguimientoTicket", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr3 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion3 = gvr3.Cells[1].Text.ToString().Trim();
    				Session["idticket"] = eleccion3;
    				string[] datos3 = new string[13];
    				datos3 = odbusuario.buscarTicketNum(eleccion3);
    				lblIdSeguimiento.Text = datos3[0];
    				mpeSeguimiento.Show();
    				Timer1.Enabled = false;
    			}
    			if (e.CommandName.Equals("reasignar", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr4 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion4 = gvr4.Cells[1].Text.ToString().Trim();
    				Session["idticket"] = eleccion4;
    				lblIdReasignar.Text = eleccion4;
    				mpeReasignar.Show();
    				Timer1.Enabled = false;
    				odbusuario = new BaseDatos();
    				string[] datos4 = new string[19];
    				datos4 = odbusuario.buscarTicketNum(eleccion4);
    				DataSet ds = odbusuario.tecnicosDispinoblesArea(Convert.ToInt32(datos4[19]));
    				RadMultiSelect1.DataSource = ds;
    				RadMultiSelect1.DataBind();
    			}
    			if (e.CommandName.Equals("reasignarArea", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr5 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion5 = gvr5.Cells[1].Text.ToString().Trim();
    				Session["idticket"] = eleccion5;
    				Session["idTicketReasignarArea"] = eleccion5;
    				lblIdReasignarArea.Text = eleccion5;
    				ddlNuevaArea.SelectedIndex = 0;
    				txtMotivoReasignacionArea.Text = "";
    				mpeReasignarArea.Show();
    				Timer1.Enabled = false;
    			}
    		}
    		catch (Exception)
    		{
    		ScriptManager.RegisterStartupScript(this, GetType(), "alertaError",
    			"mostrarAlerta('danger', 'Error al ingresar al proceso');", addScriptTags: true);
    	}
    }

    	protected void btnConfirmar_Click(object sender, EventArgs e)
    	{
    		mpe.Hide();
    		string coment = ((!(txtComent.Text != string.Empty)) ? "" : ("--Comentario de cierre: " + txtComent.Text));
    		odbusuario = new BaseDatos();
    		if (odbusuario.cerrarTicket(Convert.ToInt32((string)Session["idticket"]), coment))
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('se cerro el ticket satisfactoriamente');", addScriptTags: true);
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.ListaTicketSinCierre();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    		}
    		else
    		{
    			odbusuario = new BaseDatos();
    			DataSet ds2 = odbusuario.ListaTicketSinCierre();
    			GridView1.DataSource = ds2.Tables[0];
    			GridView1.DataBind();
    		}
    	}

    	protected void btnConfirmarRevision_Click(object sender, EventArgs e)
    	{
    		if (!string.IsNullOrEmpty(txtRevision.Text))
    		{
    			mpeRevision.Hide();
    			odbusuario = new BaseDatos();
    			if (odbusuario.asignarRevisionTickets(Convert.ToInt32((string)Session["idticket"]), txtRevision.Text))
    			{
    			ScriptManager.RegisterStartupScript(this, GetType(), "alertaExito",
    				"mostrarAlerta('success', 'Revisión asignada exitosamente');", addScriptTags: true);
    				odbusuario = new BaseDatos();
    				DataSet ds = odbusuario.ListaTicketSinCierre();
    				GridView1.DataSource = ds.Tables[0];
    				GridView1.DataBind();
    			}
    			else
    			{
    				ScriptManager.RegisterStartupScript(this, GetType(), "alertaError",
    				 "mostrarAlerta('danger', 'No se pudo asignar la revisión del ticket');", addScriptTags: true);
    			}
    		}
    		else
    		{
    		ScriptManager.RegisterStartupScript(this, GetType(), "alertaWarning",
    			"mostrarAlerta('warning', 'Debe indicar el motivo de la revisión');", addScriptTags: true);
    	}
    }

    	protected void btnConfirmarSegumiento_Click(object sender, EventArgs e)
    	{
    		if (!string.IsNullOrEmpty(txtSegumiento.Text))
    		{
    			mpeRevision.Hide();
    			odbusuario = new BaseDatos();
    			if (odbusuario.asignarSegumientoTickets(Convert.ToInt32((string)Session["idticket"]), txtSegumiento.Text))
    			{
    			ScriptManager.RegisterStartupScript(this, GetType(), "alertaExito",
    				"mostrarAlerta('success', 'Seguimiento asignado exitosamente');", addScriptTags: true);
    				odbusuario = new BaseDatos();
    				DataSet ds = odbusuario.ListaTicketSinCierre();
    				GridView1.DataSource = ds.Tables[0];
    				GridView1.DataBind();
    			}
    			else
    			{
    			ScriptManager.RegisterStartupScript(this, GetType(), "alertaError",
    				"mostrarAlerta('danger', 'No se pudo asignar el seguimiento del ticket');", addScriptTags: true);
    		}
    	}
    	else
    	{
    		ScriptManager.RegisterStartupScript(this, GetType(), "alertaWarning",
    			"mostrarAlerta('warning', 'Debe indicar el motivo del seguimiento');", addScriptTags: true);
    	}
    }

    protected void btnReasignar_Click(object sender, EventArgs e)
    {
    		odbusuario = new BaseDatos();
    		string tecnico = "";
    		IEnumerable<object> selectedValues = RadMultiSelect1.Value;
    		try
    		{
    			if (!string.IsNullOrEmpty(txtMotivoReasignacion.Text) && RadMultiSelect1.MaxSelectedItems > 0.0)
    			{
    				foreach (string value in selectedValues)
    				{
    					MultiSelectItem selectedItem = RadMultiSelect1.Items.FindChildByValue(value);
    					tecnico = selectedItem.Value;
    				}
    				DataSet TiCket = odbusuario.reasignarTicket(Convert.ToInt32((string)Session["idticket"]), txtMotivoReasignacion.Text, tecnico);
    				odbusuario = new BaseDatos();
    				DataSet ds = odbusuario.ListaTicketSinCierre();
    				GridView1.DataSource = ds.Tables[0];
    				GridView1.DataBind();
    				mpeReasignar.Hide();
    				Timer1.Enabled = false;
    			ScriptManager.RegisterStartupScript(this, GetType(), "alertaExito",
    				"mostrarAlerta('success', 'Ticket reasignado exitosamente al nuevo técnico');", addScriptTags: true);
    		}
    		else
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "alertaWarning",
    				"mostrarAlerta('warning', 'Debe indicar el motivo de reasignación y seleccionar un técnico');", addScriptTags: true);
    		}
    	}
    	catch (Exception ex)
    	{
    		ScriptManager.RegisterStartupScript(this, GetType(), "alertaError",
    			$"mostrarAlerta('danger', 'No se pudo reasignar el ticket. Error: {ex.Message}');", addScriptTags: true);
    	}
    }

    protected void btnConfirmarReasignarArea_Click(object sender, EventArgs e)
    {
    	try
    		{
    			if (ddlNuevaArea.SelectedIndex == 0)
    			{
    			ScriptManager.RegisterStartupScript(this, GetType(), "alertaWarning",
    				"mostrarAlerta('warning', 'Debe seleccionar un área de destino');", addScriptTags: true);
    				mpeReasignarArea.Show();
    				return;
    			}

    			if (string.IsNullOrWhiteSpace(txtMotivoReasignacionArea.Text))
    			{
    			ScriptManager.RegisterStartupScript(this, GetType(), "alertaWarning",
    				"mostrarAlerta('warning', 'Debe ingresar el motivo de la reasignación');", addScriptTags: true);
    				mpeReasignarArea.Show();
    				return;
    			}

    			int idTicket = Convert.ToInt32(Session["idTicketReasignarArea"]);
    			int nuevaArea = Convert.ToInt32(ddlNuevaArea.SelectedValue);
    			string motivo = txtMotivoReasignacionArea.Text.Trim();

    			odbusuario = new BaseDatos();
    			DataSet resultado = odbusuario.reasignarTicketArea(idTicket, nuevaArea, motivo, User.Identity.Name);

    			// Buscar la tabla que contiene la columna "Exito" (el SP devuelve múltiples tablas)
    			DataTable tablaResultado = null;
    			if (resultado != null && resultado.Tables.Count > 0)
    			{
    				foreach (DataTable tabla in resultado.Tables)
    				{
    					if (tabla.Columns.Contains("Exito"))
    					{
    						tablaResultado = tabla;
    						break;
    					}
    				}
    			}

    			if (tablaResultado != null && tablaResultado.Rows.Count > 0)
    			{
    				DataRow row = tablaResultado.Rows[0];
    				int exito = Convert.ToInt32(row["Exito"]);
    				string mensaje = row["Mensaje"].ToString();

    				if (exito == 1)
    				{
    					string nombreTecnico = row["NombreTecnico"]?.ToString() ?? "asignado";
    					mpeReasignarArea.Hide();
					ScriptManager.RegisterStartupScript(this, GetType(), "alertaExito",
						$"mostrarAlerta('success', 'Ticket reasignado exitosamente. Nuevo técnico: {nombreTecnico}');", addScriptTags: true);
    					odbusuario = new BaseDatos();
    					DataSet ds = odbusuario.ListaTicketSinCierre();
    					GridView1.DataSource = ds.Tables[0];
    					GridView1.DataBind();
    				}
    				else
    				{
    				ScriptManager.RegisterStartupScript(this, GetType(), "alertaDanger",
    					$"mostrarAlerta('danger', '{mensaje}');", addScriptTags: true);
    				}
    			}
    			else
    			{
    				// Si no hay tabla con "Exito", asumimos éxito ya que los datos sí llegan a la BD
    				mpeReasignarArea.Hide();
				ScriptManager.RegisterStartupScript(this, GetType(), "alertaExito",
					"mostrarAlerta('success', 'Ticket reasignado exitosamente');", addScriptTags: true);
    				GridView1.DataBind();
    			}
    		}
    		catch (Exception ex)
    		{
    			System.Diagnostics.Debug.WriteLine("Error en reasignación de área: " + ex.Message);
    			ScriptManager.RegisterStartupScript(this, GetType(), "alertaError",
    				$"mostrarAlerta('danger', 'Error interno al procesar la reasignación de área: {ex.Message}');", addScriptTags: true);
    		}
    	}

    	protected void Timer1_Tick(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		DataSet ds = odbusuario.ListaTicketSinCierre();
    		GridView1.DataSource = ds.Tables[0];
    		GridView1.DataBind();
    	}

    	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    	{
    		if (e.Row.RowType == DataControlRowType.DataRow)
    		{
    			if (e.Row.Cells[8].Text == "Atendido")
    			{
    				Button Button1 = (Button)e.Row.FindControl("Button1");
    				Button1.Visible = true;
    				e.Row.BackColor = Color.Green;
    			}
    			else
    			{
    				Button Button1 = (Button)e.Row.FindControl("Button1");
    				Button1.Visible = false;
    			}
    		}
    	}
    }

}
