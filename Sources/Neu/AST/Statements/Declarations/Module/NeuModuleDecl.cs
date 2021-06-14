//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuModuleDecl : NeuDeclaration
    {
        public NeuModuleDecl(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}