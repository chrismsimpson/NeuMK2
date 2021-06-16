//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuMemberTypeIdentifier : NeuNode
    {
        public NeuMemberTypeIdentifier(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}