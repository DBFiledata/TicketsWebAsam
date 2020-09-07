using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace paginaOficial.viewsUsers
{
    public partial class liberarTicketProgramado : System.Web.UI.Page
    {
        Controlers.BaseDatos odbusuario;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                odbusuario = new Controlers.BaseDatos();
                DataSet ds = odbusuario.liberarTicketLista(User.Identity.Name);
                this.listTicket.DataSource = ds.Tables[0];
                this.listTicket.DataBind();
            }
           
        }


        protected void listTicket_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                odbusuario = new Controlers.BaseDatos();
                if (e.CommandName.Equals("info", StringComparison.CurrentCultureIgnoreCase))
                {
                    GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    string eleccion = gvr.Cells[1].Text.ToString().Trim();
                    Session["idticket"] = eleccion;
                    string[] datos = new string[13];
                    datos = odbusuario.buscarTicketNum(eleccion);
                    this.lblNumTicket.Text = datos[0];
                    this.lblIdSolicitante.Text = datos[1];
                    this.lblNombreSolicitante.Text = datos[2] + " " + datos[3];
                    this.txtProblema.Text = datos[10];
                    this.txtDescripcion.Text = datos[11];
                    this.lblfecha.Text = datos[16];
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalInfo()", true);
                }
                if (e.CommandName.Equals("liberar", StringComparison.CurrentCultureIgnoreCase))
                {
                    GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    string eleccion = gvr.Cells[1].Text.ToString().Trim();
                    Session["idticket"] = eleccion;
                    string[] datos = new string[13];
                    datos = odbusuario.buscarTicketNum(eleccion);
                    lblIdLiberar.Text = datos[0];
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalLiberarTicket()", true);

                }

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Erorr al ingresar al proceso');", true);

            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            odbusuario = new Controlers.BaseDatos();
            DataSet TiCket = odbusuario.liberarTicketProgramado(Convert.ToInt32((string)Session["idticket"]), Convert.ToInt32(ListTipo.SelectedValue));
            string id = Convert.ToString((TiCket.Tables[1].Rows[0]["id"]));
            string desc = Convert.ToString(TiCket.Tables[1].Rows[0]["descr"]);
            if ((TiCket != null) || (id == "-1"))
            {
                lblIdLiberado.Text = Convert.ToString((string)Session["idticket"]);
                lblTecnico.Text = id + " "+desc;
                odbusuario = new Controlers.BaseDatos();
                DataSet ds = odbusuario.liberarTicketLista(User.Identity.Name);
                this.listTicket.DataSource = ds.Tables[0];
                this.listTicket.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalResultadoTicket()", true);
                ListTipo.ClearSelection();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('no se pudo liberar el ticket');", true);

            }

        }
    }
}