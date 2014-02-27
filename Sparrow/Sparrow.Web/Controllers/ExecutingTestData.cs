using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Sparrow.External;
using Sparrow.Web.Models;
using Sparrow.Web.Models.TestEntry;

namespace Sparrow.Web.Controllers
{
    internal sealed class ExecutingTestData
    {
        public const string HistorySubfolder = "_history";
        public const string HistoryFileExtension = ".history";

        private const string TestContainerVariableName = "TEST_CONTAINER";

        private IReadOnlyList<BaseTestItem> testSteps;

        public ExecutingTestData(Guid runIdentity, string testIdentity, Process process)
        {
            RunIdentity = runIdentity;
            TestIdentity = testIdentity;
            RunningProcess = process;
            ExecutionId = DateTime.UtcNow.Ticks;

            string pathToTest = TestViewModel.PathToTestFolder(testIdentity);

            testSteps = TestDataParser.GetTestSteps(File.ReadAllText(pathToTest));

            var testFolder = TestViewModel.PathToTestFolder(testIdentity);

            var historyFolder = Path.Combine(testFolder, HistorySubfolder);

            var fileName = ExecutionId + HistoryFileExtension;

            HistoryFilePath = Path.Combine(historyFolder, fileName);
        }

        public void WriteError(string error)
        {
            File.AppendAllText(HistoryFilePath, @"error:" + error);
        }

        public long ExecutionId
        {
            get;
            private set;
        }

        public string HistoryFilePath
        {
            get;
            private set;
        }

        public Guid RunIdentity
        {
            get;
            private set;
        }

        public string TestIdentity
        {
            get;
            private set;
        }

        public Process RunningProcess
        {
            get;
            set;
        }

        public string LibraryPath
        {
            get
            {
                var testLibraryVariables = testSteps.OfType<DefineTestItem>().Where(d => string.Equals(d.VariableName, TestContainerVariableName, StringComparison.OrdinalIgnoreCase)).ToArray();

                Validate.CollectionHasElements(testLibraryVariables, "Unable to find path to the library with tests. Please define variable {0} and put path to the test container", TestContainerVariableName);

                var result = string.Join(";", testLibraryVariables.Select(v => v.VariableContent));

                return result;
            }
        }
    }
}