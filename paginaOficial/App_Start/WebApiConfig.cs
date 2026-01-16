using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace paginaOficial.App_Start
{
    public class WebApiConfig
    {
    	public static void Register(HttpConfiguration configuration)
    	{
    		configuration.Routes.MapHttpRoute("API Default", "{controller}/{action}/{id}", new
    		{
    			id = RouteParameter.Optional
    		});
    		MediaTypeHeaderValue appXmlType = configuration.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault((MediaTypeHeaderValue t) => t.MediaType == "application/xml");
    		configuration.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
    	}
    }

}
