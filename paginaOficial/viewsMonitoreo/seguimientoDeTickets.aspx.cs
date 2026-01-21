using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using paginaOficial.Controlers;

namespace paginaOficial.viewsMonitoreo
{
    public partial class seguimientoDeTickets : Page
    {
    	private BaseDatos odbusuario;

    	protected ScriptManager ScriptManager1;

    	protected UpdatePanel UpdatePanel1;

    	protected Label Label6;

    	protected DropDownList listEstado;

    	protected DropDownList listAreas;

    	protected Label Label7;

    	protected TextBox txtDesde;

    	protected Label Label8;

    	protected TextBox TxtHasta;

    	protected Button Button1;

    	protected Button btnLimpiar;

    	protected Button btnExportar;

    	protected GridView listTickets;

    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (!User.Identity.IsAuthenticated)
    		{
    			Response.Redirect("~/Login.aspx");
    		}
    		else if ((string)Session["type"] != "7")
    		{
    			Session.Abandon();
    			Session.Clear();
    			FormsAuthentication.SignOut();
    			Response.Redirect("~/login.aspx");
    		}
    		else if (!Page.IsPostBack)
    		{
    			odbusuario = new BaseDatos();
    			DataSet ds = odbusuario.listatickets();
    			listTickets.DataSource = ds.Tables[0];
    			listTickets.DataBind();
    		}
    	}

    	protected void btnfiltrar_Click(object sender, EventArgs e)
    	{
    		odbusuario = new BaseDatos();
    		int estado = (((listEstado.SelectedIndex > 0) & (listEstado.SelectedIndex < 9)) ? Convert.ToInt32(listEstado.SelectedValue) : 0);
    		int area = (((listAreas.SelectedIndex > 0) & (listAreas.SelectedIndex < 9)) ? Convert.ToInt32(listAreas.SelectedValue) : 0);
    		string desde = ((!(txtDesde.Text != string.Empty)) ? "0000-00-00" : txtDesde.Text);
    		string hasta = ((!(TxtHasta.Text != string.Empty)) ? "0000-00-00" : TxtHasta.Text);
    		DataSet ds = odbusuario.filtrolistaTicket(estado, area, desde, hasta);
    		listTickets.DataSource = ds.Tables[0];
    		listTickets.DataBind();
    	}

    	protected void listTickets_PageIndexChanging(object sender, GridViewPageEventArgs e)
    	{
    		listTickets.PageIndex = e.NewPageIndex;
    		btnfiltrar_Click(null, null);
    	}

    	protected void btnLimpiar_Click(object sender, EventArgs e)
    	{
    		// Limpiar controles de filtro
    		listEstado.SelectedIndex = 0;
    		listAreas.SelectedIndex = 0;
    		txtDesde.Text = string.Empty;
    		TxtHasta.Text = string.Empty;

    		// Recargar todos los tickets
    		odbusuario = new BaseDatos();
    		DataSet ds = odbusuario.listatickets();
    		listTickets.DataSource = ds.Tables[0];
    		listTickets.DataBind();
    	}

