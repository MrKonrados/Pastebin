using System.Web.Mvc;
using System.Web.Routing;

namespace Pastebin
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: "Paste",
                 url: "{url}",
                 defaults: new { controller = "Paste", action = "Detail" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Paste", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Languages",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Languages", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
