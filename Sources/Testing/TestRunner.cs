//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static System.Array;
using static System.Console;
using static System.IO.File;
using static System.IO.Directory;
using static System.IO.Path;
using static System.TimeSpan;
using static System.DateTimeOffset;

using static Neu.PathHelpers;
using static Neu.ConsoleHelpers;

namespace Neu
{
    public abstract partial class TestRunner
    {
        public TestRunner() { }

        public abstract IEnumerable<TestRun> Run();
    }

    public partial class TestRunner
    {
        public static void PrintTestStatistics(
            IEnumerable<TestRun> testRuns)
        {
            var successful = testRuns
                .Where(x => x.Result == TestResult.Success);

            if (successful.Count() > 0)
            {
                WriteGreenLine(2, $"Successful: {successful.Count()} ({successful.Sum(x => x.TimeElapsed())} ms)");

                foreach (var s in successful)
                {
                    WriteGreenLine(4, $"{s.Filename} ({s.TimeElapsed()} ms)");
                }
            }

            ///

            var failed = testRuns
                .Where(x => x.Result == TestResult.Failure);

            if (failed.Count() > 0)
            {
                WriteRedLine(2, $"Failed: {failed.Count()}");

                foreach (var f in failed)
                {
                    WriteRedLine(4, $"{f.Filename} ({f.TimeElapsed()} ms)");
                }
            }

            ///

            var unsupported = testRuns
                .Where(x => x.Result == TestResult.Unsupported);

            if (unsupported.Count() > 0)
            {
                WriteYellowLine(2, $"Unsupported: {unsupported.Count()}");

                foreach (var u in unsupported)
                {
                    WriteYellowLine(4, $"{u}");
                }
            }
        }
    }
}