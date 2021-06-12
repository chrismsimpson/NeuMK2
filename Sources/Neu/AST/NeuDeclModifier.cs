//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuDeclModifier : NeuNode
    {
        public NeuDeclModifier(
            NeuKeyword keyword)
            : base(new Node[] { keyword }, keyword.Start, keyword.End) { }

        /// 

        public NeuDeclModifier(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}