//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuMemberAccessExpr : NeuExpression
    {
        public NeuMemberAccessExpr(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}