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
        public static T? GetFirst<T>(
            this NeuNode node)
            where T : NeuNode
        {
            foreach (var child in node.Children)
            {
                if (child is T b)
                {
                    return b;
                }
            }

            return null;
        }
    }
}