using System;
using System.Diagnostics;
using System.IO;
using Sparrow.Web.Models;

namespace Sparrow.Web.Controllers
{
    internal sealed class ExecutingTestData
    {
        public const string HistorySubfolder = "_history";
        public const string HistoryFileExtension = ".history";


        public ExecutingTestData(Guid runIdentity, string testIdentity, Process process)
        {
            RunIdentity = runIdentity;
            TestIdentity = testIdentity;
            RunningProcess = process;
            ExecutionId = DateTime.UtcNow.Ticks;

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
    }
}