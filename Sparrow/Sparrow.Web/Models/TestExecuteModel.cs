using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Sparrow.External.Properties;

namespace Sparrow.Web.Models
{
    public sealed class TestExecuteModel : BaseTestViewModel
    {
        private const string historySubfolder = "_history";

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

            var historyFolder = Path.Combine(testFolder, historySubfolder);

            if (!Directory.Exists(historyFolder))
                return null;

            var historyFiles = Directory.GetFiles(historyFolder, "*.history", SearchOption.TopDirectoryOnly).ToList();

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