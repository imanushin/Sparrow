using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow.Runner
{
    internal static class Program
    {
        private static int Main(string[] args)
        {
            Debugger.Launch();

            if (args.Length < 2)
            {
                throw new InvalidOperationException(string.Format("Wrong argument count. Please add following arguments: pathToExecutableController and test execution identity"));
            }

            try
            {
                var pathToApiRoot = args[0];
                var executionId = args[1];

                var requester = new HttpRequester(pathToApiRoot, executionId);

                var libPath = requester.GetLibraryPath();

                return 0;
            }
            catch (Exception ex)
            {
                return 1;
            }

        }
    }
}
