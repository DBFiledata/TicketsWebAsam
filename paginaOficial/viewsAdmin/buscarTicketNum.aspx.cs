using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace paginaOficial.viewsAdmin
{
    public partial class buscarTicketNum : System.Web.UI.Page
    {
        Controlers.BaseDatos odbusuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
                Session["TicketNum"] = null;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            try
            {
                if (txtIdTicket.Text != String.Empty)
                {
                    odbusuario = new Controlers.BaseDatos();
                    string[] datos = new string[14];
                    datos = odbusuario.buscarTicketNum(this.txtIdTicket.Text);
                    if (datos != null)
                    {
                        this.lblNumTicket.Text = datos[0];
                        this.lblNombreSolicitante.Text = datos[1] + " " + datos[2] + " " + datos[3];
                        this.lblNombreTecnico.Text = datos[7] + " " + datos[8] + " " + datos[9];
                        this.lblNombreAgente.Text = datos[4] + " " + datos[5] + " " + datos[6];
                        this.txtProblema.Text = datos[10];
                        this.txtDescripcion.Text = datos[11];
                        this.lblEstado.Text = datos[12];
                        this.panelInfo.Visible = true;
                        if (datos[18] == "1")
                        {
                            this.lblfecha.Text = datos[13];
                        }
                        else if (datos[18] == "2")
                        {
                            this.lblfecha.Text = datos[14];
                        }
                        else if (datos[18] == "3")
                        {
                            this.lblfecha.Text = datos[15];
                        }
                        else if (datos[18] == "4")
                        {
                            this.lblfecha.Text = datos[16];
                        }
                        else if (datos[18] == "5")
                        {
                            this.lblfecha.Text = datos[17];
                        }
                        this.panelBuscar.Visible = false;
                        this.btnBuscarTicket.Enabled = false;
                        this.btnEditar.Enabled = true;
                        this.btnEliminar.Enabled = true;
                    }
                    else
                    {
                        lblerror.Text = "Verifique que el valor ingresado existe como numero de ticket";
                        lblerror.Visible = true;
                        ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Verifique que el valor ingresado existe como numero de ticket');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Deve completar los campos requeridos');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Erorr al ingresar al proceso -" + ex.Message+ "');", true);

            }
        }
            

            protected void btnEditar_Click(object sender, EventArgs e)
        {
            Session["TicketNum"] = this.txtIdTicket.Text;
            Response.Redirect("editarTicket.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            odbusuario = new Controlers.BaseDatos();
            if (odbusuario.EliminarTicket(Convert.ToInt32(lblNumTicket.Text))) {
                txtIdTicket.Text = "";
                this.panelInfo.Visible = false;
                this.panelBuscar.Visible = true;
                this.btnBuscarTicket.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnEliminar.Enabled = false;
                this.lblNumTicket.Text = "";
                this.lblNombreSolicitante.Text = "";
                this.lblNombreTecnico.Text = "";
                this.lblNombreAgente.Text = "";
                this.txtProblema.Text = "";
                this.txtDescripcion.Text = "";
                this.lblEstado.Text = "";
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Ticket eliminado satisfactoriamente');", true);
            }
            else
            {
                lblerror.Text = "No se pudo eliminar el ticket";
                lblerror.Visible = true;

            }
        }

        
    }


}