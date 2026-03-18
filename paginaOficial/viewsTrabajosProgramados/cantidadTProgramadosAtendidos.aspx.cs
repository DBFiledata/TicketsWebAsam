using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsTrabajosProgramados
{
    public partial class cantidadTProgramadosAtendidos : Page
    {
    	private BaseDatos odbusuario;

    	protected GridView GridView1;

    	protected TextBox txtDesde;

    	protected TextBox TxtHasta;

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
    			CargarDatos("0000-00-00", "0000-00-00");
    		}
    	}

    	private void CargarDatos(string desde, string hasta)
    	{
    		odbusuario = new BaseDatos();
    		int rolJefe = Convert.ToInt32(Session["rol"]);
    		DataSet ds = odbusuario.cantidadTrabajoProgramadoPorArea(rolJefe, desde, hasta);
    		if (ds != null && ds.Tables.Count > 0)
    		{
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    		}
    	}

    	protected void btnFiltrar_Click(object sender, EventArgs e)
    	{
    		string desde = string.IsNullOrEmpty(txtDesde.Text) ? "0000-00-00" : txtDesde.Text;
    		string hasta = string.IsNullOrEmpty(TxtHasta.Text) ? "0000-00-00" : TxtHasta.Text;
    		CargarDatos(desde, hasta);
    	}

    	protected void btnLimpiar_Click(object sender, EventArgs e)
    	{
    		txtDesde.Text = "";
    		TxtHasta.Text = "";
    		CargarDatos("0000-00-00", "0000-00-00");
    	}
    }

}
