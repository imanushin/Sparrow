using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Web;
using Sparrow.External;
using Sparrow.Web.Models;
using Sparrow.Web.Models.TestEntry;

namespace Sparrow.Web.Controllers
{
    internal static class TestExecutor
    {
        private static readonly ConcurrentDictionary<Guid, ExecutingTestData> tests = new ConcurrentDictionary<Guid, ExecutingTestData>();
        private const string runnerPathVariableName = "RUNNER_PATH";

        public static ExecutingTestData StartTest(string testIdentity)
        {
            var test = new TestViewModel(testIdentity);

            var testSteps = TestDataParser.GetTestSteps(test.RawContents);

            var runnerVariable = testSteps.OfType<DefineTestItem>().FirstOrDefault(d => d.VariableName == runnerPathVariableName);

            Validate.IsNotNull(
                runnerVariable,
                "Unable to find runner variable for test {0}. Please define variable {1} with the valid path to the runner executable",
                testIdentity,
                runnerPathVariableName);

            string pathToRunner = runnerVariable.VariableContent;

            if (!File.Exists(pathToRunner))
                pathToRunner = Path.Combine(pathToRunner, "Sparrow.Runner.exe");

            Validate.Condition(File.Exists(pathToRunner), "Unable to find runner executable '{0}'", runnerVariable.VariableContent);

            var runIdentity = Guid.NewGuid();

            var startInfo = new ProcessStartInfo(pathToRunner);
            


            startInfo.Arguments = string.Format("{0} {1}", "", runIdentity);

            var process = new Process()
            {
                StartInfo = startInfo
            };

            var data = new ExecutingTestData(runIdentity, testIdentity, process);

            bool addResult = tests.TryAdd(runIdentity, data);

            Validate.Condition(addResult, "Unable to add data with id {0} for test {1}", runIdentity, testIdentity);

            process.Start();

            return data;
        }

        public static ExecutingTestData GetData(Guid executionId)
        {
            ExecutingTestData result;

            tests.TryGetValue(executionId, out result);

            Validate.IsNotNull(result, "Unable to find execution test for key {0}", executionId);

            return result;
        }
    }
}