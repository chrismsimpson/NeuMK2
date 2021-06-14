//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{    
    public partial class NeuExpressionSegment : NeuNode
    {
        public NeuExpressionSegment(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}