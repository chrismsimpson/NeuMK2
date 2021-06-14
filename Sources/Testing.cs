//
//
//

using System;

using static System.TimeSpan;
using static System.DateTimeOffset;

namespace Neu
{
    public enum TestSuite
    {
        All,
        Granular
    }

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
}