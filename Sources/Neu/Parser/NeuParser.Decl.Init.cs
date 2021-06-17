//
//
//

using System;
using System.Collections.Generic;

using static Neu.NeuTokenizer;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuInitDecl ParseInitDecl(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuToken token)
        {
            var children = new List<Node>();
            
            ///

            if (!IsInitKeyword(token))
            {
                throw new Exception();
            }

            children.Add(token);

            ///

            var paramClause = parser.ParseParameterClause();

            children.Add(paramClause);

            ///

            var codeBlock = parser.ParseCodeBlock();

            children.Add(codeBlock);

            ///

            return new NeuInitDecl(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}