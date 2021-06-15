//
//
//

using System;

namespace Neu
{
    public class NeuTestRun : TestRun
    {
        public NeuTestRun(
            String filename,
            TestResult result)
            : base(filename, result) { }

        public NeuTestRun(
            String filename,
            long start,
            long end,
            TestResult result)
            : base(filename, start, end, result) { }
    }
}