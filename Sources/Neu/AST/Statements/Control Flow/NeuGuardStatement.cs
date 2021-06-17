//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuGuardStatement : NeuStatement
    {
        public NeuGuardStatement(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}