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

    public partial class NeuTupleExprElementList : NeuNode
    {
        public NeuTupleExprElementList(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuTupleExprElement : NeuNode
    {
        public NeuTupleExprElement(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}