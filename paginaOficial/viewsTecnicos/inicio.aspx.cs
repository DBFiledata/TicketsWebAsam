using System;
using System.Web.Security;
using System.Web.UI;

namespace paginaOficial.viewsTecnicos
{
    public partial class inicio : Page
    {
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
    	}
    }

}
