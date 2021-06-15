//
//
//

using System;

using static System.DateTimeOffset;

namespace Neu
{
    public class TestRun
    {
        public String Filename { get; init; }

        public long Start { get; init; }

        public long End { get; init; }

        public TestResult Result { get; init; }

        ///

        public TestRun(
            String filename,
            long start,
            long end,
            TestResult result)
        {
            this.Filename = filename;
            this.Start = start;
            this.End = end;
            this.Result = result;
        }

        public TestRun(
            String filename,
            TestResult result)
        {
            this.Filename = filename;
            this.Start = UtcNow.UtcTicks;
            this.End = this.Start;
            this.Result = result;
        }
    }
}