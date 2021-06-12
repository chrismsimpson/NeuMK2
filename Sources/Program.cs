//
//
//

using System;

using static System.Console;
using static System.IO.File;

using static Neu.PathHelpers;

namespace Neu
{
    public static partial class Program
    {
        public static void Main(String[] args)
        {
            IRTests();
            NeuTests();
        }

        public static void IRTests()
        {

        }

        public static void NeuTests()
        {
            var testsDir = GetNeuTestsDirectory();

            var files = GetFiles(testsDir);





        }

    }
}