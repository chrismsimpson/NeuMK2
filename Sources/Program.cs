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

using static Neu.TestRunner;

namespace Neu
{
    public static partial class Program
    {
        public static void Main(
            String[] args)
        {
            // RunTests();
            Interpret();
        }

        public static void RunTests()
        {
            var runners = new TestRunner[]
            {
                new NeuTestRunner(
                    dumpAST: true,
                    NeuTestSuite.Parsing, 
                    NeuTestSuite.Interpreting)
            };

            ///

            var tests = new List<TestRun>();

            foreach (var runner in runners)
            {
                foreach (var testRun in runner.Run())
                {
                    tests.Add(testRun);
                }
            }

            PrintTestStatistics(tests);
        }

        public static void Interpret()
        {
            var file = "../Tests/Neu/Interpreting/0000-Scratchpad.neu";

            var parser = NeuParser.FromFile(file);

            var sourceFile = parser.ParseSourceFile();

            Write($"\n//\n// Filename: {file}\n//\n\n{sourceFile.Dump()}\n");

            var interpreter = new NeuInterpreter();

            interpreter.Execute(sourceFile);

            // Write(sourceFile.Dump());
        }

        // public static void Main(String[] args)
        // {
        //     // IRTests(TestSuite.Granular);
        //     // RunNeuTests(TestSuite.Granular, dumpAST: true);

        //     ///

        //     var neuTestsDir = GetNeuTestsDirectory();

        //     // var neuFile = $"{neuTestsDir}/0000-Arithmetic.neu";
        //     var neuFile = $"{neuTestsDir}/0002-FuncCallExpr.neu";

        //     InterpretNeuFile(file: neuFile);
        // }

        // public static void InterpretNeuFile(
        //     String file)
        // {
        //     var parser = NeuParser.FromFile(file);

        //     ///

        //     var sourceFile = parser.ParseSourceFile();

        //     ///

        //     Write($"\n//\n// Filename: {file}\n//\n\n{sourceFile.ToString()}\n");

        //     // var interpreter = new NeuInterpreter();

        //     // var result = interpreter.Run(sourceFile);

        //     // WriteLine(2, $"{result}");
        // }

        // ///

        // public static IEnumerable<String> GetIRTestFiles(
        //     TestSuite suite)
        // {
        //     throw new Exception();
        // }

        // public static void RunIRTests(
        //     TestSuite suite,
        //     bool dumpIR)
        // {
        //     throw new Exception();
        // }

        // ///

        // public static IEnumerable<String> GetNeuTestFiles(
        //     TestSuite suite)
        // {
        //     var neuTestsDir = GetNeuTestsDirectory();

        //     ///

        //     switch (suite)
        //     {
        //         case TestSuite.All:

        //             return GetFiles(neuTestsDir);

        //         ///

        //         case TestSuite.Granular:

        //             var files = new []
        //             {
        //                 $"{neuTestsDir}/0000-Arithmetic.neu",
        //                 $"{neuTestsDir}/0000-Empty.neu",
        //                 $"{neuTestsDir}/0001-EmptyFunction.neu",
        //             };

        //             return files;

        //         ///

        //         default:

        //             throw new Exception();
        //     }
        // }

        // public static void RunNeuTests(
        //     TestSuite suite,
        //     bool dumpAST)
        // {
        //     var files = GetNeuTestFiles(suite);

        //     ///

        //     var successful = new List<TestRun>();
        //     var failed = new List<TestRun>();
        //     var unsupported = new List<TestRun>();

        //     ///

        //     foreach (var file in files.OrderBy(x => x))
        //     {
        //         var extension = GetExtension(file);

        //         switch (extension)
        //         {
        //             case ".neu":

        //                 var parser = NeuParser.FromFile(file);

        //                 ///

        //                 var start = UtcNow.UtcTicks;

        //                 try
        //                 {
        //                     var sourceFile = parser.ParseSourceFile();

        //                     if (dumpAST)
        //                     {
        //                         Write($"\n//\n// Filename: {file}\n//\n\n{sourceFile.ToString()}\n");
        //                     }

        //                     successful.Add(
        //                         new TestRun(
        //                             filename: file,
        //                             start: start,
        //                             end: UtcNow.UtcTicks));
        //                 }
        //                 catch
        //                 {
        //                     failed.Add(
        //                         new TestRun(
        //                             filename: file,
        //                             start: start,
        //                             end: UtcNow.UtcTicks));
        //                 }

        //                 break;

        //             ///

        //             default:

        //                 unsupported.Add(
        //                     new TestRun(
        //                         filename: file));

        //                 break;
        //         }
        //     }

        //     ///

        //     WriteLine($"\n//");
        //     WriteLine($"// Neu stats:");
        //     WriteLine($"//\n");

        //     ///

        //     PrintStats(successful, failed, unsupported);
        // }

        // ///

        // public static void PrintStats(
        //     IEnumerable<TestRun> successful,
        //     IEnumerable<TestRun> failed,
        //     IEnumerable<TestRun> unsupported)
        // {
        //     if (successful.Count() > 0)
        //     {
        //         WriteGreenLine(2, $"Successful: {successful.Count()} ({successful.Sum(x => x.TimeElapsed())} ms)");

        //         foreach (var s in successful)
        //         {
        //             WriteGreenLine(4, $"{s.Filename} ({s.TimeElapsed()} ms)");
        //         }
        //     }

        //     ///

        //     if (failed.Count() > 0)
        //     {
        //         WriteRedLine(2, $"Failed: {failed.Count()}");

        //         foreach (var f in failed)
        //         {
        //             WriteRedLine(4, $"{f.Filename} ({f.TimeElapsed()} ms)");
        //         }
        //     }

        //     ///

        //     if (unsupported.Count() > 0)
        //     {
        //         WriteYellowLine(2, $"Unsupported: {unsupported.Count()}");

        //         foreach (var u in unsupported)
        //         {
        //             WriteYellowLine(4, $"{u}");
        //         }
        //     }
        // }
    }
}