using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sparrow.Web.Models.TestEntry
{
    public sealed class DefineTestItem : BaseTestItem
    {
        private const string preffix = "!define";
        private const string delimeter = "=>";

        private DefineTestItem(string rawContent)
            : base(rawContent)
        {
        }

        public string VariableName
        {
            get;
            private set;
        }

        public string VariableContent
        {
            get;
            private set;
        }

        internal static DefineTestItem TryParse(string rawContent, VariablesStore variablesStore)
        {
            if (!rawContent.StartsWith(preffix, StringComparison.OrdinalIgnoreCase))
                return null;

            var defineValue = rawContent.Substring(preffix.Length);

            int delimeterIndex = defineValue.IndexOf(delimeter, StringComparison.OrdinalIgnoreCase);

            if (delimeterIndex < 0)
                return null;

            var result = new DefineTestItem(rawContent);

            result.VariableName = defineValue.Substring(0, delimeterIndex).Trim();

            var content = defineValue.Substring(delimeterIndex + delimeter.Length).Trim();

            result.VariableContent = variablesStore.ApplyVariables(content);

            variablesStore.Add(result.VariableName, content);

            return result;
        }
    }
}