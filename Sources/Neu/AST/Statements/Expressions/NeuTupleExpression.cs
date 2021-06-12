//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuTupleExpression : NeuExpression
    {
        public NeuTupleExpression(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}