//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuAccessPath : NeuNode
    {
        public NeuAccessPath(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuAccessPathComponent : NeuNode
    {
        public NeuAccessPathComponent(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}