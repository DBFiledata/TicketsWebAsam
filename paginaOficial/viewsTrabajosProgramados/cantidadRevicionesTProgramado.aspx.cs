using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsTrabajosProgramados
{
    public partial class cantidadRevicionesTProgramado : Page
    {
    	private BaseDatos odbusuario;

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
    			int rolJefe = Convert.ToInt32(Session["rol"]);
    			DataSet ds = odbusuario.cantidadRevisionesPorArea(rolJefe);
    			// Validar que el DataSet tenga tablas antes de asignar al GridView
    			if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    			{
    				GridView1.DataSource = ds.Tables[0];
    				GridView1.DataBind();
    			}
    		}
    	}
    }

}
