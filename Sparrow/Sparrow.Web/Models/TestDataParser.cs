using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Sparrow.Web.Models.TestEntry;

namespace Sparrow.Web.Models
{
    public static class TestDataParser
    {
        public static IReadOnlyList<BaseTestItem> GetTestSteps(string testRawData)
        {
            var lines = testRawData.Split('\n').Select(s => s.Trim()).ToArray();

            var result = new List<BaseTestItem>();

            var variables = new VariablesStore();

            var previousRows = new List<RowTestItem>();

            for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
            {
                string currentLine = lines[lineIndex];

                var defineItem = DefineTestItem.TryParse(currentLine, variables);

                var rowItem = RowTestItem.TryParse(currentLine, variables);

                if (rowItem != null)
                {
                    previousRows.Add(rowItem);

                    continue;
                }
                
                if (previousRows.Any())
                {
                    result.Add(new TableTestItem(previousRows));
                    previousRows.Clear();

                    continue;
                }

                if (defineItem != null)
                {
                    result.Add(defineItem);

                    continue;
                }

                result.Add(new UnknownTestItem(currentLine));
            }

            if (previousRows.Any())
                result.Add(new TableTestItem(previousRows));

            return result;
        }
    }
}