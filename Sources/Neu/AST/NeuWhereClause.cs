//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuWhereClause : NeuNode
    {
        public NeuWhereClause(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}