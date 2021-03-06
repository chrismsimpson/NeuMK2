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
            return new NeuContinueStatement(
                children: new Node[] { token },
                start: start,
                end: parser.Position());
        }
    }
}