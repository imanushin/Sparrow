using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sparrow.Web.Models
{
    public sealed class TestViewModel
    {
        public TestViewModel(string testIdentity)
        {
            Name = testIdentity;
            TestIdentity = testIdentity;
        }

        public string TestIdentity
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }
    }
}