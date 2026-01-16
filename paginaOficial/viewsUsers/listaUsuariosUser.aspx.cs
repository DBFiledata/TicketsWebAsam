using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsUsers
{
    public partial class listaUsuariosUser : Page
    {
    	private BaseDatos odbusuario;

    	protected ScriptManager ScriptManager1;

    	protected UpdatePanel UpdatePanel1;

    	protected Label Label6;

    	protected DropDownList ListTipo;

    	protected Label Label1;

    	protected TextBox txtnombre;

    	protected Button btnfiltrar;

    	protected GridView GridView1;

    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (!User.Identity.IsAuthenticated)
    		{
    			Response.Redirect("~/Login.aspx");
    		}
    		else if ((string)Session["type"] != "5")
    		{
    			Session.Abandon();
    			Session.Clear();
    			FormsAuthentication.SignOut();
    			Response.Redirect("~/login.aspx");
    		}
    		else if (!Page.IsPostBack)
    		{
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.ListaTotal();
    			GridView1.DataSource = ds.Tables[0];
    			GridView1.DataBind();
    		}
    	}

    	protected void btnfiltrar_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		string texto = txtnombre.Text + " ";
    		string[] datos = texto.Split(' ');
    		if ((txtnombre.Text != string.Empty) & (ListTipo.SelectedIndex > 0) & (ListTipo.SelectedIndex < 9))
    		{
    			if ((datos[1] != null) & (datos[1] != string.Empty))
    			{
    				DataSet ds = odbusuario.filtroUsuario(datos[0], datos[1], Convert.ToInt32(ListTipo.Text));
    				GridView1.DataSource = ds.Tables[0];
    				GridView1.DataBind();
    			}
    			else
    			{
    				DataSet ds2 = odbusuario.filtroUsuario(datos[0], datos[0], Convert.ToInt32(ListTipo.Text));
    				GridView1.DataSource = ds2.Tables[0];
    				GridView1.DataBind();
    			}
    		}
    		else if ((txtnombre.Text != string.Empty) & (ListTipo.SelectedIndex == 0))
    		{
    			if ((datos[1] != null) & (datos[1] != string.Empty))
    			{
    				DataSet ds3 = odbusuario.filtroUsuario(datos[0], datos[1], Convert.ToInt32(ListTipo.Text));
    				GridView1.DataSource = ds3.Tables[0];
    				GridView1.DataBind();
    			}
    			else
    			{
    				DataSet ds4 = odbusuario.filtroUsuario(datos[0], datos[0], Convert.ToInt32(ListTipo.Text));
    				GridView1.DataSource = ds4.Tables[0];
    				GridView1.DataBind();
    			}
    		}
    		else if ((txtnombre.Text == string.Empty) & (ListTipo.SelectedIndex > 0) & (ListTipo.SelectedIndex < 9))
    		{
    			DataSet ds5 = odbusuario.filtroUsuario(null, null, Convert.ToInt32(ListTipo.Text));
    			GridView1.DataSource = ds5.Tables[0];
    			GridView1.DataBind();
    		}
    		else if ((txtnombre.Text == string.Empty) & (ListTipo.SelectedIndex == 0))
    		{
    			DataSet ds6 = odbusuario.filtroUsuario(null, null, 0);
    			GridView1.DataSource = ds6.Tables[0];
    			GridView1.DataBind();
    		}
    	}
    }

}
