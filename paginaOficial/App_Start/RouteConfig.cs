using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace paginaOficial
{
    public static class RouteConfig
    {
    	public static void RegisterRoutes(RouteCollection routes)
    	{
    		FriendlyUrlSettings settings = new FriendlyUrlSettings();
    		settings.AutoRedirectMode = RedirectMode.Permanent;
    		routes.EnableFriendlyUrls(settings);
    	}
    }

}
