using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sparrow.Web.Models;

namespace Sparrow.Web.Controllers
{
    internal static class TestExecutor
    {
        private sealed class ExecutingTestData
        {

        }

        private static readonly ConcurrentDictionary<Guid, ExecutingTestData> tests = new ConcurrentDictionary<Guid, ExecutingTestData>();

        public static void StartTest(string test)
        {
        }
    }
}