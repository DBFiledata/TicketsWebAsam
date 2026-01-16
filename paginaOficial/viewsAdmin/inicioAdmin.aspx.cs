using System;
using System.Web.Security;
using System.Web.UI;

namespace paginaOficial.viewsAdmin
{
    public partial class inicioAdmin : Page
    {
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
    	}
    }

}
