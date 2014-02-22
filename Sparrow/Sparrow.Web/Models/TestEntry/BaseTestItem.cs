using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sparrow.Web.Models.TestEntry
{
    public abstract class BaseTestItem
    {
        private string html = null;

        protected BaseTestItem(string rawContent)
        {
            RawContent = rawContent;
        }

        public string RawContent
        {
            get;
            private set;
        }

        protected virtual string GetHtmlText()
        {
            return RawContent;
        }

        public string Html
        {
            get
            {
                if (html == null)
                    html = GetHtmlText();

                return html;
            }
        }
    }
}