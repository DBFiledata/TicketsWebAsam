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

namespace paginaOficial.viewsTrabajosProgramados
{
    public partial class crearInstalacion : Page
    {
    	private readonly FirebaseMessaging messaging;

    	private BaseDatos odbusuario;

    	protected ScriptManager ScriptManager1;

    	protected UpdatePanel UpdatePanel1;

    	protected Panel panelInfo;

    	protected Button btnConfirmarReasignacion;

    	protected Label Label8;

    	protected TextBox txtDetallePocicion;

    	protected Label Label2;

    	protected TextBox txtProblema;

    	protected Label Label4;

    	protected TextBox txtfecha;

    	protected Label Label6;

    	protected RadMultiSelect RadMultiSelect1;

    	protected Button btnRegistrar;

    	protected Button btnReasignacion;

    	protected Panel panelResultado;

    	protected Label label5;

    	protected Label lblNum;

    	protected Button btnContinuar;

    	protected Label lblerror;

    	protected Label lblValidadorFecha;

    	protected RequiredFieldValidator RequiredFieldValidatorDetalle;

    	protected ValidationSummary ValidationSummary;

    	public crearInstalacion()
    	{
    		messaging = FirebaseMessaging.GetMessaging(FirebaseApp.DefaultInstance);
    	}

    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (!User.Identity.IsAuthenticated)
    		{
    			Response.Redirect("~/Login.aspx");
    		}
    		else if ((string)Session["type"] != "8")
    		{
    			Session.Abandon();
    			Session.Clear();
    			FormsAuthentication.SignOut();
    			Response.Redirect("~/login.aspx");
    		}
    		else if (Session["ReasicgacionTP"] != null)
    		{
    			odbusuario = new BaseDatos();
    			string[] datos = new string[13];
    			datos = odbusuario.buscarTicketNum((string)Session["ReasicgacionTP"]);
    			if (datos != null)
    			{
    				btnConfirmarReasignacion.Visible = true;
    				btnConfirmarReasignacion.Enabled = true;
    				btnConfirmarReasignacion.ToolTip = "Confirmacion de reasignacion de ticket " + (string)Session["ReasicgacionTP"] + " a instalación ";
    			}
    		}
    		if (!Page.IsPostBack)
    		{
    			DataSet ds = new DataSet();
    			odbusuario = new BaseDatos();
    			ds = odbusuario.tecnicosDisponiblesTrabajosProgramados();
    			RadMultiSelect1.DataSource = ds;
    			RadMultiSelect1.DataBind();
    		}
    	}

