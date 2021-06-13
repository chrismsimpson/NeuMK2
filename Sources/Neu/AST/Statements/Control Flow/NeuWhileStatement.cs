//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuWhileStatement : NeuStatement
    {
        public NeuWhileStatement(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}