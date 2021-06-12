//
//
//

using System;

namespace Neu
{
    public class NeuToken : Token
    {
        public NeuToken(
            String source,
            SourceLocation start,
            SourceLocation end)
            : base(source, start, end) { }
    }
}