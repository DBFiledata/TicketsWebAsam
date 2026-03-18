using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsUsers
{
    public partial class registroSolicitantes : Page
    {
    	private BaseDatos odbusuario;

    	protected ScriptManager ScriptManager1;

    	protected UpdatePanel UpdatePanel1;

    	protected Label Label1;

    	protected TextBox txtId;

    	protected Label Label2;

    	protected TextBox txtNombre;

    	protected Label Label4;

    	protected TextBox txtApellido;

    	protected Label Label7;

    	protected TextBox txtDepartamento;

    	protected Label Label9;

    	protected TextBox txtTelefono;

    	protected Label Label3;

    	protected TextBox txtEmail;

    	protected Button btnRegistrar;

    	protected Button btnCancelar;

    	protected Label lblerror;

    	protected RequiredFieldValidator RequiredFieldValidatorId;

    	protected RequiredFieldValidator RequiredFieldValidatorIdNombre;

    	protected RequiredFieldValidator RequiredFieldValidatorApellido;

    	protected RequiredFieldValidator RequiredFieldValidator1;

    	protected RequiredFieldValidator RequiredFieldValidator2;

    	protected RegularExpressionValidator RegularExpressionValidatortelefono;

    	protected ValidationSummary ValidationSummary;

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
    	}

    	protected void btnRegistrar_Click(object sender, EventArgs e)
    	{
    		lblerror.Visible = false;
    		odbusuario = new BaseDatos();
    		if ((txtId.Text != string.Empty) & (txtNombre.Text != string.Empty) & (txtApellido.Text != string.Empty) & (txtDepartamento.Text != string.Empty) & (txtTelefono.Text != string.Empty))
    		{
    			odbusuario = new BaseDatos();
    			if (odbusuario.RegistrarSolicitante(txtId.Text, txtNombre.Text, txtApellido.Text, txtDepartamento.Text, txtEmail.Text, txtTelefono.Text))
    			{
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Usuario creado satisfactoriamente');", addScriptTags: true);
    				Session["solicitanteNuevo"] = txtId.Text;
    				txtId.Text = "";
    				txtNombre.Text = "";
    				txtApellido.Text = "";
    				txtDepartamento.Text = "";
    				txtEmail.Text = "";
    				txtTelefono.Text = "";
    			}
    			else
    			{
    				lblerror.Text = "No se pudo registrar el solicitante<br/>-Verifique que el Id que desea registrar no este creado<br/>-Verificar que la informacion ingresada es correcta";
    				lblerror.Visible = true;
    			}
    		}
    		else
    		{
    			lblerror.Text = "Deve completar todos los campos necesarios";
    			lblerror.Visible = true;
    		}
    	}

    	protected void btnCancelar_Click(object sender, EventArgs e)
    	{
    		txtId.Text = "";
    		txtNombre.Text = "";
    		txtApellido.Text = "";
    		txtEmail.Text = "";
    		txtDepartamento.Text = "";
    		txtTelefono.Text = "";
    	}
    }

}
