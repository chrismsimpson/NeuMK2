//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static System.Array;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuStatement ParseStatement(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var token = parser.Tokenizer.Next();

            if (token == null)
            {
                throw new Exception();
            }

            ///

            return parser.ParseStatement(start, token);
        }

        public static NeuStatement ParseStatement(
            this NeuParser parser,
            SourceLocation start,
            NeuToken token)
        {
            return parser.ParseStatement(start, token, Empty<NeuToken>());
        }

        public static NeuStatement ParseStatement(
            this NeuParser parser,
            SourceLocation start,
            NeuToken token,
            IEnumerable<NeuToken> modifiers)
        {
            switch (token)
            {
                /// Declarations

                case NeuKeyword keyword when keyword.KeywordType == NeuKeywordType.Func:

                    return parser.ParseFunctionDeclaration(start, token, modifiers);

                ///

                default:

                    return parser.ParseSequenceExpr(start, token, modifiers);
            }
        }
    }
}