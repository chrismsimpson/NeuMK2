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

    ///

    public partial class NeuNumberLiteralExpr : NeuLiteralExpr
    {
        public NeuNumberLiteralExpr(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    ///

    public partial class NeuBooleanLiteralExpr : NeuNumberLiteralExpr
    {
        public NeuBooleanLiteralExpr(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    ///

    public partial class NeuFloatLiteralExpr : NeuNumberLiteralExpr
    {
        public NeuFloatLiteralExpr(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuIntLiteralExpr : NeuNumberLiteralExpr
    {
        public NeuIntLiteralExpr(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    ///

    public partial class NeuStringLiteralExpr : NeuLiteralExpr
    {
        public NeuStringLiteralExpr(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuStringLiteralSegments : NeuNode
    {
        public NeuStringLiteralSegments(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuStringSegment : NeuNode
    {
        public NeuStringSegment(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}