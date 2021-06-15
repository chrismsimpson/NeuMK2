//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuAliasDecl : NeuDeclaration
    {
        public NeuAliasDecl(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}