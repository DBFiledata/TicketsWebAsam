using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsAdmin
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

    	protected Label lblerror;

    	protected RequiredFieldValidator RequiredFieldValidatorId;

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
    	}

    	protected void btnEditar_Click(object sender, EventArgs e)
    	{
    		Session["solicitante"] = txtIdSolicitante.Text;
    		Response.Redirect("editarSolicitante.aspx");
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
    				lblId.Text = "";
    				lblNombre.Text = "";
    				lblDepartamento.Text = "";
    				lblEmail.Text = "";
    				lblTelefono.Text = "";
    				txtIdSolicitante.Text = "";
    				panelBuscar.Visible = true;
    				btnBuscarSolicitante.Enabled = true;
    				btnEditar.Enabled = false;
    				btnEliminar.Enabled = false;
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('El solicitante a sido eliminado satisfactoriamente');", addScriptTags: true);
    			}
    			else
    			{
    				lblerror.Text = "no se pudo elimirar el solicitante";
    				lblerror.Visible = true;
    			}
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
    				string[] datos = new string[8];
    				datos = odbusuario.infoSolicitante(txtIdSolicitante.Text);
    				if (datos != null)
    				{
    					panelInfo.Visible = true;
    					lblId.Text = datos[0];
    					lblNombre.Text = datos[1] + " " + datos[2];
    					lblDepartamento.Text = datos[3];
    					lblEmail.Text = datos[4];
    					lblTelefono.Text = datos[5];
    					panelBuscar.Visible = false;
    					btnBuscarSolicitante.Enabled = false;
    					btnEditar.Enabled = true;
    					btnEliminar.Enabled = true;
    				}
    				else
    				{
    					lblerror.Text = "No se encontro solocitante registrado con ese id";
    					lblerror.Visible = true;
    				}
    			}
    		}
    		catch (Exception ex)
    		{
    			lblerror.Text = "error al intentar realizar el proceso <br/>" + ex.Message;
    			lblerror.Visible = true;
    		}
    	}
    }

}
