using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Sparrow.External.Properties;
using Sparrow.Web.Controllers;

namespace Sparrow.Web.Models
{
    public sealed class TestExecuteModel : BaseTestViewModel
    {
        public TestExecuteModel(string testIdentity, long executionTick)
            : base(testIdentity)
        {
            ExecutionTick = executionTick;
        }

        public long ExecutionTick
        {
            get;
            private set;
        }

        [CanBeNull]
        public static TestExecuteModel FindLastExecuted(string testIdentity)
        {
            var testFolder = TestViewModel.PathToTestFolder(testIdentity);

            var historyFolder = Path.Combine(testFolder, ExecutingTestData.HistorySubfolder);

            if (!Directory.Exists(historyFolder))
                return null;

            var historyFiles = Directory.GetFiles(historyFolder, "*" + ExecutingTestData.HistoryFileExtension, SearchOption.TopDirectoryOnly).ToList();

            var times = new List<long>();

            foreach (string file in historyFiles)
            {
                long res;
                if (long.TryParse(file, out res))
                    times.Add(res);
            }

            if (!times.Any())
                return null;

            var last = times.Max();

            return new TestExecuteModel(testIdentity, last);
        }
    }
}