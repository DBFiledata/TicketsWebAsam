using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace paginaOficial.viewsCompartidas
{
    public partial class generarTicketsUsers : System.Web.UI.Page
    {
        Controlers.BaseDatos odbusuario;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            else {
                if(Session["solicitanteNuevo"] != null)
                {
                    odbusuario = new Controlers.BaseDatos();
                    string[] datos = new string[6];
                    datos = odbusuario.infoSolicitante((string)Session["solicitanteNuevo"]);
                    if (datos != null)
                    {
                        this.btnSolicitanteNuevo.Visible = true;
                        this.btnSolicitanteNuevo.Enabled = true;
                        this.btnSolicitanteNuevo.ToolTip = "si desea ingresar el ultimo solicitante creado presione este boton\nEl ultimo solicitante creado fue:\n " + datos[0] + "\n " + datos[1] + " " + datos[2];
                        //this.txtIdSolicitante.Width = 483;
                    }
                }
            }
        }
        protected void btnSolicitanteNuevo_Click(object sender, EventArgs e)
        {
            this.txtIdSolicitante.Text = (string)Session["solicitanteNuevo"];
            this.btnSolicitanteNuevo.Visible = false;
            this.btnSolicitanteNuevo.Enabled = false;
            Session["solicitanteNuevo"] = null;

        }
        protected void btnBuscarInfo_Click(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            odbusuario = new Controlers.BaseDatos();
            string[] datos = new string[6];
            datos = odbusuario.infoSolicitante(this.txtIdSolicitante.Text);
            if (datos != null)
            {
                this.panelInfo.Visible = true;
                this.lblNombre.Text = datos[1] + " " + datos[2];
                this.lblDepartamento.Text = datos[3];
                this.lblEmail.Text = datos[4];
                this.lblTelefono.Text = datos[5];
            }
            else
            {
                lblerror.Text = "No se encontro solocitante registrado con ese id";
                lblerror.Visible = true;

            }

        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            odbusuario = new Controlers.BaseDatos();
            int id;
            string desc;
            DataSet TiCket;
            try {
                if (checkFechaProgramacion.Checked) {
                    TiCket = odbusuario.generarTicketProgramado(this.txtDetallePocicion.Text, this.txtProblema.Text, this.txtIdSolicitante.Text, User.Identity.Name, Convert.ToDateTime(txtfecha.Text));
                    id = Convert.ToInt32((TiCket.Tables[0].Rows[0]["id"]));
                    desc ="ticket programado para el "+txtfecha.Text;
                    if ( (checkFechaProgramacion.Checked & txtfecha.Text != string.Empty))
                    {
                        this.panelBuscar.Visible = false;
                        this.panelInfo.Visible = false;
                        this.lblNombre.Text = "";
                        this.lblDepartamento.Text = "";
                        this.lblEmail.Text = "";
                        this.lblTelefono.Text = "";
                        this.txtDetallePocicion.Text = "";
                        this.txtProblema.Text = "";
                        this.checkFechaProgramacion.Checked = false;
                        this.txtIdSolicitante.Text = "";
                        this.txtfecha.Text = "";
                        this.ListTipo.ClearSelection();
                        this.lblNum.Text = Convert.ToString(id);
                        this.lblTecnico.Text = desc;
                        this.panelResultado.Visible = true;
                        //Response.Redirect("resultadoTickets.aspx?id= " + id.ToString() + "&desc=" + desc);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('no se pudo generar ticket<br/>-verifique que los datos entan ingresados correctamente<br/>-verifique si tiene fecha de programacion seleccionada');", true);
                    }
                }
                else
                {
                    TiCket = odbusuario.generarTicket(this.txtDetallePocicion.Text, this.txtProblema.Text, this.txtIdSolicitante.Text, User.Identity.Name, ListTipo.SelectedValue);
                    id = Convert.ToInt32((TiCket.Tables[1].Rows[0]["id"]));
                    desc = Convert.ToString(TiCket.Tables[1].Rows[0]["descr"]);
                    if ((TiCket != null) || (id == -1))
                    {
                        this.lblerror.Visible = false;
                        this.panelBuscar.Visible = false;
                        this.panelInfo.Visible = false;
                        this.lblNombre.Text = "";
                        this.lblDepartamento.Text = "";
                        this.lblEmail.Text = "";
                        this.lblTelefono.Text = "";
                        this.txtDetallePocicion.Text = "";
                        this.txtProblema.Text = "";
                        this.checkFechaProgramacion.Checked = false;
                        this.txtIdSolicitante.Text = "";
                        this.txtfecha.Text = "";
                        this.ListTipo.ClearSelection();
                        this.lblNum.Text = Convert.ToString(id);
                        this.lblTecnico.Text = desc;
                        this.panelResultado.Visible = true;
                        //Response.Redirect("resultadoTickets.aspx?id= " + id.ToString() + "&desc=" + desc);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('no se pudo generar ticket');", true);
                    }
                }

                

            
            }catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('no se pudo generar ticket\n-Error:\n-"+ex.Message+"');", true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.lblerror.Visible = false;
            this.panelInfo.Visible = false;
            this.lblNombre.Text = "";
            this.lblDepartamento.Text = "";
            this.lblEmail.Text = "";
            this.lblTelefono.Text = "";
            this.txtDetallePocicion.Text = "";
            this.txtProblema.Text = "";
            this.checkFechaProgramacion.Checked = false;
            this.txtIdSolicitante.Text = "";
            this.txtfecha.Text = "";
            this.ListTipo.ClearSelection();

        }
        
        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            this.lblerror.Visible = false;
            this.panelResultado.Visible = false;
            this.lblNum.Text = "";
            this.lblTecnico.Text = "";
            this.panelBuscar.Visible = true;
        }

        
    }
}