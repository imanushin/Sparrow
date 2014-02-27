using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Sparrow.External;
using RouteParameter = System.Web.Http.RouteParameter;

namespace Sparrow.Web
{
    public static class WebApiConfig
    {
        private const string executionApiRouteName = "ExecutionApi";

        public static string GetExecutionControllerRoot(ControllerContext context)
        {
            var request = context.RequestContext.HttpContext.Request;

            var helper = new UrlHelper(context.RequestContext);

            Uri url = request.Url;

            Validate.IsNotNull(url, "Unable to get current url");

            var serverRoot = url.GetLeftPart(UriPartial.Authority) + helper.Content("~");

            return serverRoot + "api/Execution";
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