    	protected async void btnGenerar_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		int nToken = 0;
    		string tecnicosNToken = "";
    		try
    		{
    			DataSet TiCket = odbusuario.generarTicketsInstalaciones(txtDetallePocicion.Text, txtProblema.Text, User.Identity.Name);
    			int id = Convert.ToInt32(TiCket.Tables[0].Rows[0]["id"]);
    			if (TiCket != null || id == -1)
    			{
    				lblerror.Visible = false;
    				txtDetallePocicion.Text = "";
    				txtProblema.Text = "";
    				txtfecha.Text = "";
    				lblNum.Text = Convert.ToString(id);
    				panelResultado.Visible = true;
    				panelInfo.Visible = false;
    				if (id == -1)
    				{
    					return;
    				}
    				IEnumerable<object> selectedValues = RadMultiSelect1.Value;
    				foreach (string value in selectedValues)
    				{
    					MultiSelectItem selectedItem = RadMultiSelect1.Items.FindChildByValue(value);
    					odbusuario = new BaseDatos();
    					odbusuario.asignarTecnicosInstalaciones(id, selectedItem.Value);
    					_ = new string[8];
    					string[] datos = odbusuario.infoTecnico(selectedItem.Value);
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
    						await messaging.SendAsync(CreateNotification("Hola: " + desc, "Se te ha asignado un nuevo ticket con identificador: " + Convert.ToInt32((string)Session["idticket"]), tokens, data));
    					}
    					catch (Exception)
    					{
    						tecnicosNToken = "  " + idtecnico + "   " + desc + "\n";
    						nToken++;
    					}
    				}
    				RadMultiSelect1.Items.Clear();
    				new DataSet();
    				odbusuario = new BaseDatos();
    				DataSet ds = odbusuario.tecnicosDisponiblesTrabajosProgramados();
    				RadMultiSelect1.DataSource = ds;
    				RadMultiSelect1.DataBind();
    				if (nToken > 0)
    				{
    					ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('El tecnico no cuenta con dispositivo movil vinculado al sistema\n" + tecnicosNToken + "');", addScriptTags: true);
    				}
    			}
    			else
    			{
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('no se pudo generar ticket');", addScriptTags: true);
    			}
    		}
    		catch (Exception ex2)
    		{
    			Exception ex3 = ex2;
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('no se pudo generar ticket\n-Error:\n-" + ex3.Message + "');", addScriptTags: true);
    		}
    	}

    	protected void btnContinuar_Click(object sender, EventArgs e)
    	{
    		lblerror.Visible = false;
    		panelResultado.Visible = false;
    		lblNum.Text = "";
    		RadMultiSelect1.Items.Clear();
    		panelInfo.Visible = true;
    		DataSet ds = new DataSet();
    		odbusuario = new BaseDatos();
    		ds = odbusuario.tecnicosDisponiblesTrabajosProgramados();
    		RadMultiSelect1.DataSource = ds;
    		RadMultiSelect1.DataBind();
    	}

    	protected async void btnReasignacion_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		int nToken = 0;
    		string tecnicosNToken = "";
    		if (odbusuario.ActualizarAInstalacion((string)Session["ReasicgacionTP"], txtDetallePocicion.Text, txtProblema.Text))
    		{
    			odbusuario = new BaseDatos();
    			IEnumerable<object> selectedValues = RadMultiSelect1.Value;
    			int id = Convert.ToInt32((string)Session["ReasicgacionTP"]);
    			foreach (string value in selectedValues)
    			{
    				MultiSelectItem selectedItem = RadMultiSelect1.Items.FindChildByValue(value);
    				odbusuario = new BaseDatos();
    				odbusuario.asignarTecnicosInstalaciones(id, selectedItem.Value);
    				_ = new string[8];
    				string[] datos = odbusuario.infoTecnico(selectedItem.Value);
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
    					await messaging.SendAsync(CreateNotification("Hola: " + desc, "Se te ha asignado un nuevo ticket con identificador: " + Convert.ToInt32((string)Session["idticket"]), tokens, data));
    				}
    				catch (Exception)
    				{
    					tecnicosNToken = "  " + idtecnico + "   " + desc + "\n";
    					nToken++;
    				}
    			}
    			txtDetallePocicion.Text = "";
    			txtProblema.Text = "";
    			RadMultiSelect1.Items.Clear();
    			btnReasignacion.Visible = false;
    			btnReasignacion.Enabled = false;
    			btnConfirmarReasignacion.Visible = false;
    			btnConfirmarReasignacion.Enabled = false;
    			btnRegistrar.Visible = true;
    			lblNum.Text = Convert.ToString(id);
    			panelResultado.Visible = true;
    			panelInfo.Visible = false;
    			Session["ReasicgacionTP"] = null;
    			new DataSet();
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.tecnicosDisponiblesTrabajosProgramados();
    			RadMultiSelect1.DataSource = ds;
    			RadMultiSelect1.DataBind();
    			if (nToken > 0)
    			{
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('El tecnico no cuenta con dispositivo movil vinculado al sistema\n" + tecnicosNToken + "');", addScriptTags: true);
    			}
    		}
    		else
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('no se pudo reasignar segumiento del ticket');", addScriptTags: true);
    		}
    	}

    	protected void btnConfirmarReasignacion_Click(object sender, EventArgs e)
    	{
    		if (Session["ReasicgacionTP"] != null)
    		{
    			odbusuario = new BaseDatos();
    			string[] datos = new string[13];
    			datos = odbusuario.buscarTicketNum((string)Session["ReasicgacionTP"]);
    			if (datos != null)
    			{
    				btnReasignacion.Visible = true;
    				btnReasignacion.Enabled = true;
    				btnReasignacion.ToolTip = "reasignacion de ticket " + datos[0] + " a instalación";
    				btnRegistrar.Visible = false;
    				txtDetallePocicion.Text = datos[11];
    				txtProblema.Text = datos[10];
    			}
    		}
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
