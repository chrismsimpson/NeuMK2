//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static System.String;

namespace Neu
{
    public static partial class NeuInterpreterHelpers
    {
        public static String? GetScopeName(
            this Interpreter<NeuFrame, NeuVTableEntry> interpreter)
        {
            var segments = new List<String>();

            ///

            foreach (var frame in interpreter.Stack)
            {
                switch (frame.Node)
                {
                    case NeuDeclaration decl:

                        segments.Add(decl.GetDeclName());

                        break;

                    ///

                    default:

                        continue;
                }
            }

            ///

            switch (segments.Count)
            {
                case 0:
                    return null;

                ///

                case 1:
                    return segments.First();

                ///

                default:
                    return Join('.', segments);
            }
        }
    }
}