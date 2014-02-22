using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sparrow.Web.Models.TestEntry
{
    public sealed class UnknownTestItem : BaseTestItem
    {
        public UnknownTestItem(string rawContent)
            : base(rawContent)
        {
        }

    }
}