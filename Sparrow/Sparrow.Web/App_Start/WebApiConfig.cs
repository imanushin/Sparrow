using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using RouteParameter = System.Web.Http.RouteParameter;

namespace Sparrow.Web
{
    public static class WebApiConfig
    {
        private const string executionApiRouteName = "ExecutionApi";

        public static string GetExecutionControllerRoot(ControllerContext context)
        {
            var url = new UrlHelper(context.RequestContext);

            return url.HttpRouteUrl(executionApiRouteName, new
            {
                controller = "Execution"
            });
        }

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Map this rule first
            config.Routes.MapHttpRoute(
                 executionApiRouteName,
                 "api/{controller}/{action}/{executionId}"
             );
        }
    }
}
