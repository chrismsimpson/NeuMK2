//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuExtendDecl : NeuDeclaration
    {
        public NeuExtendDecl(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}