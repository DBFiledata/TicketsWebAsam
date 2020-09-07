using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace paginaOficial.usersviews
{
    public partial class infoCuenta : System.Web.UI.Page
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
                odbusuario = new Controlers.BaseDatos();
                string[] datos = new string[8];
                datos = odbusuario.infoCuenta(User.Identity.Name);
                lblId.Text = datos[0];
                lblNombre.Text = datos[1];
                lblAapellido.Text = datos[2];
                lblEmail.Text = datos[3];
                lblTelefono.Text = datos[4];
                lblTipo.Text = datos[5];
            }
        }
    }
}