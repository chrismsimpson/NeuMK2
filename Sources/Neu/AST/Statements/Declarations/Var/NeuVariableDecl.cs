//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuVariableDecl : NeuDeclaration
    {
        public NeuVariableDecl(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}