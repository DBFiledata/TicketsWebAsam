using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using paginaOficial.Controlers;
using Telerik.Web.UI;

namespace paginaOficial.viewsTrabajosProgramados
{
    public partial class administrarTProgramado : Page
    {
    	private readonly FirebaseMessaging messaging;

    	private BaseDatos odbusuario;

    	protected ScriptManager ScriptManager1;

    	protected UpdatePanel UpdatePanel1;

    	protected HiddenField HiddenField1;

    	protected ModalPopupExtender mpe;

    	protected HiddenField HiddenField2;

    	protected ModalPopupExtender mpeTecnicos;

    	protected HiddenField HiddenField3;

    	protected ModalPopupExtender mpeFinalizar;

    	protected HiddenField HiddenField4;

    	protected ModalPopupExtender mpeEditarTecnicos;

    	protected Timer Timer1;

    	protected Panel Panel1;

    	protected Button btnClose;

    	protected Label lblIdEliminar;

    	protected Button btnEliminar;

    	protected Panel Panel2;

    	protected Button btnCloseTecnicos;

    	protected GridView GridViewTecnicos;

    	protected Button btnEditarTecnicos;

    	protected Panel Panel3;

    	protected Button btnCloseFinalizar;

    	protected Label lblIdFinalizar;

    	protected Button btnFinalizar;

    	protected Panel Panel4;

    	protected Button btnCloseEditarTecnicos;

    	protected RadMultiSelect RadMultiSelect1;

    	protected Button btnConfirmarTecnicos;

    	protected GridView GridView1;

    	public administrarTProgramado()
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
    		else if (!Page.IsPostBack)
    		{
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.listaTrabajosProgramados();
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
    			if (e.CommandName.Equals("eliminar", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion = gvr.Cells[1].Text.ToString().Trim();
    				Session["idticket"] = eleccion;
    				string[] datos = new string[13];
    				datos = odbusuario.buscarTicketNum(eleccion);
    				lblIdEliminar.Text = datos[0];
    				mpe.Show();
    				Timer1.Enabled = false;
    			}
    			if (e.CommandName.Equals("TecicosTrabajosProgrmados", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr2 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion2 = gvr2.Cells[1].Text.ToString().Trim();
    				Session["idticket"] = eleccion2;
    				odbusuario = new BaseDatos();
    				DataSet ds = odbusuario.TecnicosAsignadosTrabajosProgramados(Convert.ToInt32(eleccion2));
    				GridViewTecnicos.DataSource = ds.Tables[0];
    				GridViewTecnicos.DataBind();
    				mpeTecnicos.Show();
    				Timer1.Enabled = false;
    			}
    			if (e.CommandName.Equals("cerrarTicket", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr3 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion3 = gvr3.Cells[1].Text.ToString().Trim();
    				Session["idticket"] = eleccion3;
    				string[] datos2 = new string[13];
    				datos2 = odbusuario.buscarTicketNum(eleccion3);
    				lblIdFinalizar.Text = datos2[0];
    				mpeFinalizar.Show();
    				Timer1.Enabled = false;
    			}
    		}
    		catch (Exception)
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Erorr al ingresar al proceso');", addScriptTags: true);
    		}
    	}

    	protected void btnEliminar_Click(object sender, EventArgs e)
    	{
    		mpe.Hide();
    		odbusuario = new BaseDatos();
    		if (odbusuario.eliminarTrabajoProgamado(Convert.ToInt32((string)Session["idticket"])))
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('se elimino el ticket satisfactoriamente');", addScriptTags: true);
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.listaTrabajosProgramados();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    		}
    		else
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('no se pudo eliminar el ticket');", addScriptTags: true);
    		}
    	}

    	protected void btnFinalizar_Click(object sender, EventArgs e)
    	{
    		mpeFinalizar.Hide();
    		odbusuario = new BaseDatos();
    		if (odbusuario.finalizarTrabajoProgamado(Convert.ToInt32((string)Session["idticket"])))
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('se finalizo el ticket satisfactoriamente');", addScriptTags: true);
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.listaTrabajosProgramados();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    		}
    		else
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('no se pudo finalizar el ticket');", addScriptTags: true);
    		}
    	}

    	protected void btnEditarTecnicos_Click(object sender, EventArgs e)
    	{
    		mpeTecnicos.Hide();
    		mpeEditarTecnicos.Show();
    		Timer1.Enabled = false;
    		odbusuario = new BaseDatos();
    		DataSet ds = odbusuario.TecnicosReasignacionTrabajosProgramados(Convert.ToInt32((string)Session["idticket"]));
    		RadMultiSelect1.DataSource = ds;
    		RadMultiSelect1.DataBind();
    		IEnumerable<object> selectedValues = RadMultiSelect1.Value;
    		foreach (string value in selectedValues)
    		{
    			RadMultiSelect1.Items.FindChildByValue(value);
    		}
    	}

    	protected async void btnConfirmarTecnicos_Click(object sender, EventArgs e)
    	{
    		mpeEditarTecnicos.Hide();
    		odbusuario = new BaseDatos();
    		int nToken = 0;
    		string tecnicosNToken = "";
    		try
    		{
    			odbusuario = new BaseDatos();
    			odbusuario.eliminarTecnicosTrabajosProgramados(Convert.ToInt32((string)Session["idticket"]));
    			IEnumerable<object> selectedValues = RadMultiSelect1.Value;
    			foreach (string value in selectedValues)
    			{
    				MultiSelectItem selectedItem = RadMultiSelect1.Items.FindChildByValue(value);
    				odbusuario = new BaseDatos();
    				odbusuario.asignarTecnicosTrabajoProgamado(Convert.ToInt32((string)Session["idticket"]), selectedItem.Value);
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
    			if (nToken > 0)
    			{
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('El tecnico no cuenta con dispositivo movil vinculado al sistema\n" + tecnicosNToken + "');", addScriptTags: true);
    			}
    		}
    		catch (Exception ex2)
    		{
    			Exception ex3 = ex2;
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('no se pudo generar ticket\n-Error:\n-" + ex3.Message + "');", addScriptTags: true);
    		}
    	}

    	protected void Timer1_Tick(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		DataSet ds = odbusuario.listaTrabajosProgramados();
    		GridView1.DataSource = ds.Tables[0];
    		GridView1.DataBind();
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
