using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using Sparrow.Internal;

namespace Sparrow.Web.Models.TestEntry
{
    public sealed class RowTestItem : BaseTestItem
    {
        private readonly string html;

        public RowTestItem(string rawContent, string html)
            : base(rawContent)
        {
            this.html = html;
        }

        protected override string GetHtmlText()
        {
            return html;
        }

        public SingleCommand Command
        {
            get;
            private set;
        }

        internal static RowTestItem TryParse(string rowLine, VariablesStore variablesStore)
        {
            if (!rowLine.StartsWith("|", StringComparison.OrdinalIgnoreCase))
                return null;

            string afterDefines = variablesStore.ApplyVariables(rowLine);

            var sections = afterDefines.Substring(1, afterDefines.Length - 2).Split('|').Select(s => s.Trim());

            var htmlText = new StringBuilder();
            var functionNameText = new StringBuilder();
            var arguments = new List<string>();

            foreach (string section in sections)
            {
                htmlText.Append(@"<td>");

                if (section.StartsWith("'") && section.EndsWith("'"))
                {
                    htmlText.Append("<b>");
                    string functionName = section.Substring(1, section.Length - 2);
                    htmlText.Append(functionName);
                    functionNameText.Append(functionName);
                    htmlText.Append("</b>");
                }
                else
                {
                    htmlText.Append(section);
                    arguments.Add(section);
                }
                htmlText.Append("</td>");
            }

            var result = new RowTestItem(rowLine, htmlText.ToString());

            result.Command = new SingleCommand(functionNameText.ToString(), arguments);

            return result;
        }
    }
}