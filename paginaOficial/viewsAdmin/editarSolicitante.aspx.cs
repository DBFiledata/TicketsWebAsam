using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsAdmin
{
    public partial class editarSolicitante : Page
    {
    	private BaseDatos odbusuario;

    	protected Label Label7;

    	protected TextBox txtId;

    	protected Label Label1;

    	protected TextBox txtNombre;

    	protected Label Label2;

    	protected TextBox txtApellido;

    	protected Label Label4;

    	protected TextBox txtDepartemento;

    	protected Label Label9;

    	protected TextBox txtTelefono;

    	protected Label Label3;

    	protected TextBox txtEmail;

    	protected Button btnEditar;

    	protected Button btnCancelar;

    	protected Label lblerror;

    	protected RequiredFieldValidator RequiredFieldValidatorId;

    	protected RequiredFieldValidator RequiredFieldValidatorIdNombre;

    	protected RequiredFieldValidator RequiredFieldValidatorApellido;

    	protected RequiredFieldValidator RequiredFieldValidatorDepartemento;

    	protected RequiredFieldValidator RequiredFieldValidatorTelefono;

    	protected RegularExpressionValidator RegularExpressionValidatortelefono;

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
    			datos = odbusuario.infoSolicitante((string)Session["solicitante"]);
    			txtId.Text = datos[0];
    			txtNombre.Text = datos[1];
    			txtApellido.Text = datos[2];
    			txtDepartemento.Text = datos[3];
    			txtEmail.Text = datos[4];
    			txtTelefono.Text = datos[5];
    		}
    	}

    	protected void btnEditar_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		if (odbusuario.ActualizarSolicitante((string)Session["solicitante"], txtId.Text, txtNombre.Text, txtApellido.Text, txtDepartemento.Text, txtEmail.Text, txtTelefono.Text))
    		{
    			Response.Redirect("buscarSolicitante.aspx");
    			return;
    		}
    		lblerror.Text = "No se pudo actualizar el solicitante <br />-verifique si la informacion esta ingresada correctamente <br />-verifique que al id que intenta registrar no este creado";
    		lblerror.Visible = true;
    	}

    	protected void btnCancelar_Click(object sender, EventArgs e)
    	{
    		Response.Redirect("buscarSolicitante.aspx");
    	}
    }

}
