using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sparrow.Web.Models.TestEntry
{
    internal sealed class VariablesStore
    {
        private readonly Dictionary<string, string> variables = new Dictionary<string, string>();

        public VariablesStore()
        {
        }

        public void Add(string variable, string content)
        {
            variables[string.Format("${{{0}}}", variable)] = content;
        }

        public string ApplyVariables(string data)
        {
            var result = data;

            foreach (KeyValuePair<string, string> variable in variables)
            {
                result = result.Replace(variable.Key, variable.Value);
            }

            return result;
        }
    }
}