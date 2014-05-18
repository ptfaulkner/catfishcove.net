using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebGrease.Css.Ast.Selectors;

namespace CatfishCove.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "Catering", url: "catering", defaults: new {controller = "Home", action = "Catering"});
            routes.MapRoute(name: "Directions", url: "directions", defaults: new { controller = "Home", action = "Directions" });
            routes.MapRoute(name: "Contact", url: "contact", defaults: new { controller = "Home", action = "Contact" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
