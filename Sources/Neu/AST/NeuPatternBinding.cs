//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuPatternBinding : NeuNode
    {
        public NeuPatternBinding(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
        
    public partial class NeuPatternBindingList : NeuNode
    {
        public NeuPatternBindingList(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}