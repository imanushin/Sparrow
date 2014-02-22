using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Sparrow.Web.Models.TestEntry
{
    public sealed class TableTestItem : BaseTestItem
    {
        private readonly IEnumerable<RowTestItem> rows;

        public TableTestItem(IReadOnlyCollection<RowTestItem> rows)
            : base(string.Join(Environment.NewLine, rows.Select(r => r.RawContent)))
        {
            this.rows = rows.ToList();
        }

        protected override string GetHtmlText()
        {
            var result = new StringBuilder();

            result.AppendLine(@"<table border=""1"">");

            foreach (var row in rows)
            {
                result.AppendLine("<tr>");

                result.AppendLine(row.Html);

                result.AppendLine("</tr>");
            }

            result.AppendLine("</table>");

            return result.ToString();
        }
    }
}