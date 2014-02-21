using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace Sparrow.Web
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var viewDefaults = new
            {
                controller = "Default",
                action = "View",
                testIdentity = ""
            };

            routes.MapRoute(
                name: "Empty",
                url: "",
                defaults: viewDefaults
            );

            routes.MapRoute(
                name: "Default",
                url: "{testIdentity}",
                defaults: viewDefaults
            );
        }
    }
}
