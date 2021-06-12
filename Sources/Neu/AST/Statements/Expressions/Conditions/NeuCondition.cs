//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuCondition : NeuExpression
    {
        public NeuCondition(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuOptionalBindingCondition : NeuCondition
    {
        public NeuOptionalBindingCondition(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuParseMatchingPatternCondition : NeuCondition
    {
        public NeuParseMatchingPatternCondition(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

}