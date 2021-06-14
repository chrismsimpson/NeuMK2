//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuFuncCallExpr : NeuExpression
    {
        public NeuFuncCallExpr(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}