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
    public partial class NeuTestRunner : TestRunner
    {
        public bool DumpAST { get; init; }

        public IEnumerable<NeuTestSuite> Suites { get; init; }

        ///

        public NeuTestRunner(
            bool dumpAST,
            params NeuTestSuite[] suites)
            : base()
        {
            this.DumpAST = dumpAST;
            this.Suites = suites;
        }

        public NeuTestRunner(
            bool dumpAST,
            IEnumerable<NeuTestSuite> suites)
            : base()
        {
            this.DumpAST = dumpAST;
            this.Suites = suites;
        }

        ///

        public override IEnumerable<TestRun> Run()
        {
            foreach (var suite in this.Suites)
            {
                foreach (var testRun in this.Run(suite))
                {
                    yield return testRun;
                }
            }
        }
    }

    public static partial class NeuTestRunnerHelpers
    {
        public static IEnumerable<NeuTestRun> Run(
            this NeuTestRunner runner,
            NeuTestSuite suite)
        {
            var neuTestsDir = GetNeuTestsDirectory();

            ///

            switch (suite)
            {
                case NeuTestSuite.Parsing:

                    foreach (var parsingTest in runner.RunParsingSuite(neuTestsDir))
                    {
                        yield return parsingTest;
                    }

                    break;

                ///

                case NeuTestSuite.Interpreting:

                    break;

                ///

                default:

                    throw new Exception();
            }
        }
    }
}