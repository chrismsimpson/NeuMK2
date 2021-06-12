//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuSimpleTypeIdentifier : NeuNode
    {
        public NeuSimpleTypeIdentifier(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}