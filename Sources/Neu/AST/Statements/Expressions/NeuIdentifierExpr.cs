//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuIdentifierExpr : NeuExpression
    {
        public NeuIdentifierExpr(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}