using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace paginaOficial.viewsAdmin
{
    public partial class estadisticasDiarias : System.Web.UI.Page
    {
        Controlers.BaseDatos odbusuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            else {
                
            odbusuario = new Controlers.BaseDatos();
            int cantidad = (Convert.ToInt32(odbusuario.totalTicketsDia()));
                if (cantidad==0)
                {
                    Panel1.Visible = false;

                    Panel2.Visible = true;
                }
                else {
                    Panel1.Visible = true;

                    Panel2.Visible = false;

                    labelTickets.Text = Convert.ToString(cantidad);
                    //datos de db
                    odbusuario = new Controlers.BaseDatos();
                    DataSet ds = odbusuario.EstadisticaAreaTicketsDiario();

            //conf de pie chart
            pieChartArea.Width = Unit.Pixel(500);
            pieChartArea.Height = Unit.Pixel(400);
            pieChartArea.PlotArea.XAxis.TitleAppearance.Text = "area";
            pieChartArea.PlotArea.YAxis.TitleAppearance.Text = "Tickets";
            pieChartArea.ChartTitle.Text = "Porcentaje por area";
            pieChartArea.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Custom;
            //contenedor de datos tipo pie
            PieSeries datosPie = new PieSeries();
            datosPie.Name = "Datos porcentuales";
            datosPie.LabelsAppearance.Visible = true;
            datosPie.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieAndDonutLabelsPosition.OutsideEnd;
            datosPie.LabelsAppearance.DataFormatString = "{0} %";
            datosPie.TooltipsAppearance.Color = System.Drawing.Color.Black;


            //conf de bar chart
            BarChart1.Width = Unit.Pixel(500);
            BarChart1.Height = Unit.Pixel(400);
            BarChart1.PlotArea.XAxis.TitleAppearance.Text = "area";
            BarChart1.PlotArea.YAxis.TitleAppearance.Text = "Tickets";
            //BarChart1;
            BarChart1.ChartTitle.Text = "Cantidades por area";
            BarChart1.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Right;
            //contenedor de datos tipo bar chart


            //conf de donut chart
            donutChart.Width = Unit.Pixel(800);
            donutChart.Height = Unit.Pixel(500);
            donutChart.PlotArea.XAxis.TitleAppearance.Text = "Etados";
            donutChart.PlotArea.YAxis.TitleAppearance.Text = "Tickets";
            donutChart.ChartTitle.Text = "Cantidades por estados";
            donutChart.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Right;
            //contenedor de datos tipo pie
            DonutSeries datosDonut = new DonutSeries();
            datosDonut.Name = "Cantidades";
            datosDonut.LabelsAppearance.Visible = true;
            datosDonut.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieAndDonutLabelsPosition.OutsideEnd;
            datosDonut.LabelsAppearance.DataFormatString = "{0}";
            datosDonut.TooltipsAppearance.Color = System.Drawing.Color.Black;

            DataTable dt = ds.Tables[1];


            foreach (DataRow row in dt.Rows)
            {
                
                BarSeries datosBar = new BarSeries();
                datosBar.LabelsAppearance.Visible = true;
                datosBar.Name = row[0].ToString();
                datosBar.LabelsAppearance.DataFormatString = "{0}";
                datosBar.TooltipsAppearance.Color = System.Drawing.Color.Black;
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

            foreach (DataRow row in dt.Rows)
            {
                PieSeriesItem dato = new PieSeriesItem(Convert.ToDecimal(row[1].ToString()));
                dato.Name = row[0].ToString();
                datosDonut.SeriesItems.Add(dato);
            }
            donutChart.PlotArea.Series.Add(datosDonut);
            }
            }
        }
    }
}