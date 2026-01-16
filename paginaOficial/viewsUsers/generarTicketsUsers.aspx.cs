using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using paginaOficial.Controlers;

namespace paginaOficial.viewsCompartidas
{
    public partial class generarTicketsUsers : Page
    {
    	private readonly FirebaseMessaging messaging;

    	private BaseDatos odbusuario;

    	private Mailer mailer;

    	protected ScriptManager ScriptManager1;

    	protected UpdatePanel UpdatePanel1;

    	protected Panel panelBuscar;

    	protected Label Label9;

    	protected TextBox txtIdSolicitante;

    	protected Button btnSolicitanteNuevo;

    	protected Button btnBuscarInfo;

    	protected Panel panelInfo;

    	protected Label Label11;

    	protected TextBox txtNombre;

    	protected Label Label12;

    	protected TextBox txtApellido;

    	protected Label Label1;

    	protected TextBox txtDepartamento;

    	protected Label Label3;

    	protected TextBox txtEmail;

    	protected Label Label7;

    	protected TextBox txtTelefono;

    	protected Label Label8;

    	protected TextBox txtDetallePocicion;

    	protected Label Label2;

    	protected TextBox txtProblema;

    	protected CheckBox checkFechaProgramacion;

    	protected Label Label4;

    	protected TextBox txtfecha;

    	protected Label Label6;

    	protected DropDownList ListTipo;

    	protected CheckBox CheckArea;

    	protected Button btnRegistrar;

    	protected Button btnCancelar;

    	protected Panel panelResultado;

    	protected Label label5;

    	protected Label lblNum;

    	protected Label lblresultado;

    	protected Label lblTecnico;

    	protected Button btnContinuar;

    	protected Label lblerror;

    	protected Label lblValidadorFecha;

    	protected RequiredFieldValidator RequiredFieldValidatorId;

    	protected ValidationSummary ValidationSummary;

    	public generarTicketsUsers()
    	{
    		messaging = FirebaseMessaging.GetMessaging(FirebaseApp.DefaultInstance);
    	}

    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (!User.Identity.IsAuthenticated)
    		{
    			Response.Redirect("~/Login.aspx");
    		}
    		else if (Session["solicitanteNuevo"] != null)
    		{
    			odbusuario = new BaseDatos();
    			string[] datos = new string[6];
    			datos = odbusuario.infoSolicitante((string)Session["solicitanteNuevo"]);
    			if (datos != null)
    			{
    				btnSolicitanteNuevo.Visible = true;
    				btnSolicitanteNuevo.Enabled = true;
    				btnSolicitanteNuevo.ToolTip = "si desea ingresar el ultimo solicitante creado presione este boton\nEl ultimo solicitante creado fue:\n " + datos[0] + "\n " + datos[1] + " " + datos[2];
    			}
    		}
    	}

    	protected void btnSolicitanteNuevo_Click(object sender, EventArgs e)
    	{
    		txtIdSolicitante.Text = (string)Session["solicitanteNuevo"];
    		btnSolicitanteNuevo.Visible = false;
    		btnSolicitanteNuevo.Enabled = false;
    		Session["solicitanteNuevo"] = null;
    	}

    	protected void btnBuscarInfo_Click(object sender, EventArgs e)
    	{
    		lblerror.Visible = false;
    		txtNombre.Text = "";
    		txtApellido.Text = "";
    		txtDepartamento.Text = "";
    		txtEmail.Text = "";
    		txtTelefono.Text = "";
    		txtDetallePocicion.Text = "";
    		txtProblema.Text = "";
    		checkFechaProgramacion.Checked = false;
    		txtfecha.Text = "";
    		ListTipo.ClearSelection();
    		odbusuario = new BaseDatos();
    		string[] datos = new string[6];
    		datos = odbusuario.infoSolicitante(txtIdSolicitante.Text);
    		int ocurrencias = 0;
    		ocurrencias = txtIdSolicitante.Text.Split('-').Length - 1;
    		if (datos != null)
    		{
    			panelInfo.Visible = true;
    			txtNombre.Text = datos[1];
    			txtApellido.Text = datos[2];
    			txtDepartamento.Text = datos[3];
    			txtEmail.Text = datos[4];
    			txtTelefono.Text = datos[5];
    		}
    		else if (ocurrencias == 2)
    		{
    			odbusuario = new BaseDatos();
    			datos = odbusuario.infoSolicitantePadron(txtIdSolicitante.Text);
    			if (datos != null)
    			{
    				panelInfo.Visible = true;
    				txtNombre.Text = datos[0];
    				txtApellido.Text = datos[1];
    			}
    			else
    			{
    				panelInfo.Visible = true;
    			}
    		}
    		else
    		{
    			panelInfo.Visible = true;
    		}
    	}

