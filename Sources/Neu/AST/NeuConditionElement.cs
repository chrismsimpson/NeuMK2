//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuConditionElement : NeuStatement
    {
        public NeuConditionElement(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuConditionElementList : NeuNode
    {
        public NeuConditionElementList(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }    
}