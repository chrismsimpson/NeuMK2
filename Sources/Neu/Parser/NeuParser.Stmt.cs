//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static System.Array;

using static Neu.NeuTokenizer;

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
            return parser.ParseStatement(start, Empty<NeuToken>(), token);
        }

        public static NeuStatement ParseStatement(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuToken token)
        {
            switch (token)
            {
                /// Modifiers

                case NeuKeyword keyword when IsStatementModifier(keyword):

                    var next = parser.Tokenizer.Next();

                    if (next == null)
                    {
                        throw new Exception();
                    }

                    return parser.ParseStatement(start, modifiers.Append(keyword), next);


                /// Declarations

                case NeuKeyword keyword when keyword.KeywordType == NeuKeywordType.Func:

                    return parser.ParseFunctionDeclaration(start, modifiers, token);

                case NeuKeyword keyword when keyword.KeywordType == NeuKeywordType.Interface:

                    return parser.ParseInterfaceDecl(start, modifiers, token);
;
                case NeuKeyword keyword when keyword.KeywordType == NeuKeywordType.Struct:

                    throw new Exception();

                case NeuKeyword keyword when keyword.KeywordType == NeuKeywordType.Enum:

                    throw new Exception();

                case NeuKeyword keyword when keyword.KeywordType == NeuKeywordType.Case:

                    throw new Exception();

                case NeuKeyword keyword when keyword.KeywordType == NeuKeywordType.Using:

                    throw new Exception();


                /// Control Flow

                case NeuKeyword keyword when keyword.KeywordType == NeuKeywordType.If:

                    return parser.ParseIfStatement(start, modifiers, token);

                case NeuKeyword keyword when keyword.KeywordType == NeuKeywordType.While:

                    return parser.ParseWhileStatement(start, modifiers, token);

                case NeuKeyword keyword when keyword.KeywordType == NeuKeywordType.For:

                    throw new Exception();

                case NeuKeyword keyword when keyword.KeywordType == NeuKeywordType.Switch:
                    
                    throw new Exception();

                case NeuKeyword keyword when keyword.KeywordType == NeuKeywordType.Break:

                    throw new Exception();

                case NeuKeyword keyword when keyword.KeywordType == NeuKeywordType.Continue:

                    throw new Exception();

                case NeuKeyword keyword when keyword.KeywordType == NeuKeywordType.Return:

                    throw new Exception();

                

                ///



                ///

                default:

                    return parser.ParseSequenceExpr(start, modifiers, token);
            }
        }
    }
}