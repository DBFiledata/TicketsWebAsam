using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial
{
    public partial class login : Page
    {
    	private BaseDatos odbusuario;

    	protected HtmlForm form1;

    	protected Login Login;

    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (!IsPostBack)
    		{
    			ViewState["LoginErrors"] = 0;
    		}
    	}

    	protected void Login_Authenticate1(object sender, AuthenticateEventArgs e)
    	{
    		if (!((Login.Password != string.Empty) & (Login.UserName != string.Empty)))
    		{
    			return;
    		}
    		odbusuario = new BaseDatos();
    		if (odbusuario.login(Login.UserName, Login.Password))
    		{
    			string[] datos = new string[3];
    			datos = odbusuario.getDatosSession(Login.UserName, Login.Password);
    			Session["id"] = Login.UserName;
    			Session["username"] = datos[0];
    			Session["type"] = datos[1];
    			Session["rol"] = datos[2];
    			FormsAuthentication.SetAuthCookie(Login.UserName, Login.RememberMeSet);
    			FormsAuthentication.RedirectFromLoginPage(Login.UserName, Login.RememberMeSet);
    			string nombre = User.Identity.Name;
    			if ((string)Session["type"] == "8")
    			{
    				Response.Redirect("~/viewsTrabajosProgramados/inicioTProgramado.aspx");
    			}
    			else if ((string)Session["type"] == "7")
    			{
    				Response.Redirect("~/viewsMonitoreo/inicioMonitoreo.aspx");
    			}
    			else if ((string)Session["type"] == "6")
    			{
    				Response.Redirect("~/viewsAdmin/inicioAdmin.aspx");
    			}
    			else if ((string)Session["type"] == "5")
    			{
    				Response.Redirect("~/viewsUsers/inicioUsers.aspx");
    			}
    			else if (((string)Session["type"] == "1") | ((string)Session["type"] == "2") | ((string)Session["type"] == "3") | ((string)Session["type"] == "4") | ((string)Session["type"] == "9"))
    			{
    				Response.Redirect("~/viewsTecnicos/inicio.aspx");
    			}
    			else
    			{
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Su perfil no cuenta con los permisos para acceder a la aplicacion');", addScriptTags: true);
    			}
    		}
    		else
    		{
    			e.Authenticated = false;
    		}
    	}

    	protected void Login_LoginError(object sender, AuthenticateEventArgs e)
    	{
    		if (ViewState["LoginErrors"] == null)
    		{
    			ViewState["LoginErrors"] = 0;
    		}
    		int ErrorCount = (int)ViewState["LoginErrors"] + 1;
    		ViewState["LoginErrors"] = ErrorCount;
    		if (ErrorCount > 3 && Login.PasswordRecoveryUrl != string.Empty)
    		{
    			Response.Redirect(Login.PasswordRecoveryUrl);
    		}
    	}
    }

}
