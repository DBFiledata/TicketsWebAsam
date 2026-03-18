using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using paginaOficial.Controlers;

namespace paginaOficial.viewsTrabajosProgramados
{
    public partial class seguimientoDeTicketsCreadosTProgramado : Page
    {
    	private BaseDatos odbusuario;

    	private Mailer mailer;

    	protected ScriptManager ScriptManager1;

    	protected UpdatePanel UpdatePanel1;

    	protected HiddenField HiddenField1;

    	protected ModalPopupExtender mpe;

    	protected HiddenField HiddenField2;

    	protected ModalPopupExtender mpeRevision;

    	protected Timer Timer1;

    	protected Panel Panel1;

    	protected Button btnClose;

    	protected Label lblIdFinalizar;

    	protected Button btnConfirmar;

    	protected Panel Panel2;

    	protected Button btnCloseReasignar;

    	protected Label lblIdReasignar;

    	protected Button btnReasignar;

    	protected GridView GridView1;

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
    			DataSet ds = odbusuario.listaTicketsActivos1();
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
    			if (e.CommandName.Equals("revisionTicket", StringComparison.CurrentCultureIgnoreCase))
    			{
    				GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
    				string eleccion = gvr.Cells[1].Text.ToString().Trim();
    				string[] datos = new string[18];
    				datos = odbusuario.buscarTicketNum(eleccion);
    				if (datos[18] != "8")
    				{
    					Session["idticket"] = eleccion;
    					lblIdReasignar.Text = eleccion;
    					mpeRevision.Show();
    					Timer1.Enabled = false;
    				}
    				else
    				{
    					ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('El ticket selecionado ya es un trabajo programado');", addScriptTags: true);
    				}
    			}
    		}
    		catch (Exception)
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Erorr al ingresar al proceso');", addScriptTags: true);
    		}
    	}

    	protected void btnConfirmar_Click(object sender, EventArgs e)
    	{
    		mpe.Hide();
    		odbusuario = new BaseDatos();
    		if (odbusuario.cerrarTicket(Convert.ToInt32((string)Session["idticket"]), ""))
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('se cerro el ticket satisfactoriamente');", addScriptTags: true);
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.listaTicketsActivos1();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    		}
    		else
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('no se pudo serrar el ticket');", addScriptTags: true);
    		}
    	}

    	protected void btnReasignar_Click(object sender, EventArgs e)
    	{
    		Session["ReasicgacionTP"] = (string)Session["idticket"];
    		Session["idticket"] = null;
    		Response.Redirect("crearTProgramado.aspx");
    	}

    	protected void Timer1_Tick(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		DataSet ds = odbusuario.listaTicketsActivos1();
    		GridView1.DataSource = ds.Tables[0];
    		GridView1.DataBind();
    	}

    	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    	{
    		if (e.Row.RowType != DataControlRowType.DataRow)
    		{
    			return;
    		}
    		// Scroll para columnas Problema y Descripcion
    		GridView gv = (GridView)sender;
    		if (gv.HeaderRow != null)
    		{
    			for (int i = 0; i < gv.HeaderRow.Cells.Count; i++)
    			{
    				string hText = gv.HeaderRow.Cells[i].Text.ToLower();
    				if (hText.Contains("problema") || hText.Contains("descripci"))
    				{
    					string origText = e.Row.Cells[i].Text;
    					e.Row.Cells[i].Text = "<div class='cell-scroll'>" + origText + "</div>";
    				}
    			}
    		}
    		string dateString = HttpUtility.HtmlDecode(e.Row.Cells[10].Text);
    		string tipo = HttpUtility.HtmlDecode(e.Row.Cells[2].Text);
    		int id = Convert.ToInt32(e.Row.Cells[1].Text);
    		string format = "dd/MM/yyyy h:mm:ss tt";
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
