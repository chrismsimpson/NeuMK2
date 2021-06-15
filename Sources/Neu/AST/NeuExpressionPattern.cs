//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuExprPattern : Node
    {
        public NeuExprPattern(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}