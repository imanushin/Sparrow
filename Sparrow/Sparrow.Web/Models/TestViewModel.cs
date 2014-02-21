using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Sparrow.Web.Models
{
    public sealed class TestViewModel
    {
        private static readonly string pathToTests = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData");
        private readonly string absolutePath;

        public TestViewModel(string testIdentity)
        {
            Name = testIdentity;
            TestIdentity = testIdentity;

            var localTestPath = testIdentity.Replace('.', Path.PathSeparator);
            absolutePath = Path.Combine(pathToTests, localTestPath);

            IsExists = File.Exists(absolutePath);

            RawContents = IsExists ? File.ReadAllText(absolutePath) : string.Empty;
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
            File.WriteAllText(absolutePath, newData);
        }
    }
}