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

    public partial class NeuMatchingPatternCondition : NeuCondition
    {
        public NeuMatchingPatternCondition(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

}