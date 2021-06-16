//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuTypeAlignClause : NeuNode
    {
        public NeuTypeAlignClause(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuAlignedTypeList : NeuNode
    {
        public NeuAlignedTypeList(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuAlignedType : NeuNode
    {
        public NeuAlignedType(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}