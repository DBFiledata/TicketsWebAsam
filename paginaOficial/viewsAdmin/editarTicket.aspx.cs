using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using paginaOficial.Controlers;
using Telerik.Web.UI;

namespace paginaOficial.viewsAdmin
{
    public partial class editarTicket : Page
    {
    	private BaseDatos odbusuario;

    	private readonly FirebaseMessaging messaging;

    	protected ScriptManager ScriptManager1;

    	protected Panel panelInfo;

    	protected Label Label6;

    	protected Label lblNumTicket;

    	protected Label Label4;

    	protected Label lblIdSolicitante;

    	protected Label Label9;

    	protected Label lblIdAgente;

    	protected Label Label3;

    	protected Label lblIdTecnico;

    	protected Label Label8;

    	protected TextBox txtDetallePocicion;

    	protected Label Label2;

    	protected TextBox txtProblema;

    	protected Label Label1;

    	protected DropDownList listTipo;

    	protected Label lblArea;

    	protected DropDownList listArea;

    	protected Label lblFechaProgramacion;

    	protected TextBox txtfecha;

    	protected Label lblListTecnico;

    	protected RadMultiSelect RadMultiSelect1;

    	protected Label Label5;

    	protected TextBox txtMotivo;

    	protected Button btnActualizar;

    	protected Button btnCancelar;

