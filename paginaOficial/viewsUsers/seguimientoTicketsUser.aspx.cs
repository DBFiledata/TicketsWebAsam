using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using paginaOficial.Controlers;

namespace paginaOficial.viewsUsers
{
    public partial class seguimientoTicketsUser : Page
    {
    	private BaseDatos odbusuario;

    	protected ScriptManager ScriptManager1;

    	protected UpdatePanel UpdatePanel1;

    	protected Label Label6;

    	protected DropDownList listEstado;

    	protected Button btnfiltrar;

    	protected GridView listTickets;

    	// Controles para el modal de reasignación
    	protected HiddenField hfReasignar;
    	protected ModalPopupExtender mpeReasignar;
    	protected Panel pnlReasignar;
    	protected Button btnCloseReasignar;
    	protected Label lblIdTicketReasignar;
    	protected DropDownList ddlNuevaArea;
    	protected TextBox txtMotivoReasignacion;
    	protected Button btnConfirmarReasignacion;

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
    		DataSet ds = odbusuario.ListaTicketUsuario(User.Identity.Name);
    		if (ds != null && ds.Tables.Count > 0)
    		{
    			listTickets.DataSource = ds.Tables[0];
    			listTickets.DataBind();
    		}
    	}

    	protected void btnfiltrar_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		if ((listEstado.SelectedIndex > 0) & (listEstado.SelectedIndex < 5))
    		{
    			DataSet ds = odbusuario.filtroTicketUsuario(User.Identity.Name, Convert.ToInt32(listEstado.Text));
    			if (ds != null && ds.Tables.Count > 0)
    			{
    				listTickets.DataSource = ds.Tables[0];
    				listTickets.DataBind();
    			}
    		}
    		else
    		{
    			CargarTickets();
    		}
    	}

    	protected void listTickets_PageIndexChanging(object sender, GridViewPageEventArgs e)
    	{
    		listTickets.PageIndex = e.NewPageIndex;
    		btnfiltrar_Click(null, null);
    	}

    	protected void listTickets_RowCommand(object sender, GridViewCommandEventArgs e)
    	{
    		if (e.CommandName == "reasignarArea")
    		{
    			string idTicket = e.CommandArgument.ToString();
    			lblIdTicketReasignar.Text = idTicket;
    			Session["idTicketReasignar"] = idTicket;
    			
    			// Limpiar campos del modal
    			ddlNuevaArea.SelectedIndex = 0;
    			txtMotivoReasignacion.Text = "";
    			
    			// Mostrar el modal
    			mpeReasignar.Show();
    		}
    	}

    	protected void btnConfirmarReasignacion_Click(object sender, EventArgs e)
    	{
    		try
    		{
    			if (ddlNuevaArea.SelectedIndex == 0)
    			{
    				ScriptManager.RegisterStartupScript(this, GetType(), "alertaError",
    					"mostrarAlerta('warning', 'Debe seleccionar un área de destino');", true);
    				mpeReasignar.Show();
    				return;
    			}

    			if (string.IsNullOrWhiteSpace(txtMotivoReasignacion.Text))
    			{
    				ScriptManager.RegisterStartupScript(this, GetType(), "alertaError",
    					"mostrarAlerta('warning', 'Debe ingresar el motivo de la reasignación');", true);
    				mpeReasignar.Show();
    				return;
    			}

    			int idTicket = Convert.ToInt32(Session["idTicketReasignar"]);
    			int nuevaArea = Convert.ToInt32(ddlNuevaArea.SelectedValue);
    			string motivo = txtMotivoReasignacion.Text.Trim();

    			odbusuario = new BaseDatos();
    			DataSet resultado = odbusuario.reasignarTicketArea(idTicket, nuevaArea, motivo, User.Identity.Name);

    			if (resultado != null && resultado.Tables.Count > 0 && resultado.Tables[0].Rows.Count > 0)
    			{
    				DataRow row = resultado.Tables[0].Rows[0];
    				int exito = Convert.ToInt32(row["Exito"]);
    				string mensaje = row["Mensaje"].ToString();

    				if (exito == 1)
    				{
    					string nombreTecnico = row["NombreTecnico"].ToString();
    					ScriptManager.RegisterStartupScript(this, GetType(), "alertaExito",
    						$"mostrarAlerta('success', 'Ticket reasignado exitosamente. Nuevo técnico: {nombreTecnico}');", true);
    					
    					// Recargar la lista de tickets
    					CargarTickets();
    				}
    				else
    				{
    					ScriptManager.RegisterStartupScript(this, GetType(), "alertaError",
    						$"mostrarAlerta('danger', '{mensaje}');", true);
    				}
    			}
    			else
    			{
    				ScriptManager.RegisterStartupScript(this, GetType(), "alertaError",
    					"mostrarAlerta('danger', 'Error al procesar la reasignación');", true);
    			}
    		}
    		catch (Exception ex)
    		{
    			System.Diagnostics.Debug.WriteLine("Error en reasignación: " + ex.Message);
    			ScriptManager.RegisterStartupScript(this, GetType(), "alertaError",
    				"mostrarAlerta('danger', 'Error interno al procesar la reasignación');", true);
    		}
    	}
    }

}
