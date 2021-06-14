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
        public static NeuExpression ParseExpression(
            this NeuParser parser,
            NeuToken token)
        {
            switch (token)
            {
                case NeuLiteral literal:

                    return parser.ParseLiteralExpr(literal);

                ///

                case NeuOperator op:

                    return parser.ParseOperatorExpr(op);

                ///

                case NeuPunctuation punc when IsBinaryOperator(punc):

                    return parser.ParseBinaryOperator(punc);

                ///

                case NeuIdentifier identifier:

                    return parser.ParseIdentifier(identifier);
                    
                ///

                default:

                    throw new Exception();
            }
        }

        ///

        public static NeuExprList ParseExprList(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuToken token,
            bool escapeOnNewline,
            params NeuPunctuationType[] delimiters)
        {
            var children = new List<Node>();

            ///

            var tokens = parser.Tokenizer.Tokenize(token, modifiers, escapeOnNewline, delimiters);
            
            ///

            foreach (var t in tokens)
            {
                var expr = parser.ParseExpression(t);

                children.Add(expr);
            }

            ///

            return new NeuExprList(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}