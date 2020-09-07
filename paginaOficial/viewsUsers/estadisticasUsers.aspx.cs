using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace paginaOficial.viewsUsers
{
    public partial class estadisticasUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text="21";
            Label2.Text = "10";
            Label3.Text = "2";
        }

        //protected void Chart3_Load(object sender, EventArgs e)
        //{
        //    //var myChart = new Chart(width: 600, height: 400)
        //    //.AddTitle("Employees")
        //    //.AddSeries(chartType: "column",
        //    // xValue: new[] { "Peter", "Andrew", "Julie", "Mary", "Dave" },
        //    // yValues: new[] { "2", "6", "4", "5", "3" })
        //    //.Write();
        //}

        protected void Chart2_Load(object sender, EventArgs e)
        {
            var myChart = new Chart(width: 600, height: 400)
            .AddTitle("Employees")
            .AddSeries(chartType: "pie",
             xValue: new[] { "Peter", "Andrew", "Julie", "Mary", "Dave" },
             yValues: new[] { "2", "6", "4", "5", "3" });
            //.Write();

        }
    }
}