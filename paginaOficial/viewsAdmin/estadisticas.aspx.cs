using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Charting;
using Telerik.Web.UI;


namespace paginaOficial.viewsAdmin
{
    public partial class estadisticas : System.Web.UI.Page
    {

        Controlers.BaseDatos odbusuario;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }

            odbusuario = new Controlers.BaseDatos();
            labelVisitasMensual.Text = odbusuario.totalTicketsMes();

            odbusuario = new Controlers.BaseDatos();
            labelVisitasTotal.Text = odbusuario.totalTickets();
            
                

            //datos de db
            odbusuario = new Controlers.BaseDatos();
            DataSet ds = odbusuario.EstadisticaAreaTickets();
            
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
            BarChart1.ChartTitle.Text= "Cantidades por area";
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



            //conf de line chart
            lineChart.Width = Unit.Pixel(1000);
            lineChart.Height = Unit.Pixel(500);
            lineChart.PlotArea.XAxis.TitleAppearance.Text = "meses";
            lineChart.PlotArea.YAxis.TitleAppearance.Text = "Tickets";
            lineChart.ChartTitle.Text = "Cantidades mensuales por area";
            lineChart.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Right;
            //contenedor de datos line



            DataTable dt = ds.Tables[1];


            foreach (DataRow row in dt.Rows)
            {
                //if (row[0].ToString() == "Soporte Tecnico")
                //{
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

            //line chart
            DataSet dsLine = odbusuario.EstadisticaAreaTicketsMeses();
            DataTable tbl = dsLine.Tables[0];
            lineChart.DataSource = tbl;
            lineChart.DataBind();

            ds = odbusuario.EstadisticaEstadosTicketsMensual();
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

        //protected void Timer1_Tick(object sender, EventArgs e)
        //{
        //}

}
