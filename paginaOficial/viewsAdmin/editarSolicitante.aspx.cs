using System;
using System.Web.UI;

namespace paginaOficial.viewsAdmin
{
    public partial class editarSolicitante : System.Web.UI.Page
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
                    string[] datos = new string[6];
                    datos = odbusuario.infoSolicitante((string)Session["solicitante"]);
                    txtId.Text = datos[0];
                    txtNombre.Text = datos[1];
                    txtApellido.Text = datos[2];
                    txtDepartemento.Text = datos[3];
                    txtEmail.Text = datos[4];
                    txtTelefono.Text = datos[5];
                }
            }
        }


        protected void btnEditar_Click(object sender, EventArgs e)
        {
            odbusuario = new Controlers.BaseDatos();
            if (odbusuario.ActualizarSolicitante((string)Session["solicitante"], txtId.Text, txtNombre.Text, txtApellido.Text, txtDepartemento.Text, txtEmail.Text, txtTelefono.Text))
            {
                Response.Redirect("buscarSolicitante.aspx");
            }
            else
            {
                lblerror.Text = "No se pudo actualizar el solicitante <br />-verifique si la informacion esta ingresada correctamente <br />-verifique que al id que intenta registrar no este creado";
                lblerror.Visible = true;
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("buscarSolicitante.aspx");
        }
    }
}