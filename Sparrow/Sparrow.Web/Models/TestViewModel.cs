using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sparrow.Web.Models
{
    public sealed class TestViewModel
    {
        public TestViewModel(string testName)
        {
            Name = testName;
        }

        public string Name
        {
            get;
            private set;
        }
    }
}