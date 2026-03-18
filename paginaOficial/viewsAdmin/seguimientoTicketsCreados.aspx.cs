using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using paginaOficial.Controlers;

namespace paginaOficial.viewsAdmin
{
    public partial class seguimientoTicketsCreados : Page
    {
    	private BaseDatos odbusuario;

    	private Mailer mailer;

    	protected ScriptManager ScriptManager1;

    	protected UpdatePanel UpdatePanel1;

    	protected HiddenField HiddenField1;

    	protected ModalPopupExtender mpe;

    	protected Timer Timer2;

    	protected Panel Panel1;

    	protected Button btnClose;

    	protected Timer Timer1;

    	protected GridView listTickets;

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
    		else if (!IsPostBack)
    		{
    			odbusuario = new BaseDatos();
    			Session["ultimoTicketActivo"] = odbusuario.ultimoTicket();
    		}
    		odbusuario = new BaseDatos();
    		DataSet ds = odbusuario.listaTicketsActivos();
    		listTickets.DataSource = ds.Tables[0];
    		listTickets.DataBind();
    	}

    	protected void Timer1_Tick(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		DataSet ds = odbusuario.listaTicketsActivos();
    		listTickets.DataSource = ds.Tables[0];
    		listTickets.DataBind();
    		odbusuario = new BaseDatos();
    		int count = odbusuario.ultimoTicket();
    		if (count > (int)Session["ultimoTicketActivo"])
    		{
    			Session["ultimoTicketActivo"] = count;
    			Timer2.Interval = 5000;
    			Timer2.Enabled = true;
    			ScriptManager.RegisterStartupScript(this, GetType(), "playSound", "playSound();", addScriptTags: true);
    			mpe.Show();
    		}
    	}

    	protected void Timer2_Tick(object sender, EventArgs e)
    	{
    		mpe.Hide();
    		Timer2.Enabled = false;
    	}

    	protected void listTickets_RowDataBound(object sender, GridViewRowEventArgs e)
    	{
    		if (e.Row.RowType != DataControlRowType.DataRow)
    		{
    			return;
    		}
    		string dateString = e.Row.Cells[9].Text;
    		string tipo = e.Row.Cells[1].Text;
    		int id = Convert.ToInt32(e.Row.Cells[0].Text);
    		string format = "dd-MM-yyyy HH:mm:ss";
    		if (!DateTime.TryParseExact(dateString, format, null, DateTimeStyles.None, out var dateValue))
    		{
    			return;
    		}
    		DateTime currentTime = DateTime.Now;
    		if (!((Math.Abs((currentTime - dateValue).TotalHours) >= 4.0) & (tipo != "Trabajo Progamado")))
    		{
    			return;
    		}
    		e.Row.BackColor = Color.Yellow;
    		e.Row.ForeColor = Color.Black;
    		odbusuario = new BaseDatos();
    		if (odbusuario.verificarConfirmacionTiempoTickets(id) == "1")
    		{
    			odbusuario = new BaseDatos();
    			if (odbusuario.asignarConfirmacionTiempoTickets(id))
    			{
    				odbusuario = new BaseDatos();
    				string[] datos = new string[11];
    				datos = odbusuario.infoTicketMailConnfirmacionTiempo(Convert.ToString(id));
    				mailer = new Mailer();
    				mailer.Notify(datos[9], Convert.ToInt32(id), datos[1], datos[3], "", "", datos[8], datos[7], 4);
    				mailer = new Mailer();
    				mailer.Notify(datos[10], Convert.ToInt32(id), datos[1], datos[3], "", "", datos[8], datos[7], 4);
    			}
    		}
    	}
    }

}
