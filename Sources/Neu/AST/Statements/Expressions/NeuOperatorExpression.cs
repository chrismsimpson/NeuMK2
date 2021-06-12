//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NueOperatorExpr : NeuExpression
    {
        public NueOperatorExpr(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NueBinaryOperatorExpr : NueOperatorExpr
    {
        public NueBinaryOperatorExpr(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}