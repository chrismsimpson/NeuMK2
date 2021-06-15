//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuSubscriptExpr : NeuExpression
    {
        public NeuSubscriptExpr(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}