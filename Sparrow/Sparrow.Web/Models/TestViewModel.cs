using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Sparrow.Web.Models
{
    public sealed class TestViewModel
    {
        private static readonly string pathToTests = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData");
        private readonly string absolutePath;
        private readonly string contentsPath;

        public TestViewModel(string testIdentity)
        {
            Name = testIdentity;
            TestIdentity = testIdentity;

            var localTestPath = testIdentity.Replace('.', Path.PathSeparator);
            absolutePath = Path.Combine(pathToTests, localTestPath);
            contentsPath = Path.Combine(absolutePath, "contents.txt");

            IsExists = File.Exists(contentsPath);

            RawContents = IsExists ? File.ReadAllText(contentsPath) : string.Empty;
        }

        public bool IsExists
        {
            get;
            private set;
        }

        public string TestIdentity
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public string RawContents
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
    }
}