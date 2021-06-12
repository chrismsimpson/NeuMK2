//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuNode : Node
    {
        public NeuNode(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public static partial class NeuNodeHelpers
    {
        public static void Execute(
            this NeuNode node,
            NeuInterpreter interpreter)
        {

        }
    }
}