//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuForInStatement : NeuStatement
    {
        public NeuForInStatement(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}