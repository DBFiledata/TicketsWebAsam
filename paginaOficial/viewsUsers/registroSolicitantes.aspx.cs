using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace paginaOficial.viewsUsers
{
    public partial class registroSolicitantes : System.Web.UI.Page
    {
        Controlers.BaseDatos odbusuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            odbusuario = new Controlers.BaseDatos();
            if(txtId.Text != string.Empty & txtNombre.Text != string.Empty & txtApellido.Text != string.Empty & txtDepartamento.Text != string.Empty & txtTelefono.Text != string.Empty)
                {
                
                //txtId.Text = "" + num;
                odbusuario = new Controlers.BaseDatos();
                if (odbusuario.RegistrarSolicitante(txtId.Text, txtNombre.Text, txtApellido.Text, txtDepartamento.Text, txtEmail.Text,txtTelefono.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('usuario creado satisfactoriamente');", true);
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