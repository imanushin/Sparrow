using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sparrow.Runner
{
    internal sealed class HttpRequester
    {
        private readonly string pathToApiRoot;
        private readonly string executionId;

        private const string requestTemplate = "{0}/{1}/{2}";

        public HttpRequester(string pathToApiRoot, string executionId)
        {
            this.pathToApiRoot = pathToApiRoot;
            this.executionId = executionId;
        }

        private string GetSimpleRequest(string action)
        {
            return string.Format(requestTemplate, pathToApiRoot, action, executionId);
        }

        public string GetLibraryPath()
        {
            var request = WebRequest.CreateHttp(GetSimpleRequest("getlibrarypath"));

            var response = request.GetResponse();

            return string.Empty;
        }
    }
}
