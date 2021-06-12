//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuIfStatement : NeuStatement
    {
        public NeuIfStatement(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}