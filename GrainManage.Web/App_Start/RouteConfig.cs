using System.Web.Mvc;
using System.Web.Routing;

namespace GrainManage.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "SignIn", id = UrlParameter.Optional }
                //defaults: new { controller = "Contact", action = "SearchContacts", id = UrlParameter.Optional }
                //defaults: new { controller = "Price", action = "SearchRecentPrice", id = UrlParameter.Optional }
                //defaults: new { controller = "Trade", action = "EditTrade", id = UrlParameter.Optional }
            );
        }
    }
}