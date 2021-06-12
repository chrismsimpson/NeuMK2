//
//
//

using System;

using static System.IO.Directory;
using static System.IO.Path;
using static System.String;

namespace Neu
{
    public static partial class PathHelpers
    {
        public static String GetTestsDirectory()
        {
            var current = GetCurrentDirectory();

            ///

            var root = GetParent(current);

            if (root == null)
            {
                throw new Exception();
            }

            ///

            return Combine(root.FullName, "Tests");
        }

        public static String GetIRTestsDirectory()
        {
            var tests = GetTestsDirectory();

            ///

            var ir = Combine(tests, "IR");

            if (IsNullOrWhiteSpace(ir))
            {
                throw new Exception();
            }

            ///

            return ir;
        }

        public static String GetNeuTestsDirectory()
        {
            var tests = GetTestsDirectory();

            ///

            var neu = Combine(tests, "Neu");

            if (IsNullOrWhiteSpace(neu))
            {
                throw new Exception();
            }

            ///

            return neu;
        }
    }
}