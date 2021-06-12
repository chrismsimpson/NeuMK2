//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuFunctionDeclaration : NeuDeclaration
    {
        public NeuFunctionDeclaration(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}