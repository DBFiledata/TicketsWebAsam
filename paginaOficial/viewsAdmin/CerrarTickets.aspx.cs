using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace paginaOficial.viewsAdmin
{
    public partial class CerrarTickets : System.Web.UI.Page
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
                DataSet ds = odbusuario.ListaTicketSinCierre();
                this.GridView1.DataSource = ds.Tables[0];
                this.GridView1.DataBind();
            }
            else
            {
                this.Timer1.Enabled = true;
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                odbusuario = new Controlers.BaseDatos();
                if (e.CommandName.Equals("cerrarTicket", StringComparison.CurrentCultureIgnoreCase))
                {
                    GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    string eleccion = gvr.Cells[1].Text.ToString().Trim();
                    Session["idticket"] = eleccion;
                    string[] datos = new string[13];
                    datos = odbusuario.buscarTicketNum(eleccion);
                    lblIdFinalizar.Text = datos[0];
                    this.mpe.Show();
                    this.Timer1.Enabled=false;
                }

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Erorr al ingresar al proceso');", true);

            }
        }
        
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.mpe.Hide();
            odbusuario = new Controlers.BaseDatos();
            if (odbusuario.cerrarTicket(Convert.ToInt32((string)Session["idticket"])))
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('se cerro el ticket satisfactoriamente');", true);
                odbusuario = new Controlers.BaseDatos();
                DataSet ds = odbusuario.ListaTicketSinCierre();
                this.GridView1.DataSource = ds.Tables[0];
                this.GridView1.DataBind();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('no se pudo serrar el ticket');", true);

            }

        }


        protected void Timer1_Tick(object sender, EventArgs e)
        {
            odbusuario = new Controlers.BaseDatos();
            DataSet ds = odbusuario.ListaTicketSinCierre();
            this.GridView1.DataSource = ds.Tables[0];
            this.GridView1.DataBind();
        }
       
    }

}


    