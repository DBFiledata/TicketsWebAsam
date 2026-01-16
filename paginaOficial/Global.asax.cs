using System;
using System.IO;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using paginaOficial.App_Start;

namespace paginaOficial
{
    public class Global : HttpApplication
    {
    	private void Application_Start(object sender, EventArgs e)
    	{
    		RouteConfig.RegisterRoutes(RouteTable.Routes);
    		BundleConfig.RegisterBundles(BundleTable.Bundles);
    		WebApiConfig.Register(GlobalConfiguration.Configuration);
    		AppOptions appOptions = new AppOptions();
    		appOptions.Credential = GoogleCredential.FromFile(Path.Combine(HttpContext.Current.Server.MapPath("~"), "helpdeskasam-firebase-adminsdk-obfay-de930dbc41.json")).CreateScoped("https://www.googleapis.com/auth/firebase.messaging");
    		FirebaseApp.Create(appOptions);
    	}
    }

}
