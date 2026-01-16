using System;
using System.Data;
using System.Drawing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;
using Telerik.Web.UI;
using Telerik.Web.UI.HtmlChart;

namespace paginaOficial.viewsAdmin
{
    public partial class EstadisticasFiltro : Page
    {
    	private BaseDatos odbusuario;

    	protected RadScriptManager RadScriptManager2;

    	protected Label Label4;

    	protected DropDownList dlistArea;

    	protected Label Label3;

    	protected DropDownList dlistTecnico;

    	protected Label Label1;

    	protected TextBox txtDesde;

    	protected Label Label2;

    	protected TextBox TxtHasta;

    	protected Button btnFiltrar;

    	protected Panel Panel1;

    	protected Panel Panel2;

    	protected Label labelVisitasTotal;

    	protected RadHtmlChart pieChartArea;

    	protected RadHtmlChart BarChart1;

    	protected Panel Panel3;

    	protected Panel Panel4;

    	protected RadHtmlChart lineChart;

    	protected Panel Panel7;

    	protected RadHtmlChart donutChart;

    	protected RadHtmlChart barChartArea;

    	protected RadHtmlChart lineChart1;

    	protected Panel Panel5;

    	protected GridView gridViewCantidades;

    	protected Panel Panel6;

    	protected GridView gridViewHistorico;

    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (!User.Identity.IsAuthenticated)
    		{
    			Response.Redirect("~/Login.aspx");
    		}
    		else if ((string)Session["type"] != "6")
    		{
    			Session.Abandon();
    			Session.Clear();
    			FormsAuthentication.SignOut();
    			Response.Redirect("~/login.aspx");
    		}
    		if (!Page.IsPostBack)
    		{
    			odbusuario = new BaseDatos();
    			DataSet ds1 = odbusuario.tipoTecnico();
    			dlistArea.Items.Clear();
    			dlistArea.DataSource = ds1;
    			dlistArea.DataBind();
    			dlistArea.Items.Insert(0, "\ud83c\udfdb\ufe0f Seleccionar");
    			DateTime fechaTresMesesAntes = DateTime.Now.Date.AddMonths(-3);
    			txtDesde.Text = fechaTresMesesAntes.ToString("yyyy-MM-dd");
    			DateTime? desde = null;
    			desde = VerificarCampoFecha(txtDesde);
    			DataSet ds2 = new DataSet();
    			ds2 = filtros(null, null, desde, null);
    			cargarData(ds2);
    		}
    	}

