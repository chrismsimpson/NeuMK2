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
        private static IEnumerable<NeuTestRun> RunControlFlowParsingSuite(
            this NeuTestRunner runner,
            String parsingDir)
        {
            var controlFlowDir = Combine(parsingDir, "Control Flow");

            ///

            return runner.RunParseTests(ControlFlowParsingTests(controlFlowDir));
        }

        private static IEnumerable<String> ControlFlowParsingTests(
            String dir)
        {
            return new []
            {
                $"{dir}/0000-Scratchpad.neu",
                // $"{dir}/0000-IfBooleanLiteral.neu",
                // $"{dir}/0000-IfIdentifierLiteral.neu",
                // $"{dir}/0000-IfIdentifierLiteralThenBooleanLiteral.neu",
                // $"{dir}/0000-IfMatchingPattern.neu",
            };
        }
    }
}