//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuSourceFile : NeuNode
    {
        public NeuSourceFile(
            IEnumerable<NeuNode> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}