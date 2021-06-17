//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuInitDecl : NeuDeclaration
    {
        public NeuInitDecl(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}