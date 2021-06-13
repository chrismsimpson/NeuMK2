//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuBreakStatement : NeuStatement
    {
        public NeuBreakStatement(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}