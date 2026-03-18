using System;
using System.Data;
using System.Drawing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using paginaOficial.Controlers;
using Telerik.Web.UI;
using Telerik.Web.UI.HtmlChart;

namespace paginaOficial.viewsTrabajosProgramados
{
    public partial class estadisticasDiariasTProgramado : Page
    {
    	private BaseDatos odbusuario;

    	protected RadScriptManager RadScriptManager2;

    	protected Panel Panel1;

    	protected Label labelTickets;

    	protected RadHtmlChart pieChartArea;

    	protected RadHtmlChart BarChart1;

    	protected RadHtmlChart donutChart;

    	protected Panel Panel2;

    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (!User.Identity.IsAuthenticated)
    		{
    			Response.Redirect("~/Login.aspx");
    			return;
    		}
    		if ((string)Session["type"] != "8")
    		{
    			Session.Abandon();
    			Session.Clear();
    			FormsAuthentication.SignOut();
    			Response.Redirect("~/login.aspx");
    			return;
    		}
    		odbusuario = new BaseDatos();
    		int cantidad = Convert.ToInt32(odbusuario.totalTicketsDia());
    		if (cantidad == 0)
    		{
    			Panel1.Visible = false;
    			Panel2.Visible = true;
    			return;
    		}
    		Panel1.Visible = true;
    		Panel2.Visible = false;
    		labelTickets.Text = Convert.ToString(cantidad);
    		odbusuario = new BaseDatos();
    		DataSet ds = odbusuario.EstadisticaAreaTicketsDiario();
    		pieChartArea.Width = Unit.Pixel(500);
    		pieChartArea.Height = Unit.Pixel(400);
    		pieChartArea.PlotArea.XAxis.TitleAppearance.Text = "area";
    		pieChartArea.PlotArea.YAxis.TitleAppearance.Text = "Tickets";
    		pieChartArea.ChartTitle.Text = "Porcentaje por area";
    		pieChartArea.Legend.Appearance.Position = ChartLegendPosition.Custom;
    		PieSeries datosPie = new PieSeries();
    		datosPie.Name = "Datos porcentuales";
    		datosPie.LabelsAppearance.Visible = true;
    		datosPie.LabelsAppearance.Position = PieAndDonutLabelsPosition.OutsideEnd;
    		datosPie.LabelsAppearance.DataFormatString = "{0} %";
    		datosPie.TooltipsAppearance.Color = Color.Black;
    		BarChart1.Width = Unit.Pixel(500);
    		BarChart1.Height = Unit.Pixel(400);
    		BarChart1.PlotArea.XAxis.TitleAppearance.Text = "area";
    		BarChart1.PlotArea.YAxis.TitleAppearance.Text = "Tickets";
    		BarChart1.ChartTitle.Text = "Cantidades por area";
    		BarChart1.Legend.Appearance.Position = ChartLegendPosition.Right;
    		donutChart.Width = Unit.Pixel(800);
    		donutChart.Height = Unit.Pixel(500);
    		donutChart.PlotArea.XAxis.TitleAppearance.Text = "Etados";
    		donutChart.PlotArea.YAxis.TitleAppearance.Text = "Tickets";
    		donutChart.ChartTitle.Text = "Cantidades por estados";
    		donutChart.Legend.Appearance.Position = ChartLegendPosition.Right;
    		DonutSeries datosDonut = new DonutSeries();
    		datosDonut.Name = "Cantidades";
    		datosDonut.LabelsAppearance.Visible = true;
    		datosDonut.LabelsAppearance.Position = PieAndDonutLabelsPosition.OutsideEnd;
    		datosDonut.LabelsAppearance.DataFormatString = "{0}";
    		datosDonut.TooltipsAppearance.Color = Color.Black;
    		DataTable dt = ds.Tables[1];
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
    		ds = odbusuario.EstadisticaEstadosTicketsDiario();
    		dt = ds.Tables[0];
    		foreach (DataRow row2 in dt.Rows)
    		{
    			PieSeriesItem dato = new PieSeriesItem(Convert.ToDecimal(row2[1].ToString()));
    			dato.Name = row2[0].ToString();
    			datosDonut.SeriesItems.Add(dato);
    		}
    		donutChart.PlotArea.Series.Add(datosDonut);
    	}
    }

}
