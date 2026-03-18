using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsUsers
{
    public partial class buscarSolicitante : Page
    {
    	private BaseDatos odbusuario;

    	protected ScriptManager ScriptManager1;

    	protected UpdatePanel UpdatePanel1;

    	protected Panel panelBuscar;

    	protected TextBox txtIdSolicitante;

    	protected Button btnBuscarSolicitante;

    	protected Panel panelInfo;

    	protected Label Label2;

    	protected Label lblId;

    	protected Label lbl1;

    	protected Label lblNombre;

    	protected Label Label1;

    	protected Label lblDepartamento;

    	protected Label Label3;

    	protected Label lblEmail;

    	protected Label Label7;

    	protected Label lblTelefono;

    	protected Button btnEditar;

    	protected Button btnEliminar;

    	protected Panel PanelEditar;

    	protected Label Label5;

    	protected TextBox txtId;

    	protected Label Label6;

    	protected TextBox txtNombre;

    	protected Label Label8;

    	protected TextBox txtApellido;

    	protected Label Label10;

    	protected TextBox txtDepartamento;

    	protected Label Label11;

    	protected TextBox txtTelefono;

    	protected Label Label12;

    	protected TextBox txtEmail;

    	protected Button btnEdicion;

    	protected Button btnCancelar;

    	protected Label lblerror;

    	protected RequiredFieldValidator RequiredFieldValidatorIdBuscar;

    	protected RequiredFieldValidator RequiredFieldValidatorId;

    	protected RequiredFieldValidator RequiredFieldValidatorIdNombre;

    	protected RequiredFieldValidator RequiredFieldValidatorApellido;

    	protected RequiredFieldValidator RequiredFieldValidatorDepartamento;

    	protected RequiredFieldValidator RequiredFieldValidatorTelefono;

    	protected RegularExpressionValidator RegularExpressionValidatortelefono;

    	protected ValidationSummary ValidationSummary1;

    	protected void Page_Load(object sender, EventArgs e)
    	{
    		lblerror.Visible = false;
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

    	protected void btnBuscarSolicitante_Click(object sender, EventArgs e)
    	{
    		lblerror.Visible = false;
    		try
    		{
    			if (txtIdSolicitante.Text != string.Empty)
    			{
    				odbusuario = new BaseDatos();
    				string[] datos = new string[6];
    				datos = odbusuario.infoSolicitanteIntranet(txtIdSolicitante.Text);
    				if (datos != null)
    				{
    					panelBuscar.Visible = false;
    					lblId.Text = datos[0];
    					lblNombre.Text = datos[1] + " " + datos[2];
    					lblDepartamento.Text = datos[3];
    					lblEmail.Text = datos[4];
    					lblTelefono.Text = datos[5];
    					btnEditar.Enabled = false;
    					btnEliminar.Enabled = false;
    					Session["solicitante"] = datos[0];
    					panelInfo.Visible = true;
    				}
    				else
    				{
    					lblerror.Text = "No se pudo encontrar al solicitante <br />-verifique si la informacion esta ingresada correctamente <br />-verifique que al id que intenta buscar este creado";
    					lblerror.Visible = true;
    				}
    			}
    			else
    			{
    				lblerror.Text = "debe ingresar los campos necesarios";
    				lblerror.Visible = true;
    			}
    		}
    		catch (Exception ex)
    		{
    			lblerror.Text = "error al intentar realizar el proceso <br/>" + ex.Message;
    			lblerror.Visible = true;
    		}
    	}

    	protected void btnEditar_Click(object sender, EventArgs e)
    	{
    		panelInfo.Visible = false;
    		odbusuario = new BaseDatos();
    		string[] datos = new string[6];
    		datos = odbusuario.infoSolicitante((string)Session["solicitante"]);
    		txtId.Text = datos[0];
    		txtNombre.Text = datos[1];
    		txtApellido.Text = datos[2];
    		txtDepartamento.Text = datos[3];
    		txtEmail.Text = datos[4];
    		txtTelefono.Text = datos[5];
    		txtIdSolicitante.Text = "";
    		lblId.Text = "";
    		lblNombre.Text = "";
    		lblDepartamento.Text = "";
    		lblEmail.Text = "";
    		lblTelefono.Text = "";
    		RequiredFieldValidatorIdBuscar.Enabled = false;
    		RequiredFieldValidatorId.Enabled = true;
    		RequiredFieldValidatorIdNombre.Enabled = true;
    		RequiredFieldValidatorApellido.Enabled = true;
    		RequiredFieldValidatorDepartamento.Enabled = true;
    		RequiredFieldValidatorTelefono.Enabled = true;
    		RegularExpressionValidatortelefono.Enabled = true;
    		btnEditar.Enabled = false;
    		btnEliminar.Enabled = false;
    		btnEdicion.Enabled = true;
    		btnCancelar.Enabled = true;
    		PanelEditar.Visible = true;
    	}

    	protected void btnEliminar_Click(object sender, EventArgs e)
    	{
    		lblerror.Visible = false;
    		if (txtIdSolicitante.Text != string.Empty)
    		{
    			odbusuario = new BaseDatos();
    			if (odbusuario.EliminarSolicitante(txtIdSolicitante.Text))
    			{
    				panelInfo.Visible = false;
    				txtIdSolicitante.Text = "";
    				lblId.Text = "";
    				lblNombre.Text = "";
    				lblDepartamento.Text = "";
    				lblEmail.Text = "";
    				lblTelefono.Text = "";
    				btnEditar.Enabled = false;
    				btnEliminar.Enabled = false;
    				panelBuscar.Visible = true;
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('El solicitante a sido eliminado satisfactoriamente');", addScriptTags: true);
    			}
    			else
    			{
    				lblerror.Text = "no se pudo elimirar el solicitante";
    				lblerror.Visible = true;
    			}
    		}
    	}

    	protected void btnEdicion_Click(object sender, EventArgs e)
    	{
    		lblerror.Visible = false;
    		odbusuario = new BaseDatos();
    		if (odbusuario.ActualizarSolicitante((string)Session["solicitante"], txtId.Text, txtNombre.Text, txtApellido.Text, txtDepartamento.Text, txtEmail.Text, txtTelefono.Text))
    		{
    			PanelEditar.Visible = false;
    			txtId.Text = "";
    			txtNombre.Text = "";
    			txtApellido.Text = "";
    			txtDepartamento.Text = "";
    			txtTelefono.Text = "";
    			txtEmail.Text = "";
    			btnEdicion.Enabled = false;
    			btnCancelar.Enabled = false;
    			RequiredFieldValidatorIdBuscar.Enabled = true;
    			RequiredFieldValidatorId.Enabled = false;
    			RequiredFieldValidatorIdNombre.Enabled = false;
    			RequiredFieldValidatorApellido.Enabled = false;
    			RequiredFieldValidatorDepartamento.Enabled = false;
    			RequiredFieldValidatorTelefono.Enabled = false;
    			RegularExpressionValidatortelefono.Enabled = false;
    			panelBuscar.Visible = true;
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('actualizacion realizada satisfactoriamente');", addScriptTags: true);
    		}
    		else
    		{
    			lblerror.Text = "No se pudo registrar el ususario <br />-verifique si la informacion esta ingresada correctamente <br />-verifique que al id que intenta registrar no este creado";
    			lblerror.Visible = true;
    		}
    	}

    	protected void btnCancelar_Click(object sender, EventArgs e)
    	{
    		lblerror.Visible = false;
    		PanelEditar.Visible = false;
    		txtId.Text = "";
    		txtNombre.Text = "";
    		txtApellido.Text = "";
    		txtDepartamento.Text = "";
    		txtTelefono.Text = "";
    		txtEmail.Text = "";
    		btnEdicion.Enabled = false;
    		btnCancelar.Enabled = false;
    		RequiredFieldValidatorIdBuscar.Enabled = true;
    		RequiredFieldValidatorId.Enabled = false;
    		RequiredFieldValidatorIdNombre.Enabled = false;
    		RequiredFieldValidatorApellido.Enabled = false;
    		RequiredFieldValidatorDepartamento.Enabled = false;
    		RequiredFieldValidatorTelefono.Enabled = false;
    		RegularExpressionValidatortelefono.Enabled = false;
    		panelBuscar.Visible = true;
    	}
    }

}
