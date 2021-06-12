//
//
//

using System;

namespace Neu
{
    public class NeuLiteral : NeuToken
    {
        public NeuLiteral(
            String source,
            SourceLocation start,
            SourceLocation end)
            : base(source, start, end) { }
    }

    
}