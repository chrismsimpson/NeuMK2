//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuDictionaryExpr : NeuExpression
    {
        public NeuDictionaryExpr(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuDictionaryElementList : NeuNode
    {
        public NeuDictionaryElementList(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuDictionaryElement : NeuNode
    {
        public NeuDictionaryElement(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}