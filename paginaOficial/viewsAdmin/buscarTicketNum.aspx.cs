using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;

namespace paginaOficial.viewsAdmin
{
    public partial class buscarTicketNum : Page
    {
    	private BaseDatos odbusuario;

    	protected ScriptManager ScriptManager1;

    	protected UpdatePanel UpdatePanel1;

    	protected Panel panelBuscar;

    	protected TextBox txtIdTicket;

    	protected Button btnBuscarTicket;

    	protected Panel panelInfo;

    	protected Label Label6;

    	protected Label lblNumTicket;

    	protected Label Label11;

    	protected Label lblNombreSolicitante;

    	protected Label Label7;

    	protected Label lblNombreTecnico;

    	protected Label Label13;

    	protected Label lblNombreAgente;

    	protected Label lbl1;

    	protected TextBox txtProblema;

    	protected Label Label1;

    	protected TextBox txtDescripcion;

    	protected Label Label19;

    	protected Label lblEstado;

    	protected Label Label3;

    	protected Label lblfecha;

    	protected Button btnEditar;

    	protected Button btnEliminar;

    	protected Label lblerror;

    	protected RequiredFieldValidator RequiredFieldValidatorId;

    	protected RegularExpressionValidator RegularExpressionValidatorId;

    	protected ValidationSummary ValidationSummary;

    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (!User.Identity.IsAuthenticated)
    		{
    			Response.Redirect("~/Login.aspx");
    			Session["TicketNum"] = null;
    		}
    		else if ((string)Session["type"] != "6")
    		{
    			Session.Abandon();
    			Session.Clear();
    			FormsAuthentication.SignOut();
    			Response.Redirect("~/login.aspx");
    		}
    	}

    	protected void btnBuscar_Click(object sender, EventArgs e)
    	{
    		lblerror.Visible = false;
    		try
    		{
    			if (txtIdTicket.Text != string.Empty)
    			{
    				odbusuario = new BaseDatos();
    				string[] datos = new string[14];
    				datos = odbusuario.buscarTicketNum(txtIdTicket.Text);
    				if (datos != null)
    				{
    					lblNumTicket.Text = datos[0];
    					lblNombreSolicitante.Text = datos[1] + " " + datos[2] + " " + datos[3];
    					lblNombreTecnico.Text = datos[7] + " " + datos[8] + " " + datos[9];
    					lblNombreAgente.Text = datos[4] + " " + datos[5] + " " + datos[6];
    					txtProblema.Text = datos[10];
    					txtDescripcion.Text = datos[11];
    					lblEstado.Text = datos[12];
    					panelInfo.Visible = true;
    					if (datos[18] == "1")
    					{
    						lblfecha.Text = datos[13];
    					}
    					else if (datos[18] == "2")
    					{
    						lblfecha.Text = datos[14];
    					}
    					else if (datos[18] == "3")
    					{
    						lblfecha.Text = datos[15];
    					}
    					else if (datos[18] == "4")
    					{
    						lblfecha.Text = datos[16];
    					}
    					else if (datos[18] == "5")
    					{
    						lblfecha.Text = datos[17];
    					}
    					panelBuscar.Visible = false;
    					btnBuscarTicket.Enabled = false;
    					btnEditar.Enabled = true;
    					btnEliminar.Enabled = true;
    				}
    				else
    				{
    					lblerror.Text = "Verifique que el valor ingresado existe como numero de ticket";
    					lblerror.Visible = true;
    					ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Verifique que el valor ingresado existe como numero de ticket');", addScriptTags: true);
    				}
    			}
    			else
    			{
    				ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Deve completar los campos requeridos');", addScriptTags: true);
    			}
    		}
    		catch (Exception ex)
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Erorr al ingresar al proceso -" + ex.Message + "');", addScriptTags: true);
    		}
    	}

    	protected void btnEditar_Click(object sender, EventArgs e)
    	{
    		Session["TicketNum"] = txtIdTicket.Text;
    		Response.Redirect("editarTicket.aspx");
    	}

    	protected void btnEliminar_Click(object sender, EventArgs e)
    	{
    		lblerror.Visible = false;
    		odbusuario = new BaseDatos();
    		if (odbusuario.EliminarTicket(Convert.ToInt32(lblNumTicket.Text)))
    		{
    			txtIdTicket.Text = "";
    			panelInfo.Visible = false;
    			panelBuscar.Visible = true;
    			btnBuscarTicket.Enabled = true;
    			btnEditar.Enabled = false;
    			btnEliminar.Enabled = false;
    			lblNumTicket.Text = "";
    			lblNombreSolicitante.Text = "";
    			lblNombreTecnico.Text = "";
    			lblNombreAgente.Text = "";
    			txtProblema.Text = "";
    			txtDescripcion.Text = "";
    			lblEstado.Text = "";
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Ticket eliminado satisfactoriamente');", addScriptTags: true);
    		}
    		else
    		{
    			lblerror.Text = "No se pudo eliminar el ticket";
    			lblerror.Visible = true;
    		}
    	}
    }

}
