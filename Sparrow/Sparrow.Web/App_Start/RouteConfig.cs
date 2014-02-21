using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sparrow.Web
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: "Default",
                url: "{action}/{testIdentity}",
                defaults: new
                {
                    controller = "Default",
                    action = "View",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}
