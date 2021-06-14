//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuEnumCaseElement : NeuNode
    {
        public NeuEnumCaseElement(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}