using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace paginaOficial.viewsAdmin
{
    public partial class prueva : System.Web.UI.Page
    {
        Controlers.BaseDatos odbusuario;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!User.Identity.IsAuthenticated)
            {
                //Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                odbusuario = new Controlers.BaseDatos();
                DataSet ds = odbusuario.ListaTicketSinCierre();
                this.GridView1.DataSource = ds.Tables[0];
                this.GridView1.DataBind();
            }
            else
            {


            }

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            odbusuario = new Controlers.BaseDatos();
            DataSet ds = odbusuario.ListaTicketSinCierre();
            this.GridView1.DataSource = ds.Tables[0];
            this.GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                odbusuario = new Controlers.BaseDatos();
                if (e.CommandName.Equals("info", StringComparison.CurrentCultureIgnoreCase))
                {
                    GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    string eleccion = gvr.Cells[1].Text.ToString().Trim();
                    Session["idticket"] = eleccion;
                    string[] datos = new string[18];
                    datos = odbusuario.buscarTicketNum(eleccion);
                    this.lblNumTicket.Text = datos[0];
                    this.lblIdSolicitante.Text = datos[1] + " " + datos[2] + " " + datos[3];
                    this.lblIdTecnico.Text = datos[7] + " " + datos[8] + " " + datos[9];
                    this.lblIdAgente.Text = datos[4] + " " + datos[5] + " " + datos[6];
                    this.txtProblema.Text = datos[10];
                    this.txtDescripcion.Text = datos[11];
                    this.lblEstado.Text = datos[12];
                    this.lblfecha.Text = datos[15];
                    Panel1.Attributes["display"] = "block";
                    this.mp1.Show();
                }
                //if (e.CommandName.Equals("cerrarTicket", StringComparison.CurrentCultureIgnoreCase))
                //{
                //    GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                //    string eleccion = gvr.Cells[1].Text.ToString().Trim();
                //    Session["idticket"] = eleccion;
                //    string[] datos = new string[13];
                //    datos = odbusuario.buscarTicketNum(eleccion);
                //    lblIdFinalizar.Text = datos[0];
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalEliminar()", true);

                //}

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Erorr al ingresar al proceso');", true);

            }
        }
    }
}