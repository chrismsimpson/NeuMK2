//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuExpression : NeuStatement
    {
        public NeuExpression(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuExprList : NeuNode
    {
        public NeuExprList(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

}