using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace paginaOficial.viewsUsers
{
    public partial class listaUsuariosUser : System.Web.UI.Page
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
                DataSet ds = odbusuario.ListaTotal();
                this.GridView1.DataSource = ds.Tables[0];
                this.GridView1.DataBind();
            }
            else
            {

            }
        }

        protected void btnfiltrar_Click(object sender, EventArgs e)
        {
            odbusuario = new Controlers.BaseDatos();
            string texto = txtnombre.Text + " ";
            string[] datos = texto.Split(' ');
            if (txtnombre.Text != string.Empty & ListTipo.SelectedIndex > 0 & ListTipo.SelectedIndex < 7)
            {
                if (datos[1] != null & datos[1] != string.Empty) {
                DataSet ds = odbusuario.filtroUsuario(datos[0], datos[1], Convert.ToInt32(ListTipo.Text));
                this.GridView1.DataSource = ds.Tables[0];
                this.GridView1.DataBind();
                }
                else
                {
                    DataSet ds = odbusuario.filtroUsuario(datos[0], datos[0], Convert.ToInt32(ListTipo.Text));
                    this.GridView1.DataSource = ds.Tables[0];
                    this.GridView1.DataBind();
                }

            }
            else if (txtnombre.Text != string.Empty & ListTipo.SelectedIndex == 0)
            {
                if (datos[1] != null & datos[1] != string.Empty)
                {
                    DataSet ds = odbusuario.filtroUsuario(datos[0], datos[1], Convert.ToInt32(ListTipo.Text));
                    this.GridView1.DataSource = ds.Tables[0];
                    this.GridView1.DataBind();
                }
                else
                {
                    DataSet ds = odbusuario.filtroUsuario(datos[0], datos[0], Convert.ToInt32(ListTipo.Text));
                    this.GridView1.DataSource = ds.Tables[0];
                    this.GridView1.DataBind();
                }
            }
            else if (txtnombre.Text == string.Empty & ListTipo.SelectedIndex > 0 & ListTipo.SelectedIndex < 6)
            {
                DataSet ds = odbusuario.filtroUsuario(null, null, Convert.ToInt32(ListTipo.Text));
                this.GridView1.DataSource = ds.Tables[0];
                this.GridView1.DataBind();
            }
            else if(txtnombre.Text == string.Empty & ListTipo.SelectedIndex == 0)
            {
                DataSet ds = odbusuario.filtroUsuario(null, null, 0);
                this.GridView1.DataSource = ds.Tables[0];
                this.GridView1.DataBind();
            }
        }
    }
}