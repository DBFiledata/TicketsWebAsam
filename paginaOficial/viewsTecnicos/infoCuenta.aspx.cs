using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsTecnicos
{
    public partial class infoCuenta : Page
    {
    	private BaseDatos odbusuario;

    	protected Label Label4;

    	protected Label lblId;

    	protected Label Label1;

    	protected Label lblNombre;

    	protected Label Label2;

    	protected Label lblAapellido;

    	protected Label Label5;

    	protected Label lblTelefono;

    	protected Label Label3;

    	protected Label lblEmail;

    	protected Label Label6;

    	protected Label lblTipo;

    	protected Label lbl;

    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (!User.Identity.IsAuthenticated)
    		{
    			Response.Redirect("~/Login.aspx");
    			return;
    		}
    		if (((string)Session["type"] != "1") & ((string)Session["type"] != "2") & ((string)Session["type"] != "3") & ((string)Session["type"] != "4") & ((string)Session["type"] != "9") & ((string)Session["type"] != "10"))
    		{
    			Session.Abandon();
    			Session.Clear();
    			FormsAuthentication.SignOut();
    			Response.Redirect("~/login.aspx");
    			return;
    		}
    		odbusuario = new BaseDatos();
    		string[] datos = new string[8];
    		datos = odbusuario.infoCuenta(User.Identity.Name);
    		lblId.Text = datos[0];
    		lblNombre.Text = datos[1];
    		lblAapellido.Text = datos[2];
    		lblEmail.Text = datos[3];
    		lblTelefono.Text = datos[4];
    		lblTipo.Text = datos[5];
    	}
    }

}
