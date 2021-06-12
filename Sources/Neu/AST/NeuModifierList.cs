//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuModifierList : NeuNode
    {
        public NeuModifierList(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}