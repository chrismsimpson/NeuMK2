//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuClosureExpr : NeuExpression
    {
        public NeuClosureExpr(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuClosureSignature : NeuNode
    {
        public NeuClosureSignature(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}