using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace paginaOficial.viewsAdmin
{
    public partial class buscarSolicitante : System.Web.UI.Page
    {
        Controlers.BaseDatos odbusuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
        }


        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Session["solicitante"] = this.txtIdSolicitante.Text;
            Response.Redirect("editarSolicitante.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            if (txtIdSolicitante.Text != string.Empty)
            {
                odbusuario = new Controlers.BaseDatos();
                if (odbusuario.EliminarSolicitante(this.txtIdSolicitante.Text))
                {
                    this.panelInfo.Visible = false;
                    this.lblId.Text = "";
                    this.lblNombre.Text = "";
                    this.lblDepartamento.Text = "";
                    this.lblEmail.Text = "";
                    this.lblTelefono.Text = "";
                    this.txtIdSolicitante.Text = "";
                    this.panelBuscar.Visible = true;
                    this.btnBuscarSolicitante.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('El solicitante a sido eliminado satisfactoriamente');", true);

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
            try { 
            if (txtIdSolicitante.Text != string.Empty)
            {
                odbusuario = new Controlers.BaseDatos();
                string[] datos = new string[8];
                datos = odbusuario.infoSolicitante(this.txtIdSolicitante.Text);
                if(datos != null) {
                this.panelInfo.Visible = true;
                this.lblId.Text = datos[0];
                this.lblNombre.Text = datos[1] + " " + datos[2];
                this.lblDepartamento.Text = datos[3];
                this.lblEmail.Text = datos[4];
                this.lblTelefono.Text = datos[5];
                this.panelBuscar.Visible = false;
                this.btnBuscarSolicitante.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnEliminar.Enabled = true;
                }
                else
                 {
                        lblerror.Text = "No se encontro solocitante registrado con ese id";
                        lblerror.Visible = true;

                    }


                }
            
            }
            catch (Exception ex) {
                lblerror.Text = "error al intentar realizar el proceso <br/>"+ex.Message;
                lblerror.Visible = true;

            }
        }

      }
}