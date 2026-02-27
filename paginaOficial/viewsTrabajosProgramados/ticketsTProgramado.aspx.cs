using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using paginaOficial.Controlers;

namespace paginaOficial.viewsTrabajosProgramados
{
    public partial class ticketsTProgramado : Page
    {
        private BaseDatos odbusuario;

        protected ScriptManager ScriptManager1;

        protected UpdatePanel UpdatePanel1;

        protected HiddenField HiddenField1;

        protected ModalPopupExtender mpeReasignar;

        protected HiddenField HiddenField2;

        protected ModalPopupExtender mpeResultado;

        protected Timer Timer1;

        protected Panel Panel1;

        protected Button btnCloseReasignar;

        protected Label lblIdReasignar;

        protected TextBox txtMotivoReasignacion;

        protected DropDownList ddlTecnicos;

        protected Button btnReasignar;

        protected Panel Panel2;

        protected Button btnCloseResultado;

        protected Label lblTecnico;

        protected Label lblcedulaTecnico;

        protected GridView GridView1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            else if ((string)Session["type"] != "8")
            {
                Session.Abandon();
                Session.Clear();
                FormsAuthentication.SignOut();
                Response.Redirect("~/login.aspx");
            }
            else if (!Page.IsPostBack)
            {
                odbusuario = new BaseDatos();
                int rolJefe = Convert.ToInt32(Session["rol"]);
                DataSet ds = odbusuario.listaTicketsPorAreaJefe(rolJefe);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            else
            {
                Timer1.Enabled = true;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                odbusuario = new BaseDatos();
                if (e.CommandName.Equals("reasignarTicket", StringComparison.CurrentCultureIgnoreCase))
                {
                    GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                    string eleccion = gvr.Cells[1].Text.ToString().Trim();
                    Session["idticket"] = eleccion;
                    lblIdReasignar.Text = eleccion;
                    Timer1.Enabled = false;

                    // Cargar tecnicos disponibles del area del jefe
                    odbusuario = new BaseDatos();
                    int rolJefe = Convert.ToInt32(Session["rol"]);
                    DataSet dsTecnicos = odbusuario.tecnicosDisponiblesTrabajosProgramadosPorArea(rolJefe);
                    ddlTecnicos.Items.Clear();
                    ddlTecnicos.Items.Add(new ListItem("-- Seleccione un tecnico --", "0"));
                    if (dsTecnicos != null && dsTecnicos.Tables.Count > 0)
                    {
                        foreach (DataRow row in dsTecnicos.Tables[0].Rows)
                        {
                            ddlTecnicos.Items.Add(new ListItem(row["nombre"].ToString(), row["ID"].ToString()));
                        }
                    }
                    mpeReasignar.Show();
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertaError",
                    "mostrarAlerta('danger', 'Error al ingresar al proceso');", addScriptTags: true);
            }
        }

        protected void btnReasignar_Click(object sender, EventArgs e)
        {
            odbusuario = new BaseDatos();
            try
            {
                if (!string.IsNullOrEmpty(txtMotivoReasignacion.Text) && ddlTecnicos.SelectedValue != "0")
                {
                    string tecnico = ddlTecnicos.SelectedValue;
                    DataSet resultado = odbusuario.reasignarTicket(Convert.ToInt32((string)Session["idticket"]), txtMotivoReasignacion.Text, tecnico);

                    // Refrescar la lista
                    odbusuario = new BaseDatos();
                    int rolJefe = Convert.ToInt32(Session["rol"]);
                    DataSet ds = odbusuario.listaTicketsPorAreaJefe(rolJefe);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    mpeReasignar.Hide();
                    Timer1.Enabled = true;

                    // Mostrar resultado
                    lblTecnico.Text = ddlTecnicos.SelectedItem.Text;
                    lblcedulaTecnico.Text = tecnico;
                    mpeResultado.Show();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertaWarning",
                        "mostrarAlerta('warning', 'Debe indicar el motivo de reasignacion y seleccionar un tecnico');", addScriptTags: true);
                    mpeReasignar.Show();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertaError",
                    "mostrarAlerta('danger', 'No se pudo reasignar el ticket');", addScriptTags: true);
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            odbusuario = new BaseDatos();
            int rolJefe = Convert.ToInt32(Session["rol"]);
            DataSet ds = odbusuario.listaTicketsPorAreaJefe(rolJefe);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
    }
}
