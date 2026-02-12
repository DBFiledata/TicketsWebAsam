using System;
using System.Data;
using System.Drawing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using paginaOficial.Controlers;

namespace paginaOficial.viewsTecnicos
{
    public partial class ticketsTecnico : Page
    {
    	private BaseDatos odbusuario;

    	private Mailer mailer;

    	protected ScriptManager ScriptManager1;

    	protected UpdatePanel UpdatePanel1;

    	protected HiddenField HiddenField1;

    	protected ModalPopupExtender mpe;

    	protected HiddenField HiddenField2;

    	protected ModalPopupExtender mpeIniciar;

    	protected Timer Timer1;

    	protected Panel Panel1;

    	protected Button btnClose;

    	protected Label lblIdFinalizar;

    	protected Label Label2;

    	protected TextBox txtHora;

    	protected Label Label4;

    	protected TextBox txtPersonaAtendida;

    	protected Label Label1;

    	protected TextBox txtProcedimiento;

    	protected Button btnConfirmar;

    	protected Panel Panel2;

    	protected Button btnCloseIniciar;

    	protected Label lblIniciar;

    	protected Button Button4;

    	protected GridView GridView1;

    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (!User.Identity.IsAuthenticated)
    		{
    			Response.Redirect("~/Login.aspx");
    		}
    		else if (((string)Session["type"] != "1") & ((string)Session["type"] != "2") & ((string)Session["type"] != "3") & ((string)Session["type"] != "4") & ((string)Session["type"] != "9") & ((string)Session["type"] != "10"))
    		{
    			Session.Abandon();
    			Session.Clear();
    			FormsAuthentication.SignOut();
    			Response.Redirect("~/login.aspx");
    		}
    		else if (!Page.IsPostBack)
    		{
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.listaTicketsTecnico((string)Session["id"]);
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
    			if (e.CommandName.Equals("ConfirmarAtencion", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion = gvr.Cells[1].Text.ToString().Trim();
    				Session["idticket"] = eleccion;
    				lblIniciar.Text = eleccion;
    				mpeIniciar.Show();
    				Timer1.Enabled = false;
    			}
    			if (e.CommandName.Equals("finalizarAtencion", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr2 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion2 = gvr2.Cells[1].Text.ToString().Trim();
    				Session["idticket"] = eleccion2;
    				lblIdFinalizar.Text = eleccion2;
    				mpe.Show();
    				Timer1.Enabled = false;
    			}
    		}
    		catch (Exception)
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Erorr al ingresar al proceso');", addScriptTags: true);
    		}
    	}

    	protected void btnInicio_ClickAsync(object sender, EventArgs e)
    	{
    		mpe.Hide();
    		odbusuario = new BaseDatos();
    		if (odbusuario.asignarStatusTicket(Convert.ToInt32((string)Session["idticket"]), 2, ""))
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Se Inicio la atencion de su ticket');", addScriptTags: true);
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.listaTicketsTecnico((string)Session["id"]);
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    			odbusuario = new BaseDatos();
    			string[] datos = new string[8];
    			datos = odbusuario.infoTicketMail((string)Session["idticket"]);
    			mailer = new Mailer();
    			mailer.Notify(datos[2], Convert.ToInt32((string)Session["idticket"]), datos[1], (string)Session["username"], "", datos[5], "", "", 2);
    		}
    		else
    		{
    			odbusuario = new BaseDatos();
    			DataSet ds2 = odbusuario.listaTicketsTecnico((string)Session["id"]);
    			GridView1.DataSource = ds2.Tables[0];
    			GridView1.DataBind();
    		}
    	}

    	protected void btnConfirmar_Click(object sender, EventArgs e)
    	{
    		mpe.Hide();
    		if ((txtHora.Text != string.Empty) & (txtPersonaAtendida.Text != string.Empty) & (txtProcedimiento.Text != string.Empty))
    		{
    			string coment = "-Detalles de Atencion:\nPersona atendida: " + txtPersonaAtendida.Text + "\n Hora de llegada: " + txtHora.Text + "\n Procedimiento realizado: " + txtProcedimiento.Text;
    			odbusuario = new BaseDatos();
    			if (odbusuario.asignarStatusTicket(Convert.ToInt32((string)Session["idticket"]), 3, coment))
    			{
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Se confirmo la atencion de su ticket');", addScriptTags: true);
    				odbusuario = new BaseDatos();
    				DataSet ds = odbusuario.listaTicketsTecnico((string)Session["id"]);
    				GridView1.DataSource = ds.Tables[0];
    				GridView1.DataBind();
    				odbusuario = new BaseDatos();
    				string[] datos = new string[8];
    				datos = odbusuario.infoTicketMail((string)Session["idticket"]);
    				mailer = new Mailer();
    				mailer.Notify(datos[2], Convert.ToInt32((string)Session["idticket"]), datos[1], (string)Session["username"], "", txtPersonaAtendida.Text, txtHora.Text, txtProcedimiento.Text, 3);
    			}
    			else
    			{
    				odbusuario = new BaseDatos();
    				DataSet ds2 = odbusuario.listaTicketsTecnico((string)Session["id"]);
    				GridView1.DataSource = ds2.Tables[0];
    				GridView1.DataBind();
    			}
    		}
    		else
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Completar campos requeridos!!!');", addScriptTags: true);
    		}
    	}

    	protected void Timer1_Tick(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		DataSet ds = odbusuario.listaTicketsTecnico((string)Session["id"]);
    		GridView1.DataSource = ds.Tables[0];
    		GridView1.DataBind();
    	}

    	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    	{
    		if (e.Row.RowType == DataControlRowType.DataRow)
    		{
    			if (e.Row.Cells[7].Text == "Creado")
    			{
    				Button Button1 = (Button)e.Row.FindControl("Button1");
    				Button Button2 = (Button)e.Row.FindControl("Button2");
    				Button1.Visible = true;
    				Button2.Visible = false;
    			}
    			if (e.Row.Cells[7].Text == "En atencion")
    			{
    				Button Button1 = (Button)e.Row.FindControl("Button1");
    				Button Button2 = (Button)e.Row.FindControl("Button2");
    				Button1.Visible = false;
    				Button2.Visible = true;
    				e.Row.BackColor = Color.Green;
    			}
    			if (e.Row.Cells[7].Text == "Atendido")
    			{
    				Button Button1 = (Button)e.Row.FindControl("Button1");
    				Button Button2 = (Button)e.Row.FindControl("Button2");
    				Button1.Visible = false;
    				Button2.Visible = false;
    				e.Row.BackColor = Color.Red;
    			}
    		}
    	}
    }

}
