using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace paginaOficial.viewsTecnicos
{
    public partial class tecnicos : MasterPage
    {
    	protected Image Image2;

    	protected ContentPlaceHolder contenido;

    	protected Button btnRegbtnCerrarsesionistrar;

    	protected Image Image3;

    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (((string)Session["type"] != "1") & ((string)Session["type"] != "2") & ((string)Session["type"] != "3") & ((string)Session["type"] != "4") & ((string)Session["type"] != "9") & ((string)Session["type"] != "10"))
    		{
    			Session.Abandon();
    			Session.Clear();
    			FormsAuthentication.SignOut();
    			Response.Redirect("~/login.aspx");
    		}
    	}

    	protected void btnCerrarsesion_Click(object sender, EventArgs e)
    	{
    		Session.Abandon();
    		Session.Clear();
    		FormsAuthentication.SignOut();
    		Response.Redirect("~/login.aspx");
    	}
    }

}
