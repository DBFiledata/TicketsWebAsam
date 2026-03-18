using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsTrabajosProgramados
{
    public partial class cambioContraseñaTProgramado : Page
    {
    	private BaseDatos odbusuario;

    	protected ScriptManager ScriptManager1;

    	protected UpdatePanel UpdatePanel1;

    	protected Label Label4;

    	protected TextBox txtPass;

    	protected Label Label1;

    	protected TextBox txtPassnueva;

    	protected Label Label5;

    	protected TextBox txtPassnueva2;

    	protected Button btnRegistrar;

    	protected Button btnCancelar;

    	protected Label lblerror;

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
    	}

    	protected void btnRegistrar_Click(object sender, EventArgs e)
    	{
    		lblerror.Visible = false;
    		if ((txtPass.Text != string.Empty) & (txtPassnueva.Text != string.Empty) & (txtPassnueva2.Text != string.Empty))
    		{
    			odbusuario = new BaseDatos();
    			if ((txtPassnueva.Text == txtPassnueva2.Text) & odbusuario.login((string)Session["id"], txtPass.Text))
    			{
    				odbusuario = new BaseDatos();
    				if (odbusuario.ActualizarPassw((string)Session["id"], txtPassnueva.Text))
    				{
    					ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Contraseña actualizada satisfactoriamente');", addScriptTags: true);
    					txtPass.Text = "";
    					txtPassnueva.Text = "";
    					txtPassnueva2.Text = "";
    				}
    				else
    				{
    					lblerror.Text = "No se pudo actualizar la contraseña";
    					lblerror.Visible = true;
    				}
    			}
    			else
    			{
    				lblerror.Text = "No se pudo actualizar la contraseña<br/>-Verifique si la contraseña actual sea correcta<br/>-Verifique si la contreseña nueva sea igual a la de confirmacion";
    				lblerror.Visible = true;
    			}
    		}
    		else
    		{
    			lblerror.Text = "debe completar los campos necesarios";
    			lblerror.Visible = true;
    		}
    	}

    	protected void btnCancelar_Click(object sender, EventArgs e)
    	{
    		txtPass.Text = "";
    		txtPassnueva.Text = "";
    		txtPassnueva2.Text = "";
    	}
    }

}
