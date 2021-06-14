//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuIdentifierPattern : NeuNode
    {
        public NeuIdentifierPattern(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}