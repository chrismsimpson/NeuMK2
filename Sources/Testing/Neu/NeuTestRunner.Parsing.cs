//
//
//

using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    public static partial class NeuTestRunnerHelpers
    {
        private static IEnumerable<NeuTestRun> RunParsingSuite(
            this NeuTestRunner runner,
            String neuTestsDir)
        {
            var parsingDir = Combine(neuTestsDir, "Parsing");

            ///

            foreach (var testRun in runner.RunControlFlowParsingSuite(parsingDir))
            {
                yield return testRun;
            }
        }

        private static IEnumerable<NeuTestRun> RunParseTests(
            this NeuTestRunner runner,
            IEnumerable<String> tests)
        {
            foreach (var test in tests)
            {
                yield return runner.RunParseTest(test);
            }
        }

        private static NeuTestRun RunParseTest(
            this NeuTestRunner runner,
            String file)
        {
            var extension = GetExtension(file);

            if (extension != ".neu")
            {
                return new NeuTestRun(
                    filename: file, 
                    result: TestResult.Unsupported);
            }
             
            ///

            var parser = NeuParser.FromFile(file);

            ///

            var start = UtcNow.UtcTicks;

            try
            {
                var sourceFile = parser.ParseSourceFile();

                if (runner.DumpAST)
                {
                    Write($"\n//\n// Filename: {file}\n//\n\n{sourceFile.Dump()}\n");
                }

                return new NeuTestRun(
                    filename: file,
                    start: start,
                    end: UtcNow.UtcTicks,
                    result: TestResult.Success);
            }
            catch
            {
                return new NeuTestRun(
                    filename: file,
                    start: start,
                    end: UtcNow.UtcTicks,
                    result: TestResult.Failure);
            }
        }
    }
}