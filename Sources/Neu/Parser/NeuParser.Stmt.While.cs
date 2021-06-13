//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuWhileStatement ParseWhileStatement(
            this NeuParser parser,
            SourceLocation start,
            NeuToken token,
            IEnumerable<NeuToken> modifiers)
        {
            var children = new List<Node>();

            ///

            throw new Exception();
        }
    }
}