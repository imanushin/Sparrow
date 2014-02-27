using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Ajax.Utilities;

namespace Sparrow.Web.Controllers
{
    public sealed class ExecutionController : ApiController
    {
        [HttpGet]
        public string GetLibraryPath(Guid id)
        {
            var test = TestExecutor.GetData(id);

            return test.LibraryPath;
        }

        // GET api/execution/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/execution
        public void Post([FromBody]string value)
        {
        }

        // PUT api/execution/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/execution/5
        public void Delete(int id)
        {
        }
    }
}
