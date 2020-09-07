using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace paginaOficial.viewsAdmin
{
    public partial class editarVacaciones : System.Web.UI.Page
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
                DataSet ds = odbusuario.ListaEnVacaciones();
                this.GridView1.DataSource = ds.Tables[0];
                this.GridView1.DataBind();
            }
            else
            {


            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                odbusuario = new Controlers.BaseDatos();
                
                if (e.CommandName.Equals("finalizarVacaciones", StringComparison.CurrentCultureIgnoreCase))
                {
                    GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    string eleccion = gvr.Cells[1].Text.ToString().Trim();
                    Session["cedula"] = eleccion;
                    string[] datos = new string[6];
                    datos = odbusuario.infoCuenta(eleccion);
                    lblIdVacaciones.Text = datos[0];
                    lblNombreVacaciones.Text = datos[1] + " " + datos[2];
                    lblTipo.Text = datos[5];
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalFinalizarVacaciones()", true);
                }

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Erorr al ingresar al proceso');", true);

            }
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            odbusuario = new Controlers.BaseDatos();
            if (odbusuario.finalizarVacaciones(((string)Session["cedula"])))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "pop", "alert('Vacaciones finalizadas satisfactoriamente');", true);
                odbusuario = new Controlers.BaseDatos();
                DataSet ds = odbusuario.ListaEnVacaciones();
                this.GridView1.DataSource = ds.Tables[0];
                this.GridView1.DataBind();
                

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "pop", "alert('Finalizacion de vacaciones no se a podido completar');", true);

            }

        }

        protected void btnfiltrar_Click(object sender, EventArgs e)
        {
            odbusuario = new Controlers.BaseDatos();
            string texto = txtNombre.Text + " ";
            string[] datos = texto.Split(' ');
            if (txtNombre.Text != string.Empty & listTipo.SelectedIndex > 0 & listTipo.SelectedIndex < 7)
            {
                if (datos[1] != null & datos[1] != string.Empty)
                {
                    DataSet ds = odbusuario.filtroEnVacaciones(datos[0], datos[1], Convert.ToInt32(listTipo.Text));
                    this.GridView1.DataSource = ds.Tables[0];
                    this.GridView1.DataBind();
                }
                else
                {
                    DataSet ds = odbusuario.filtroEnVacaciones(datos[0], null, Convert.ToInt32(listTipo.Text));
                    this.GridView1.DataSource = ds.Tables[0];
                    this.GridView1.DataBind();
                }

            }
            else if (txtNombre.Text != string.Empty & listTipo.SelectedIndex == 0)
            {
                if (datos[0] != null & datos[1] != string.Empty)
                {
                    DataSet ds = odbusuario.filtroEnVacaciones(datos[0], datos[1], Convert.ToInt32(listTipo.Text));
                    this.GridView1.DataSource = ds.Tables[0];
                    this.GridView1.DataBind();
                }
                else
                {
                    DataSet ds = odbusuario.filtroEnVacaciones(datos[0], null, Convert.ToInt32(listTipo.Text));
                    this.GridView1.DataSource = ds.Tables[0];
                    this.GridView1.DataBind();
                }
            }
            else if (txtNombre.Text == string.Empty & listTipo.SelectedIndex > 0 & listTipo.SelectedIndex < 7)
            {
                DataSet ds = odbusuario.filtroEnVacaciones(null, null, Convert.ToInt32(listTipo.Text));
                this.GridView1.DataSource = ds.Tables[0];
                this.GridView1.DataBind();
            }
            else if (txtNombre.Text == string.Empty & listTipo.SelectedIndex == 0)
            {
                DataSet ds = odbusuario.filtroEnVacaciones(null, null, 0);
                this.GridView1.DataSource = ds.Tables[0];
                this.GridView1.DataBind();
            }
        }
    }
 }
    