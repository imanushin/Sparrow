using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Sparrow.Web.Models
{
    public sealed class TestViewModel : BaseTestViewModel
    {
        private static readonly string pathToTests = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData");
        private readonly string absolutePath;
        private readonly string contentsPath;

        public TestViewModel(string testIdentity)
            : base(testIdentity)
        {
            var localTestPath = PathToTestFolder(testIdentity);
            absolutePath = Path.Combine(pathToTests, localTestPath);
            contentsPath = Path.Combine(absolutePath, "contents.txt");

            IsExists = File.Exists(contentsPath);

            RawContents = IsExists ? File.ReadAllText(contentsPath) : string.Empty;
        }

        public string RawContents
        {
            get;
            private set;
        }

        public bool IsExists
        {
            get;
            private set;
        }

        public void SaveNewTest(string newData)
        {
            if (!Directory.Exists(absolutePath))
                Directory.CreateDirectory(absolutePath);

            File.WriteAllText(contentsPath, newData);
        }

        public static string PathToTestFolder(string testIdentity)
        {
            return testIdentity.Replace('.', Path.PathSeparator);
        }
    }
}