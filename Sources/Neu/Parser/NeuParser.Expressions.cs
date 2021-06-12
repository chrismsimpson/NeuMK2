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

                default:

                    throw new Exception();
            }
        }

        ///

        public static NeuExprList ParseExprList(
            this NeuParser parser,
            SourceLocation start,
            NeuToken token,
            IEnumerable<NeuToken> modifiers)
        {
            var children = new List<Node>();

            ///

            var escapes = new []
            {
                NeuPunctuationType.Comma, 
                NeuPunctuationType.Colon, 
                NeuPunctuationType.RightParen,
                NeuPunctuationType.LeftBrace
            };

            var tokens = parser.Tokenizer.Tokenize(token, modifiers, escapes);
            
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

        ///

        public static NeuSequenceExpr ParseSequenceExpr(
            this NeuParser parser,
            SourceLocation start,
            NeuToken token,
            IEnumerable<NeuToken> modifiers)
        {
            var children = new List<Node>();

            ///

            var exprList = parser.ParseExprList(start, token, modifiers);

            ///

            children.Add(exprList);

            ///

            return new NeuSequenceExpr(
                children: children,
                start: start,
                end: parser.Position());
        }

        ///
        
        public static NeuTupleExpr ParseTupleExpr(
            this NeuParser parser, 
            SourceLocation start, 
            NeuToken token)
        {
            throw new Exception();
        }
    }
}