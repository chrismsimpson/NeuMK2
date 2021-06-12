//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuParameterClause : Node
    {
        public NeuParameterClause(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}