    	protected void btnFiltrar_Click(object sender, EventArgs e)
    	{
    		try
    		{
    			int? area = null;
    			string tecnico = "";
    			DateTime? desde = null;
    			DateTime? hasta = null;
    			area = VerificarDList(dlistArea);
    			tecnico = VerificarDListText(dlistTecnico);
    			desde = VerificarCampoFecha(txtDesde);
    			hasta = VerificarCampoFecha(TxtHasta);
    			DataSet ds = new DataSet();
    			ds = filtros(area, tecnico, desde, hasta);
    			cargarData(ds);
    		}
    		catch (Exception)
    		{
    			ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "alert('Error no se pudo aplicar filtro');", addScriptTags: true);
    		}
    	}

    	protected int? VerificarDList(DropDownList list)
    	{
    		try
    		{
    			if (list.SelectedValue != "")
    			{
    				if (Convert.ToInt32(list.SelectedIndex) > 0)
    				{
    					return Convert.ToInt32(list.SelectedValue);
    				}
    				return null;
    			}
    			return null;
    		}
    		catch (Exception)
    		{
    			return 0;
    		}
    	}

    	protected string VerificarDListText(DropDownList list)
    	{
    		try
    		{
    			if (list.SelectedValue != "")
    			{
    				if (Convert.ToInt32(list.SelectedIndex) > 0)
    				{
    					return Convert.ToString(list.SelectedValue);
    				}
    				return "";
    			}
    			return "";
    		}
    		catch (Exception)
    		{
    			return "";
    		}
    	}

    	protected DateTime? VerificarCampoFecha(TextBox txt)
    	{
    		if (!string.IsNullOrEmpty(txt.Text))
    		{
    			return Convert.ToDateTime(txt.Text);
    		}
    		return null;
    	}

    	protected DataSet filtros(int? area, string tecnicos, DateTime? desde, DateTime? hasta)
    	{
    		DataSet ds = new DataSet();
    		odbusuario = new BaseDatos();
    		if (!string.IsNullOrEmpty(tecnicos))
    		{
    			return odbusuario.EstadisticasUsuarioFiltro(tecnicos, desde, hasta);
    		}
    		return odbusuario.EstadisticasAreasFiltro(area, desde, hasta);
    	}

    	protected void cargarData(DataSet ds)
    	{
    		// Validar que el DataSet tenga tablas antes de acceder
    		if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
    		{
    			Panel2.Visible = false;
    			Panel1.Visible = true;
    			Panel4.Visible = false;
    			Panel3.Visible = true;
    			return;
    		}
    		
    		int cantidadTotal = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[0]["total"]));
    		if (cantidadTotal == 0)
    		{
    			Panel2.Visible = false;
    			Panel1.Visible = true;
    			Panel4.Visible = false;
    			Panel3.Visible = true;
    			return;
    		}
    		Panel2.Visible = true;
    		PieSeries datosPie = new PieSeries();
    		DonutSeries datosDonut = new DonutSeries();
    		(PieSeries, DonutSeries) tuple = configCharts();
    		datosPie = tuple.Item1;
    		datosDonut = tuple.Item2;
    		
    		// Validar que exista la tabla 2 (índice 2 = tercera tabla)
    		if (ds.Tables.Count < 3 || ds.Tables[2].Rows.Count == 0)
    		{
    			Panel2.Visible = false;
    			Panel1.Visible = true;
    			Panel4.Visible = false;
    			Panel3.Visible = true;
    			return;
    		}
    		
    		DataTable dt = ds.Tables[2];
    		foreach (DataRow row in dt.Rows)
    		{
    			BarSeries datosBar = new BarSeries();
    			datosBar.LabelsAppearance.Visible = true;
    			datosBar.Name = row[0].ToString();
    			datosBar.LabelsAppearance.DataFormatString = "{0}";
    			datosBar.TooltipsAppearance.Color = Color.Black;
    			CategorySeriesItem datoBar = new CategorySeriesItem(Convert.ToDecimal(row[2].ToString()));
    			datosBar.SeriesItems.Add(datoBar);
    			PieSeriesItem datos = new PieSeriesItem(Convert.ToDecimal(row[1].ToString()));
    			datos.Name = row[0].ToString();
    			datosPie.SeriesItems.Add(datos);
    			BarChart1.PlotArea.Series.Add(datosBar);
    		}
    		pieChartArea.PlotArea.Series.Add(datosPie);
    		Panel4.Visible = true;
    		labelVisitasTotal.Text = Convert.ToString(cantidadTotal);
    		DataTable tbl = ds.Tables[3];
    		lineChart.DataSource = tbl;
    		lineChart.DataBind();
    		if (ds.Tables.Count >= 5)
    		{
    			Panel5.Visible = true;
    			gridViewCantidades.DataSource = ds.Tables[4];
    			gridViewCantidades.DataBind();
    			if (dlistArea.SelectedIndex == 0)
    			{
    				Panel7.Visible = true;
    				DataTable dt2 = ds.Tables[6];
    				foreach (DataRow row2 in dt2.Rows)
    				{
    					BarSeries datosBar2 = new BarSeries();
    					datosBar2.LabelsAppearance.Visible = true;
    					datosBar2.Name = row2[0].ToString();
    					datosBar2.LabelsAppearance.DataFormatString = "{0}";
    					datosBar2.TooltipsAppearance.Color = Color.Black;
    					CategorySeriesItem datoBar2 = new CategorySeriesItem(Convert.ToDecimal(row2[2].ToString()));
    					datosBar2.SeriesItems.Add(datoBar2);
    					barChartArea.PlotArea.Series.Add(datosBar2);
    				}
    				foreach (DataRow row3 in dt2.Rows)
    				{
    					PieSeriesItem dato = new PieSeriesItem(Convert.ToDecimal(row3[1].ToString()));
    					dato.Name = row3[0].ToString();
    					datosDonut.SeriesItems.Add(dato);
    				}
    				donutChart.PlotArea.Series.Add(datosDonut);
    				DataTable tbl2 = ds.Tables[7];
    				lineChart1.DataSource = tbl2;
    				lineChart1.DataBind();
    			}
    			else
    			{
    				Panel7.Visible = false;
    			}
    		}
    		else
    		{
    			Panel5.Visible = false;
    			Panel7.Visible = false;
    		}
    		gridViewHistorico.DataSource = ds.Tables[1];
    		gridViewHistorico.DataBind();
    	}

    	public (PieSeries, DonutSeries) configCharts()
    	{
    		pieChartArea.PlotArea.Series.Clear();
    		pieChartArea.Width = Unit.Pixel(650);
    		pieChartArea.Height = Unit.Pixel(500);
    		pieChartArea.PlotArea.XAxis.TitleAppearance.Text = "Estados";
    		pieChartArea.PlotArea.YAxis.TitleAppearance.Text = "Tickets";
    		pieChartArea.ChartTitle.Text = "Porcentaje por estado";
    		pieChartArea.Legend.Appearance.Position = ChartLegendPosition.Custom;
    		PieSeries datosPie = new PieSeries();
    		datosPie.Name = "Datos porcentuales";
    		datosPie.LabelsAppearance.Visible = true;
    		datosPie.LabelsAppearance.Position = PieAndDonutLabelsPosition.OutsideEnd;
    		datosPie.LabelsAppearance.DataFormatString = "{0} %";
    		datosPie.TooltipsAppearance.Color = Color.Black;
    		BarChart1.PlotArea.Series.Clear();
    		BarChart1.Width = Unit.Pixel(650);
    		BarChart1.Height = Unit.Pixel(500);
    		BarChart1.PlotArea.XAxis.TitleAppearance.Text = "Estados";
    		BarChart1.PlotArea.YAxis.TitleAppearance.Text = "Tickets";
    		BarChart1.ChartTitle.Text = "Cantidades por Estados";
    		BarChart1.Legend.Appearance.Position = ChartLegendPosition.Right;
    		lineChart.Height = Unit.Pixel(500);
    		lineChart.PlotArea.XAxis.LabelsAppearance.RotationAngle = -45;
    		lineChart.PlotArea.XAxis.TitleAppearance.Text = "fecha";
    		lineChart.ToolTip = "Fecha: #= category #, Valor: #= value #";
    		lineChart.ChartTitle.Text = "Cantidad mensual";
    		lineChart.Legend.Appearance.Position = ChartLegendPosition.Right;
    		donutChart.PlotArea.Series.Clear();
    		donutChart.Width = Unit.Pixel(650);
    		donutChart.Height = Unit.Pixel(500);
    		donutChart.PlotArea.XAxis.TitleAppearance.Text = "Areas";
    		donutChart.PlotArea.YAxis.TitleAppearance.Text = "Tickets";
    		donutChart.ChartTitle.Text = "Porcentaje por area";
    		donutChart.Legend.Appearance.Position = ChartLegendPosition.Right;
    		DonutSeries datosDonut = new DonutSeries();
    		datosDonut.Name = "Cantidades";
    		datosDonut.LabelsAppearance.Visible = true;
    		datosDonut.LabelsAppearance.Position = PieAndDonutLabelsPosition.OutsideEnd;
    		datosDonut.LabelsAppearance.DataFormatString = "{0}";
    		datosDonut.TooltipsAppearance.Color = Color.Black;
    		PieSeries datosPie2 = new PieSeries();
    		datosPie.Name = "Datos porcentuales por area";
    		datosPie.LabelsAppearance.Visible = true;
    		datosPie.LabelsAppearance.Position = PieAndDonutLabelsPosition.OutsideEnd;
    		datosPie.LabelsAppearance.DataFormatString = "{0} %";
    		datosPie.TooltipsAppearance.Color = Color.Black;
    		barChartArea.PlotArea.Series.Clear();
    		barChartArea.Width = Unit.Pixel(650);
    		barChartArea.Height = Unit.Pixel(500);
    		barChartArea.PlotArea.XAxis.TitleAppearance.Text = "Area";
    		barChartArea.PlotArea.YAxis.TitleAppearance.Text = "Tickets";
    		barChartArea.ChartTitle.Text = "Cantidades por area";
    		barChartArea.Legend.Appearance.Position = ChartLegendPosition.Right;
    		lineChart1.Height = Unit.Pixel(500);
    		lineChart1.PlotArea.XAxis.LabelsAppearance.RotationAngle = -45;
    		lineChart1.PlotArea.XAxis.TitleAppearance.Text = "Fecha";
    		lineChart1.ToolTip = "Fecha: #= category #, Valor: #= value #";
    		lineChart1.ChartTitle.Text = "Cantidad mensual";
    		lineChart1.Legend.Appearance.Position = ChartLegendPosition.Right;
    		return (datosPie, datosDonut);
    	}

    	protected void dlistArea_SelectedIndexChanged(object sender, EventArgs e)
    	{
    		try
    		{
    			int eleccion = 0;
    			odbusuario = new BaseDatos();
    			if (dlistArea.SelectedValue != "\ud83c\udfdb\ufe0f Seleccionar")
    			{
    				eleccion = Convert.ToInt32(dlistArea.SelectedValue);
    				if (eleccion > 0)
    				{
    					odbusuario = new BaseDatos();
    					DataSet ds = odbusuario.dListTecnico(Convert.ToInt32(dlistArea.SelectedItem.Value));
    					dlistTecnico.Items.Clear();
    					dlistTecnico.DataSource = ds;
    					dlistTecnico.DataBind();
    					dlistTecnico.Items.Insert(0, "\ud83d\udc77\u200d Seleccionar");
    					dlistTecnico.Enabled = true;
    				}
    				else
    				{
    					dlistTecnico.Items.Clear();
    					dlistTecnico.Enabled = false;
    				}
    			}
    			else
    			{
    				dlistTecnico.Items.Clear();
    				dlistTecnico.Enabled = false;
    			}
    		}
    		catch (Exception)
    		{
    		}
    	}

    	protected void gridViewHistorico_PageIndexChanging(object sender, GridViewPageEventArgs e)
    	{
    		gridViewHistorico.PageIndex = e.NewPageIndex;
    		btnFiltrar_Click(null, null);
    	}

    	protected void gridViewHistorico_RowDataBound(object sender, GridViewRowEventArgs e)
    	{
    	}

    	protected void gridViewCantidades_PageIndexChanging(object sender, GridViewPageEventArgs e)
    	{
    		gridViewHistorico.PageIndex = e.NewPageIndex;
    		btnFiltrar_Click(null, null);
    	}
    }

}
