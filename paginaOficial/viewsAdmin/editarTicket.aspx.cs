using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace paginaOficial.viewsAdmin
{
    public partial class editarTicket : System.Web.UI.Page
    {
        Controlers.BaseDatos odbusuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    odbusuario = new Controlers.BaseDatos();
                    string[] datos = new string[18];
                    datos = odbusuario.buscarTicketNum((string)Session["TicketNum"]);
                    lblNumTicket.Text = datos[0];
                    lblIdSolicitante.Text = datos[1];
                    lblIdAgente.Text = datos[4];
                    txtIdTecnico.Text = datos[7];
                    lblIdTecnico.Text = datos[7];
                    txtDetallePocicion.Text = datos[11];
                    txtProblema.Text = datos[10];
                    Session["TicketEstado"] = datos[18];
                    Session["TicketTecnico"] = datos[7];
                    listTipo.ToolTip = "Escoja el estado que desea asignar al ticket\nsi desea asignar el ticket a un nuevo tecnico escoja la opcon creado\nsi no desea cambiar el estado no seleccione opciones en esta casilla\nEl estado actual del ticket es (" + datos[12]+")";
                }
            }
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {

            odbusuario = new Controlers.BaseDatos();
            
            if (listTipo.SelectedValue == "2" || listTipo.SelectedValue == "3" || listTipo.SelectedValue == "5")
            {
                if (odbusuario.ActualizarTicket((string)Session["TicketNum"], txtDetallePocicion.Text, txtProblema.Text, Convert.ToInt32(listTipo.SelectedValue), Convert.ToString(Session["TicketTecnico"])))
                {

                    Response.Redirect("buscarTicketNum.aspx");

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('No se pudo editar el ticket');", true);
                }
            }
            else if (this.txtfecha.Text!=string.Empty && listTipo.SelectedValue=="4") 
            { 
            
                if (odbusuario.ActualizarTicketProgramado((string)Session["TicketNum"], txtDetallePocicion.Text, txtProblema.Text, Convert.ToDateTime(txtfecha.Text)))
                {
                    Response.Redirect("buscarTicketNum.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('No se pudo editar el ticket');", true);
                }
            }
            else if (this.txtIdTecnico.Text != string.Empty && listTipo.SelectedValue == "1")
            {

                if (odbusuario.ActualizarTickeCreado((string)Session["TicketNum"], txtDetallePocicion.Text, txtProblema.Text, txtIdTecnico.Text))
                {
                    Response.Redirect("buscarTicketNum.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('No se pudo editar el ticket');", true);
                }
            }
            else if(listTipo.SelectedValue == "0") {
                if (odbusuario.ActualizarTicket((string)Session["TicketNum"], txtDetallePocicion.Text, txtProblema.Text, Convert.ToInt32(Session["TicketEstado"]), Convert.ToString(Session["TicketTecnico"])))
                {

                    Response.Redirect("buscarTicketNum.aspx");

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('No se pudo editar el ticket');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('error No se pudo editar el ticket');", true);

            }

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("buscarTicketNum.aspx");
        }
    }
}