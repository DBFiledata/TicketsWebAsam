using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace paginaOficial.viewsUsers
{
    public partial class buscarSolicitante : System.Web.UI.Page
    {
        Controlers.BaseDatos odbusuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void btnBuscarSolicitante_Click(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            try
            {
                if (txtIdSolicitante.Text != string.Empty)
                {
                    odbusuario = new Controlers.BaseDatos();
                    string[] datos = new string[6];
                    datos = odbusuario.infoSolicitante(this.txtIdSolicitante.Text);
                    if (datos != null)
                    {
                        this.panelBuscar.Visible = false;
                        this.lblId.Text = datos[0];
                        this.lblNombre.Text = datos[1] + " " + datos[2];
                        this.lblDepartamento.Text = datos[3];
                        this.lblEmail.Text = datos[4];
                        this.lblTelefono.Text = datos[5];
                        this.btnEditar.Enabled = true;
                        this.btnEliminar.Enabled = true;
                        Session["solicitante"] = datos[0];
                        this.panelInfo.Visible = true;
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
            this.panelInfo.Visible = false;
            odbusuario = new Controlers.BaseDatos();
            string[] datos = new string[6];
            datos = odbusuario.infoSolicitante((string)Session["solicitante"]);
            this.txtId.Text = datos[0];
            this.txtNombre.Text = datos[1];
            this.txtApellido.Text = datos[2];
            this.txtDepartamento.Text = datos[3];
            this.txtEmail.Text = datos[4];
            this.txtTelefono.Text = datos[5];
            this.txtIdSolicitante.Text = "";
            this.lblId.Text = "";
            this.lblNombre.Text = "";
            this.lblDepartamento.Text = "";
            this.lblEmail.Text = "";
            this.lblTelefono.Text = "";
            this.RequiredFieldValidatorIdBuscar.Enabled = false;
            this.RegularExpressionIdBuscar.Enabled = false;
            this.RequiredFieldValidatorId.Enabled = true;
            this.RegularExpressionValidatorId.Enabled = true;
            this.RequiredFieldValidatorIdNombre.Enabled = true;
            this.RequiredFieldValidatorApellido.Enabled = true;
            this.RequiredFieldValidatorDepartamento.Enabled = true;
            this.RequiredFieldValidatorTelefono.Enabled = true;
            this.RegularExpressionValidatortelefono.Enabled = true;
            this.btnEditar.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnEdicion.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.PanelEditar.Visible = true;

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
                    this.txtIdSolicitante.Text = "";
                    this.lblId.Text = "";
                    this.lblNombre.Text = "";
                    this.lblDepartamento.Text = "";
                    this.lblEmail.Text = "";
                    this.lblTelefono.Text = "";
                    this.btnEditar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.panelBuscar.Visible = true;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('El solicitante a sido eliminado satisfactoriamente');", true);

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
            odbusuario = new Controlers.BaseDatos();
            if (odbusuario.ActualizarSolicitante((string)Session["solicitante"], txtId.Text, txtNombre.Text, txtApellido.Text, txtDepartamento.Text, txtEmail.Text, txtTelefono.Text))
            {
                this.PanelEditar.Visible = false;
                this.txtId.Text = "";
                this.txtNombre.Text = "";
                this.txtApellido.Text = "";
                this.txtDepartamento.Text = "";
                this.txtTelefono.Text = "";
                this.txtEmail.Text = "";
                this.btnEdicion.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.RequiredFieldValidatorIdBuscar.Enabled = true;
                this.RegularExpressionIdBuscar.Enabled = true;
                this.RequiredFieldValidatorId.Enabled = false;
                this.RegularExpressionValidatorId.Enabled = false;
                this.RequiredFieldValidatorIdNombre.Enabled = false;
                this.RequiredFieldValidatorApellido.Enabled = false;
                this.RequiredFieldValidatorDepartamento.Enabled = false;
                this.RequiredFieldValidatorTelefono.Enabled = false;
                this.RegularExpressionValidatortelefono.Enabled = false;
                this.panelBuscar.Visible = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('actualizacion realizada satisfactoriamente');", true);
            }
            else
            {
                lblerror.Text = "No se pudo registrar el ususario <br />-verifique si la informacion esta ingresada correctamente <br />-verifique que al id que intenta registrar no este creado";
                lblerror.Visible = true;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.lblerror.Visible = false;
            this.PanelEditar.Visible = false;
            this.txtId.Text = "";
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            this.txtDepartamento.Text = "";
            this.txtTelefono.Text = "";
            this.txtEmail.Text = "";
            this.btnEdicion.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.RequiredFieldValidatorIdBuscar.Enabled = true;
            this.RegularExpressionIdBuscar.Enabled = true;
            this.RequiredFieldValidatorId.Enabled = false;
            this.RegularExpressionValidatorId.Enabled = false;
            this.RequiredFieldValidatorIdNombre.Enabled = false;
            this.RequiredFieldValidatorApellido.Enabled = false;
            this.RequiredFieldValidatorDepartamento.Enabled = false;
            this.RequiredFieldValidatorTelefono.Enabled = false;
            this.RegularExpressionValidatortelefono.Enabled = false;
            this.panelBuscar.Visible = true;
        }


    }
}
    



