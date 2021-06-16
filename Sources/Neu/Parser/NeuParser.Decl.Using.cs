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
        public static NeuUsingDecl ParseUsingDecl(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuToken token)
        {
            var children = new List<Node>();

            ///

            children.Add(token);

            ///

            if (parser.Tokenizer.PeekUsingTypeKeyword())
            {
                var usingTypeKeyword = parser.Tokenizer.TokenizeUsingTypeKeyword();

                children.Add(usingTypeKeyword);
            }

            ///
            
            var accessPath = parser.ParseAccessPath();

            children.Add(accessPath);

            ///

            return new NeuUsingDecl(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}
