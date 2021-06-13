//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuStructDecl : NeuDeclaration
    {
        public NeuStructDecl(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}