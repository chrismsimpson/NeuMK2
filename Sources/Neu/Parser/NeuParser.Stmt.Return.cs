//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuReturnStatement ParseReturnStatement(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuToken token)
        {
            var children = new List<Node>();

            ///

            children.Add(token);

            ///

            if (!parser.Tokenizer.PeekSemicolonOrRightBrace())
            {
                var expr = parser.ParseExpression();

                if (expr == null)
                {
                    throw new Exception();
                }

                children.Add(expr);
            }

            ///

            return new NeuReturnStatement(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}