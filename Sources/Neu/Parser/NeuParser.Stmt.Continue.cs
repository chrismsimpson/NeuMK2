//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuContinueStatement ParseContinueStatement(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuToken token)
        {
            throw new Exception();
        }
    }
}