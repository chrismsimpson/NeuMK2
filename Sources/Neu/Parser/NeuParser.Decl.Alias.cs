//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuAliasDecl ParseAliasDecl(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuToken token)
        {
            throw new Exception();
        }
    }
}