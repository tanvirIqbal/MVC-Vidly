using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            //routes.MapRoute(
            //    name: "Customers",
            //    url: "Customers",
            //    defaults: new { controller = "Customer", action = "ShowCustomers", id = UrlParameter.Optional }
            //);
            //routes.MapRoute(
            //    name: "Movies",
            //    url: "Movies",
            //    defaults: new { controller = "Movies", action = "ShowMovies", id = UrlParameter.Optional }
            //);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
