//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuMemberDeclBlock : NeuNode
    {
        public NeuMemberDeclBlock(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuMemberDeclList : NeuNode
    {
        public NeuMemberDeclList(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuMemberDeclListItem : NeuNode
    {
        public NeuMemberDeclListItem(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}