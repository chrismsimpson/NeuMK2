//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuLiteralExpr : NeuExpression
    {
        public NeuLiteralExpr(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuFloatLiteralExpr : NeuLiteralExpr
    {
        public NeuFloatLiteralExpr(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuIntLiteralExpr : NeuLiteralExpr
    {
        public NeuIntLiteralExpr(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuStringLiteralExpr : NeuLiteralExpr
    {
        public NeuStringLiteralExpr(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuBooleanLiteralExpr : NeuLiteralExpr
    {
        public NeuBooleanLiteralExpr(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

}