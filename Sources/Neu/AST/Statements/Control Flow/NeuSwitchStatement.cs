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

    public partial class NeuSwitchCaseList : NeuNode
    {
        public NeuSwitchCaseList(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuSwitchCase : NeuNode
    {
        public NeuSwitchCase(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuSwitchCaseLabel : Node
    {
        public NeuSwitchCaseLabel(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuCaseItemList : Node
    {
        public NeuCaseItemList(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuCaseItem : Node
    {
        public NeuCaseItem(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}