//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuTupleExpr : NeuExpression
    {
        public NeuTupleExpr(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}