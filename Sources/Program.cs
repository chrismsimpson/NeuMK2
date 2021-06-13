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
    public class TestRun
    {
        public String Filename { get; init; }

        public long Start { get; init; }

        public long End { get; init; }

        ///

        public TestRun(
            String filename,
            long start,
            long end)
        {
            this.Filename = filename;
            this.Start = start;
            this.End = end;
        }

        public TestRun(
            String filename)
        {
            this.Filename = filename;
            this.Start = UtcNow.UtcTicks;
            this.End = this.Start;
        }
    }

    public static partial class TestRunHelpers
    {
        public static long TimeElapsed(
            this TestRun testRun)
        {
            var ticks = testRun.End - testRun.Start;

            return ticks / TicksPerMillisecond;
        }
    }

    public enum TestSuite
    {
        All,
        Granular
    }

    public static partial class Program
    {
        public static void Main(String[] args)
        {
            // IRTests(TestSuite.Granular);
            RunNeuTests(TestSuite.Granular, dumpAST: true);
        }

        public static void Interpret()
        {

        }

        ///

        public static IEnumerable<String> GetIRTestFiles(
            TestSuite suite)
        {
            throw new Exception();
        }

        public static void RunIRTests(
            TestSuite suite,
            bool dumpIR)
        {
            throw new Exception();
        }

        ///

        public static IEnumerable<String> GetNeuTestFiles(
            TestSuite suite)
        {
            var neuTestsDir = GetNeuTestsDirectory();

            ///

            switch (suite)
            {
                case TestSuite.All:

                    return GetFiles(neuTestsDir);

                ///

                case TestSuite.Granular:

                    var files = new []
                    {
                        $"{neuTestsDir}/0000-Arithmetic.neu",
                        $"{neuTestsDir}/0000-Empty.neu",
                        $"{neuTestsDir}/0001-EmptyFunction.neu",
                    };

                    return files;

                ///

                default:

                    throw new Exception();
            }
        }

        public static void RunNeuTests(
            TestSuite suite,
            bool dumpAST)
        {
            var files = GetNeuTestFiles(suite);

            ///

            var successful = new List<TestRun>();
            var failed = new List<TestRun>();
            var unsupported = new List<TestRun>();

            ///

            foreach (var file in files.OrderBy(x => x))
            {
                var extension = GetExtension(file);

                switch (extension)
                {
                    case ".neu":

                        var parser = NeuParser.FromFile(file);

                        ///

                        var start = UtcNow.UtcTicks;

                        try
                        {
                            var sourceFile = parser.ParseSourceFile();

                            if (dumpAST)
                            {
                                Write($"\n//\n// Filename: {file}\n//\n\n{sourceFile.ToString()}\n");
                            }

                            successful.Add(
                                new TestRun(
                                    filename: file,
                                    start: start,
                                    end: UtcNow.UtcTicks));
                        }
                        catch
                        {
                            failed.Add(
                                new TestRun(
                                    filename: file,
                                    start: start,
                                    end: UtcNow.UtcTicks));
                        }

                        break;

                    ///

                    default:

                        unsupported.Add(
                            new TestRun(
                                filename: file));

                        break;
                }
            }

            ///

            WriteLine($"\n//");
            WriteLine($"// Neu stats:");
            WriteLine($"//\n");

            ///

            PrintStats(successful, failed, unsupported);
        }

        ///

        public static void PrintStats(
            IEnumerable<TestRun> successful,
            IEnumerable<TestRun> failed,
            IEnumerable<TestRun> unsupported)
        {
            if (successful.Count() > 0)
            {
                WriteGreenLine(2, $"Successful: {successful.Count()} ({successful.Sum(x => x.TimeElapsed())} ms)");

                foreach (var s in successful)
                {
                    WriteGreenLine(4, $"{s.Filename} ({s.TimeElapsed()} ms)");
                }
            }

            ///

            if (failed.Count() > 0)
            {
                WriteRedLine(2, $"Failed: {failed.Count()}");

                foreach (var f in failed)
                {
                    WriteRedLine(4, $"{f.Filename} ({f.TimeElapsed()} ms)");
                }
            }

            ///

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