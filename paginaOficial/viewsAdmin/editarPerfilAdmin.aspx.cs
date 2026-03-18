using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsAdmin
{
    public partial class editarPerfilAdmin : Page
    {
    	private BaseDatos odbusuario;

    	protected ScriptManager ScriptManager1;

    	protected UpdatePanel UpdatePanel1;

    	protected Label Label7;

    	protected TextBox txtId;

    	protected Label Label1;

    	protected TextBox txtNombre;

    	protected Label Label2;

    	protected TextBox txtApellido;

    	protected Label Label9;

    	protected TextBox txtTelefono;

    	protected Label Label3;

    	protected TextBox txtEmail;

    	protected Label Label6;

    	protected DropDownList listTipo;

    	protected Button btnRegistrar;

    	protected Button btnCancelar;

    	protected Label lblerror;

    	protected RequiredFieldValidator RequiredFieldValidatorId;

    	protected RegularExpressionValidator RegularExpressionValidatorId;

    	protected RequiredFieldValidator RequiredFieldValidatorIdNombre;

    	protected RequiredFieldValidator RequiredFieldValidatorApellido;

    	protected RequiredFieldValidator RequiredFieldValidatorTelefono;

    	protected RegularExpressionValidator RegularExpressionValidatorTelefono;

    	protected RequiredFieldValidator RequiredFieldValidatorEmail;

    	protected RegularExpressionValidator RegularExpressionValidatorEmail;

    	protected RequiredFieldValidator RequiredFieldValidatorListTipo;

    	protected ValidationSummary ValidationSummary;

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
    		else if (!Page.IsPostBack)
    		{
    			odbusuario = new BaseDatos();
    			string[] datos = new string[6];
    			datos = odbusuario.infoCuenta((string)Session["id"]);
    			txtId.Text = datos[0];
    			txtNombre.Text = datos[1];
    			txtApellido.Text = datos[2];
    			txtEmail.Text = datos[3];
    			txtTelefono.Text = datos[4];
    			listTipo.Items.FindByValue(datos[6]).Selected = true;
    		}
    	}

    	protected void btnRegistrar_Click(object sender, EventArgs e)
    	{
    		try
    		{
    			lblerror.Visible = false;
    			odbusuario = new BaseDatos();
    			if (odbusuario.ActualizarUsuario((string)Session["id"], txtId.Text, txtNombre.Text, txtApellido.Text, txtEmail.Text, txtTelefono.Text, Convert.ToInt32(listTipo.Text)))
    			{
    				Session["id"] = txtId.Text;
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Su perfil a sido actualizado satisfactoriamente');", addScriptTags: true);
    			}
    			else
    			{
    				lblerror.Text = "No se pudo actualizar su informacion <br />-verifique si la informacion esta ingresada correctamente <br />-verifique que al id que intenta registrar no este creado";
    				lblerror.Visible = true;
    			}
    		}
    		catch (Exception)
    		{
    			lblerror.Text = " Error No se pudo editar su informacion<br />-verifique si la informacion esta ingresada correctamente <br />-verifique que al id que intenta utilizar no este creado";
    			lblerror.Visible = true;
    		}
    	}

    	protected void btnCancelar_Click(object sender, EventArgs e)
    	{
    		Response.Redirect("inicioAdmin.aspx");
    	}
    }

}
