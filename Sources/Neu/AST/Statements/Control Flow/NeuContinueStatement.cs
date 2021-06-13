//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuContinueStatement : NeuStatement
    {
        public NeuContinueStatement(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}