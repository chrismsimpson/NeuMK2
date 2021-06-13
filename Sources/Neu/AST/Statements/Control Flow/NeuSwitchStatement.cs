//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuSwitchStatement : NeuStatement
    {
        public NeuSwitchStatement(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}