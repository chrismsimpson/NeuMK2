//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuTypeAnnotation : NeuNode
    {
        public NeuTypeAnnotation(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}