    	protected async void btnGenerar_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		try
    		{
    			DataSet TiCket;
    			int id;
    			string desc;
    			if (checkFechaProgramacion.Checked)
    			{
    				TiCket = odbusuario.generarTicketProgramado(txtDetallePocicion.Text, txtProblema.Text, txtIdSolicitante.Text, User.Identity.Name, Convert.ToDateTime(txtfecha.Text), txtNombre.Text, txtApellido.Text, txtDepartamento.Text, txtEmail.Text, txtTelefono.Text);
    				id = Convert.ToInt32(TiCket.Tables[2].Rows[0]["id"]);
    				desc = "ticket programado para el " + txtfecha.Text;
    				if (checkFechaProgramacion.Checked & (txtfecha.Text != string.Empty))
    				{
    					panelBuscar.Visible = false;
    					panelInfo.Visible = false;
    					txtNombre.Text = "";
    					txtApellido.Text = "";
    					txtDepartamento.Text = "";
    					txtEmail.Text = "";
    					txtTelefono.Text = "";
    					txtDetallePocicion.Text = "";
    					txtProblema.Text = "";
    					checkFechaProgramacion.Checked = false;
    					txtIdSolicitante.Text = "";
    					txtfecha.Text = "";
    					ListTipo.ClearSelection();
    					lblNum.Text = Convert.ToString(id);
    					lblTecnico.Text = desc;
    					panelResultado.Visible = true;
    				}
    				else
    				{
    					ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('no se pudo generar ticket<br/>-verifique que los datos entan ingresados correctamente<br/>-verifique si tiene fecha de programacion seleccionada');", addScriptTags: true);
    				}
    			}
    			if (CheckArea.Checked)
    			{
    				TiCket = odbusuario.crearTicketsArea(txtDetallePocicion.Text, txtProblema.Text, txtIdSolicitante.Text, User.Identity.Name, ListTipo.SelectedValue, txtNombre.Text, txtApellido.Text, txtDepartamento.Text, txtEmail.Text, txtTelefono.Text);
    				id = Convert.ToInt32(TiCket.Tables[2].Rows[0]["id"]);
    				desc = Convert.ToString(TiCket.Tables[2].Rows[0]["descr"]);
    				Convert.ToString(TiCket.Tables[2].Rows[0]["tokens"]);
    				if (TiCket != null || id == -1)
    				{
    					lblerror.Visible = false;
    					panelBuscar.Visible = false;
    					panelInfo.Visible = false;
    					txtNombre.Text = "";
    					txtApellido.Text = "";
    					txtDepartamento.Text = "";
    					txtEmail.Text = "";
    					txtTelefono.Text = "";
    					txtDetallePocicion.Text = "";
    					txtProblema.Text = "";
    					checkFechaProgramacion.Checked = false;
    					txtIdSolicitante.Text = "";
    					txtfecha.Text = "";
    					ListTipo.ClearSelection();
    					lblNum.Text = Convert.ToString(id);
    					lblTecnico.Text = desc;
    					panelResultado.Visible = true;
    					if (id != -1)
    					{
    						try
    						{
    							return;
    						}
    						catch (Exception)
    						{
    							ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('El tecnico no cuenta con dispositivo movil vinculado al sistema\n!No le podra llegar notificacion de asignacion de ticket!');", addScriptTags: true);
    							return;
    						}
    					}
    				}
    				else
    				{
    					ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('no se pudo generar ticket');", addScriptTags: true);
    				}
    				return;
    			}
    			TiCket = odbusuario.generarTicket(txtDetallePocicion.Text, txtProblema.Text, txtIdSolicitante.Text, User.Identity.Name, ListTipo.SelectedValue, txtNombre.Text, txtApellido.Text, txtDepartamento.Text, txtEmail.Text, txtTelefono.Text);
    			id = Convert.ToInt32(TiCket.Tables[2].Rows[0]["id"]);
    			desc = Convert.ToString(TiCket.Tables[2].Rows[0]["descr"]);
    			Convert.ToString(TiCket.Tables[2].Rows[0]["tokens"]);
    			if (TiCket != null || id == -1)
    			{
    				lblerror.Visible = false;
    				panelBuscar.Visible = false;
    				panelInfo.Visible = false;
    				txtNombre.Text = "";
    				txtApellido.Text = "";
    				txtDepartamento.Text = "";
    				txtEmail.Text = "";
    				txtTelefono.Text = "";
    				txtDetallePocicion.Text = "";
    				checkFechaProgramacion.Checked = false;
    				txtProblema.Text = "";
    				txtIdSolicitante.Text = "";
    				txtfecha.Text = "";
    				ListTipo.ClearSelection();
    				lblNum.Text = Convert.ToString(id);
    				lblTecnico.Text = desc;
    				panelResultado.Visible = true;
    				odbusuario = new BaseDatos();
    				_ = new string[8];
    				string[] datos = odbusuario.infoTicketMail(Convert.ToString(id));
    				mailer = new Mailer();
    				mailer.Notify(datos[2], id, datos[1], datos[3], (string)Session["username"], datos[5], datos[6], datos[7], 1);
    				if (id != -1)
    				{
    					try
    					{
    					}
    					catch (Exception)
    					{
    						ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('El tecnico no cuenta con dispositivo movil vinculado al sistema\n!No le podra llegar notificacion de asignacion de ticket!');", addScriptTags: true);
    					}
    				}
    			}
    			else
    			{
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('no se pudo generar ticket');", addScriptTags: true);
    			}
    		}
    		catch (Exception ex3)
    		{
    			Exception ex4 = ex3;
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('no se pudo generar ticket\n-Error:\n-" + ex4.Message + "');", addScriptTags: true);
    		}
    	}

    	protected void btnCancelar_Click(object sender, EventArgs e)
    	{
    		lblerror.Visible = false;
    		panelInfo.Visible = false;
    		txtNombre.Text = "";
    		txtApellido.Text = "";
    		txtDepartamento.Text = "";
    		txtEmail.Text = "";
    		txtTelefono.Text = "";
    		txtDetallePocicion.Text = "";
    		txtProblema.Text = "";
    		checkFechaProgramacion.Checked = false;
    		txtIdSolicitante.Text = "";
    		txtfecha.Text = "";
    		ListTipo.ClearSelection();
    	}

    	protected void btnContinuar_Click(object sender, EventArgs e)
    	{
    		lblerror.Visible = false;
    		panelResultado.Visible = false;
    		lblNum.Text = "";
    		lblTecnico.Text = "";
    		panelBuscar.Visible = true;
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
