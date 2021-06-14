//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuMemberDeclList : NeuNode
    {
        public NeuMemberDeclList(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}