    	protected void btnExportar_Click(object sender, EventArgs e)
    	{
    		try
    		{
    			// Obtener datos con los filtros actuales
    			odbusuario = new BaseDatos();
    			int estado = (((listEstado.SelectedIndex > 0) & (listEstado.SelectedIndex < 9)) ? Convert.ToInt32(listEstado.SelectedValue) : 0);
    			int area = (((listAreas.SelectedIndex > 0) & (listAreas.SelectedIndex < 9)) ? Convert.ToInt32(listAreas.SelectedValue) : 0);
    			string desde = ((!(txtDesde.Text != string.Empty)) ? "0000-00-00" : txtDesde.Text);
    			string hasta = ((!(TxtHasta.Text != string.Empty)) ? "0000-00-00" : TxtHasta.Text);
    			
    			DataSet ds = (estado > 0 || area > 0 || desde != "0000-00-00" || hasta != "0000-00-00") 
    				? odbusuario.filtrolistaTicket(estado, area, desde, hasta) 
    				: odbusuario.listatickets();

    			if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    			{
    				// Verificar si aplica clasificación: Estado Atendido(3)/Finalizado(5) + Área Desarrollo(4)
    				bool aplicarClasificacion = (estado == 3 || estado == 5) && area == 4;
    				int colProblemaIndex = -1;

    				// Buscar índice de columna "problemas" (puede ser "Problema", "problemas", etc.)
    				for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
    				{
    					string nombreCol = ds.Tables[0].Columns[i].ColumnName.ToLower();
    					if (nombreCol == "problema" || nombreCol == "problemas")
    					{
    						colProblemaIndex = i;
    						break;
    					}
    				}

    				using (ExcelPackage pck = new ExcelPackage())
    				{
    					// Crear hoja de trabajo
    					ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Tickets");

    					// Agregar encabezados originales
    					int colExcel = 1;
    					for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
    					{
    						ws.Cells[1, colExcel].Value = ds.Tables[0].Columns[i].ColumnName;
    						ws.Cells[1, colExcel].Style.Font.Bold = true;
    						ws.Cells[1, colExcel].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
    						ws.Cells[1, colExcel].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
    						colExcel++;

    						// Insertar columnas adicionales después de "Problema"
    						if (aplicarClasificacion && colProblemaIndex >= 0 && i == colProblemaIndex)
    						{
    							// Columna "Usuarios"
    							ws.Cells[1, colExcel].Value = "Usuarios";
    							ws.Cells[1, colExcel].Style.Font.Bold = true;
    							ws.Cells[1, colExcel].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
    							ws.Cells[1, colExcel].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
    							colExcel++;

    							// Columna "Otros"
    							ws.Cells[1, colExcel].Value = "Otros";
    							ws.Cells[1, colExcel].Style.Font.Bold = true;
    							ws.Cells[1, colExcel].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
    							ws.Cells[1, colExcel].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
    							colExcel++;
    						}
    					}

    					// Agregar datos
    					for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    					{
    						colExcel = 1;
    						for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
    						{
    							ws.Cells[i + 2, colExcel].Value = ds.Tables[0].Rows[i][j];
    							colExcel++;

    							// Insertar clasificación después de "Problema"
    							if (aplicarClasificacion && colProblemaIndex >= 0 && j == colProblemaIndex)
    							{
    								string problema = ds.Tables[0].Rows[i][j]?.ToString()?.ToLower() ?? "";
    								bool esUsuario = ClasificarProblemaUsuario(problema);

    								// Columna "Usuarios"
    								ws.Cells[i + 2, colExcel].Value = esUsuario ? 1 : 0;
    								colExcel++;

    								// Columna "Otros"
    								ws.Cells[i + 2, colExcel].Value = esUsuario ? 0 : 1;
    								colExcel++;
    							}
    						}
    					}

    					// Autoajustar columnas
    					ws.Cells[ws.Dimension.Address].AutoFitColumns();

    					// Configurar respuesta HTTP
    					Response.Clear();
    					Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    					Response.AddHeader("content-disposition", $"attachment; filename=Tickets_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
    					
    					// Escribir archivo
    					Response.BinaryWrite(pck.GetAsByteArray());
    					Response.Flush();
    					HttpContext.Current.ApplicationInstance.CompleteRequest();
    				}
    			}
    			else
    			{
    				// No hay datos para exportar
    				Response.Write("<script>alert('No hay datos para exportar.');</script>");
    			}
    		}
    		catch (Exception ex)
    		{
    			// Manejo de errores
    			Response.Write($"<script>alert('Error al exportar: {ex.Message}');</script>");
    		}
    	}

    	private bool ClasificarProblemaUsuario(string problema)
    	{
    		// Palabras clave relacionadas a usuarios/contraseñas/accesos
    		string[] palabrasUsuario = {
    			"usuario", "usuarios", "user", "users",
    			"contraseña", "contraseñas", "password", "passwords", "clave", "claves",
    			"crear usuario", "creacion usuario", "creación usuario", "nuevo usuario",
    			"modificar usuario", "modificacion usuario", "modificación usuario", "editar usuario",
    			"cambio contraseña", "cambiar contraseña", "resetear contraseña", "reset password",
    			"acceso", "accesos", "login", "logeo",
    			"cuenta", "cuentas", "account", "accounts",
    			"permiso", "permisos", "permission", "permissions",
    			"credencial", "credenciales", "credential", "credentials"
    		};

    		foreach (string palabra in palabrasUsuario)
    		{
    			if (problema.Contains(palabra))
    			{
    				return true;
    			}
    		}

    		return false;
    	}
    }

}