    	public editarTicket()
    	{
    		messaging = FirebaseMessaging.GetMessaging(FirebaseApp.DefaultInstance);
    	}

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
    			string[] datos = new string[18];
    			datos = odbusuario.buscarTicketNum((string)Session["TicketNum"]);
    			lblNumTicket.Text = datos[0];
    			lblIdSolicitante.Text = datos[1];
    			lblIdAgente.Text = datos[4];
    			lblIdTecnico.Text = datos[7];
    			txtDetallePocicion.Text = datos[11];
    			txtProblema.Text = datos[10];
    			Session["TicketEstado"] = datos[18];
    			Session["TicketTecnico"] = datos[7];
    			Session["nombreTecnico"] = datos[8] + " " + datos[9];
    			listTipo.ToolTip = "Escoja el estado que desea asignar al ticket\nsi desea asignar el ticket a un nuevo tecnico escoja la opcon creado\nsi no desea cambiar el estado no seleccione opciones en esta casilla\nEl estado actual del ticket es (" + datos[12] + ")";
    		}
    	}

    	protected void listTipoEstadoSelected(object sender, EventArgs e)
    	{
    		if (Convert.ToInt32(listTipo.SelectedValue) == 1)
    		{
    			odbusuario = new BaseDatos();
    			string[] datos = new string[19];
    			datos = odbusuario.buscarTicketNum(lblNumTicket.Text);
    			DataSet ds2 = odbusuario.tecnicosDispinoblesArea(Convert.ToInt32(datos[19]));
    			RadMultiSelect1.DataSource = ds2;
    			listArea.Visible = true;
    			RadMultiSelect1.DataBind();
    			RadMultiSelect1.Enabled = true;
    			RadMultiSelect1.Visible = true;
    			lblListTecnico.Visible = true;
    			lblFechaProgramacion.Visible = false;
    			lblArea.Visible = true;
    			txtfecha.Visible = false;
    		}
    		if (Convert.ToInt32(listTipo.SelectedValue) == 4)
    		{
    			lblFechaProgramacion.Visible = true;
    			txtfecha.Visible = true;
    			listArea.Visible = false;
    			lblListTecnico.Visible = false;
    			RadMultiSelect1.Visible = false;
    			lblArea.Visible = false;
    		}
    		if ((Convert.ToInt32(listTipo.SelectedValue) == 2) | (Convert.ToInt32(listTipo.SelectedValue) == 3))
    		{
    			listArea.Visible = false;
    			listArea.ClearSelection();
    			listTipo.ClearSelection();
    			RadMultiSelect1.Enabled = false;
    			RadMultiSelect1.Visible = false;
    			lblListTecnico.Visible = false;
    			lblFechaProgramacion.Visible = false;
    			lblArea.Visible = false;
    			txtfecha.Visible = false;
    		}
    	}

    	protected void listTipoAreaSelected(object sender, EventArgs e)
    	{
    		if (Convert.ToInt32(listArea.SelectedValue) != 0)
    		{
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.tecnicosDispinoblesArea(Convert.ToInt32(listArea.SelectedValue));
    			RadMultiSelect1.DataSource = ds;
    			RadMultiSelect1.DataBind();
    			RadMultiSelect1.Enabled = true;
    			RadMultiSelect1.Visible = true;
    			lblListTecnico.Visible = true;
    			lblFechaProgramacion.Visible = false;
    			txtfecha.Visible = false;
    			lblArea.Visible = true;
    			txtMotivo.Visible = true;
    		}
    	}

    	protected void listTecnicoSelected(object sender, EventArgs e)
    	{
    		try
    		{
    			txtMotivo.Visible = true;
    		}
    		catch (Exception)
    		{
    		}
    	}

    	protected async void btnActualizar_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		string tecnico = "";
    		IEnumerable<object> selectedValues = RadMultiSelect1.Value;
    		if (listTipo.SelectedValue == "2" || listTipo.SelectedValue == "3" || listTipo.SelectedValue == "5")
    		{
    			if (odbusuario.ActualizarTicket((string)Session["TicketNum"], txtDetallePocicion.Text, txtProblema.Text, Convert.ToInt32(listTipo.SelectedValue), Convert.ToString(Session["TicketTecnico"])))
    			{
    				Response.Redirect("buscarTicketNum.aspx", endResponse: false);
    			}
    			else
    			{
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('No se pudo editar el ticket');", addScriptTags: true);
    			}
    		}
    		else if (txtfecha.Text != string.Empty && listTipo.SelectedValue == "4")
    		{
    			if (odbusuario.ActualizarTicketProgramado((string)Session["TicketNum"], txtDetallePocicion.Text, txtProblema.Text, Convert.ToDateTime(txtfecha.Text)))
    			{
    				Response.Redirect("buscarTicketNum.aspx", endResponse: false);
    			}
    			else
    			{
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('No se pudo editar el ticket');", addScriptTags: true);
    			}
    		}
    		else if (RadMultiSelect1.MaxSelectedItems > 0.0 && listTipo.SelectedValue == "1")
    		{
    			foreach (string value in selectedValues)
    			{
    				MultiSelectItem selectedItem = RadMultiSelect1.Items.FindChildByValue(value);
    				tecnico = selectedItem.Value;
    			}
    			if (txtMotivo.Text != string.Empty)
    			{
    				if (odbusuario.ActualizarTickeCreado((string)Session["TicketNum"], txtDetallePocicion.Text, txtProblema.Text + "---Ticket reasignado de: " + (string)Session["nombreTecnico"], tecnico))
    				{
    					odbusuario.insertCedidos((string)Session["TicketNum"], txtMotivo.Text, (string)Session["TicketTecnico"]);
    					txtMotivo.Visible = false;
    					_ = new string[8];
    					string[] datos = odbusuario.infoTecnico(tecnico);
    					string idtecnico = datos[0];
    					string desc = datos[1];
    					string tokens = datos[2];
    					string pass = datos[3];
    					try
    					{
    						Dictionary<string, string> data = new Dictionary<string, string>
    						{
    							{ "user", idtecnico },
    							{ "pass", pass }
    						};
    						await messaging.SendAsync(CreateNotification("Hola: " + desc, "Se te ha reasignado un nuevo ticket con identificador: " + Convert.ToInt32((string)Session["idticket"]), tokens, data));
    					}
    					catch (Exception)
    					{
    						_ = "  " + idtecnico + "   " + desc + "\n";
    					}
    					Response.Redirect("buscarTicketNum.aspx", endResponse: false);
    				}
    				else
    				{
    					ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('No se pudo editar el ticket');", addScriptTags: true);
    				}
    			}
    			else
    			{
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Indicar motivo de Reasignacion');", addScriptTags: true);
    			}
    		}
    		else if (listTipo.SelectedValue == "0")
    		{
    			if (odbusuario.ActualizarTicket((string)Session["TicketNum"], txtDetallePocicion.Text, txtProblema.Text, Convert.ToInt32(Session["TicketEstado"]), Convert.ToString(Session["TicketTecnico"])))
    			{
    				Response.Redirect("buscarTicketNum.aspx", endResponse: false);
    			}
    			else
    			{
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('No se pudo editar el ticket');", addScriptTags: true);
    			}
    		}
    		else
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('error No se pudo editar el ticket');", addScriptTags: true);
    		}
    	}

    	protected void btnCancelar_Click(object sender, EventArgs e)
    	{
    		Response.Redirect("buscarTicketNum.aspx");
    	}

    	private Message CreateNotification(string title, string notificationBody, string token, Dictionary<string, string> data)
    	{
    		return new Message
    		{
    			Token = token,
    			Notification = new Notification
    			{
    				Body = notificationBody,
    				Title = title
    			},
    			Data = data
    		};
    	}
    }

}
