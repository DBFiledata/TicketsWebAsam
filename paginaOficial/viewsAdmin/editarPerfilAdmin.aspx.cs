using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace paginaOficial.viewsAdmin
{
    public partial class editarPerfilAdmin : System.Web.UI.Page
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
                    datos = odbusuario.infoCuenta((string)Session["id"]);
                    txtId.Text = datos[0];
                    txtNombre.Text = datos[1];
                    txtApellido.Text = datos[2];
                    txtEmail.Text = datos[3];
                    txtTelefono.Text = datos[4];
                    listTipo.Items.FindByValue(datos[6]).Selected= true;
                }
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try { 
            lblerror.Visible = false;
            odbusuario = new Controlers.BaseDatos();
            if (odbusuario.ActualizarUsuario((string)Session["id"], txtId.Text, txtNombre.Text, txtApellido.Text, txtEmail.Text, Convert.ToInt32(txtTelefono.Text), Convert.ToInt32(listTipo.Text)))
            {
                    Session["id"] = txtId.Text;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "alert('Su perfil a sido actualizado satisfactoriamente');", true);
                
            }
            else
            {
                lblerror.Text = "No se pudo actualizar su informacion <br />-verifique si la informacion esta ingresada correctamente <br />-verifique que al id que intenta registrar no este creado";
                lblerror.Visible = true;
            }
            }
            catch (Exception ex)
            {
                lblerror.Text = " Error No se pudo editar su informacion<br />-verifique si la informacion esta ingresada correctamente <br />-verifique que al id que intenta utilizar no este creado";
                lblerror.Visible = true;
            }

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicioAdmin.aspx");
        }


    }
}