using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sparrow.Web.Models
{
    public sealed class TestExecuteModel : BaseTestViewModel
    {
        public TestExecuteModel(string testIdentity)
            : base(testIdentity)
        {
        }
    }
}