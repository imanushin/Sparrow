using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Sparrow.Web.Models
{
    public static class TestDataParser
    {
        public static string ConvertToHtml(string testRawData)
        {
            var lines = testRawData.Split('\n').Select(s => s.Trim()).ToArray();

            var result = new StringBuilder();

            result.AppendLine(@"<table>");
            
            for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
            {
                result.AppendLine(@"<tr style=""min-width: 22px;""><td>");

                string currentLine = lines[lineIndex];

                if (currentLine.StartsWith("!"))
                {
                    result.AppendLine(currentLine);

                    continue;
                }

                if (currentLine.StartsWith("|"))
                {
                    var tableHeight = GetTableHeight(lines, lineIndex);

                    result.AppendLine(ParseTable(lines, lineIndex, tableHeight));

                    lineIndex += tableHeight;
                }

                result.AppendLine("</td></tr>");
            }

            result.AppendLine("</table>");

            return result.ToString();
        }

        private static string ParseTable(string[] lines, int lineIndex, int tableHeight)
        {
            var result = new StringBuilder();

            result.AppendLine(@"<table border=""1"">");

            for (int currentLine = lineIndex; currentLine < lineIndex + tableHeight; currentLine++)
            {
                result.AppendLine("<tr>");

                result.AppendLine(RowToHtml(lines[currentLine]));

                result.AppendLine("</tr>");
            }

            result.AppendLine("</table>");

            return result.ToString();
        }

        private static string RowToHtml(string line)
        {
            var sections = line.Substring(1, line.Length - 2).Split('|').Select(s => s.Trim());

            var result = new StringBuilder();

            foreach (string section in sections)
            {
                result.Append(@"<td>");

                if (section.StartsWith("'") && section.EndsWith("'"))
                {
                    result.Append("<b>");
                    result.Append(section.Substring(1, section.Length - 1));
                    result.Append("</b>");
                }
                else
                {
                    result.Append(section);
                }
                result.Append("</td>");
            }

            return result.ToString();
        }

        private static int GetTableHeight(string[] lines, int startIndex)
        {
            var result = 1;

            while (result + startIndex < lines.Length && lines[startIndex + result].StartsWith("|"))
            {
                result++;
            }

            return result;
        }
    }
}