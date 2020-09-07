using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace paginaOficial.viewsAdmin
{
    public partial class cantidadPermisos : System.Web.UI.Page
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
                DataSet ds = odbusuario.cantidadPermisos();
                this.GridView1.DataSource = ds.Tables[0];
                this.GridView1.DataBind();
            }

        }
    }
}