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
        public static NeuExpression? ParseExpression(
            this NeuParser parser)
        {
            if (parser.IsEof())
            {
                return null;
            }

            ///

            var start = parser.Position();

            ///

            var token = parser.Tokenizer.Next();

            if (token == null)
            {
                return null;
            }

            ///

            return parser.ParseExpression(
                start: start,
                token: token);
        }

        public static NeuExpression ParseExpression(
            this NeuParser parser,
            SourceLocation start,
            NeuToken token)
        {
            return parser.ParseExpression(
                start: start,
                modifiers: Empty<NeuToken>(),
                token: token);
        }

        public static NeuExpression ParseExpression(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuToken token)
        {
            switch (token)
            {
                case NeuIdentifier identifier:

                    return parser.ParseExpression(start, modifiers, identifier);

                ///

                case NeuPunctuation punc:

                    return parser.ParseExpression(start, modifiers, punc);

                ///

                case NeuLiteral literal:

                    return parser.ParseExpression(start, modifiers, literal);

                ///

                case NeuOperator op:

                    return parser.ParseExpression(start, modifiers, op);

                ///
                
                default:

                    throw new Exception();
            }
        }

        public static NeuExpression ParseExpression(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuOperator op)
        {
            switch (op)
            {
                case NeuBinaryOperator binOp:

                    return parser.ParseBinaryOperatorExpr(start, modifiers, binOp);

                ///

                default:

                    throw new Exception();
            }
        }

        public static NeuExpression ParseExpression(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuPunctuation punc)
        {
            switch (punc.PunctuationType)
            {
                /// Binary Ops

                    /// Arith

                case NeuPunctuationType.Star:
                case NeuPunctuationType.Slash:
                case NeuPunctuationType.Plus:
                case NeuPunctuationType.Dash:

                    /// Comparison

                // case NeuPunctuationType.LessThan:
                // case NeuPunctuationType.GreaterThan:

                    return parser.ParseBinaryOperatorExpr(start, modifiers, punc);

                ///

                case NeuPunctuationType.Equal:

                    // TODO: wrap this inside another expr?

                    return parser.ParseAssignmentExpr(start, modifiers, punc);

                ///

                case NeuPunctuationType.LeftBrace when parser.Tokenizer.PeekClosure():

                    return parser.ParseClosureExpr(start, modifiers, punc);

                ///

                case NeuPunctuationType.LeftBrace when parser.Tokenizer.PeekDictionary():

                    return parser.ParseDictionaryExpr(start, modifiers, punc);

                ///

                default:

                    throw new Exception();
            }
        }

        public static NeuExpression ParseExpression(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuLiteral literal)
        {
            switch (literal)
            {
                case NeuFloatLiteral floatLiteral:

                    var floatLiteralExpr = parser.ParseNeuFloatLiteralExpr(start, modifiers, floatLiteral);

                    return parser.ParseExpression(start, floatLiteralExpr);

                ///

                case NeuIntegerLiteral integerLiteral:

                    var intLiteralExpr = parser.ParseNeuIntLiteralExpr(start, modifiers, integerLiteral);

                    return parser.ParseExpression(start, intLiteralExpr);

                ///

                default:

                    throw new Exception();
            }
        }

        public static NeuExpression ParseExpression(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuIdentifier identifier)
        {
            var idExpr = parser.ParseIdentifierExpr(identifier);

            ///

            return parser.ParseExpression(start, modifiers, idExpr);
        }

        ///

        public static NeuExpression ParseExpression(
            this NeuParser parser,
            SourceLocation start,
            NeuExpression expr)
        {
            return parser.ParseExpression(start, Empty<NeuToken>(), expr);
        }

        public static NeuExpression ParseExpression(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuExpression expr)
        {
            switch (parser.Tokenizer.Peek())
            {
                case NeuPunctuation p when p.PunctuationType == NeuPunctuationType.LeftBracket:

                    var subscriptExpr = parser.ParseSubscriptExpr(start, modifiers, expr);

                    return parser.ParseExpression(start, modifiers, subscriptExpr);

                ///

                case NeuPunctuation p when p.PunctuationType == NeuPunctuationType.LeftParen:

                    var funcCallExpr = parser.ParseFuncCallExpr(start, modifiers, expr);

                    return parser.ParseExpression(start, modifiers, funcCallExpr);

                ///

                case NeuPunctuation p when p.PunctuationType == NeuPunctuationType.Period:

                    var memberAccessExpr = parser.ParseMemberAccessExpr(start, modifiers, expr);

                    return parser.ParseExpression(start, modifiers, memberAccessExpr);

                ///

                case NeuKeyword k when k.KeywordType == NeuKeywordType.Else:

                    return expr;

                ///

                case NeuToken t when IsExprDelimiter(t):

                    return expr;

                ///

                case null:

                    return expr;

                ///

                default:

                    return parser.ParseExpressions(start, modifiers, expr);
            }
        }

        ///

        public static NeuExpression ParseExpressions(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuExpression expr)
        {
            var expressions = parser.ParseExpressions(start, modifiers, new NeuExpression[] { expr });

            ///

            switch (expressions.Count())
            {
                case 1:

                    return expressions.First();

                ///

                default:

                    return parser.ParseSequenceExpr(start, modifiers, expressions);
            }
        }

        public static IEnumerable<NeuExpression> ParseExpressions(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            IEnumerable<NeuExpression> expressions)
        {
            var e = new List<NeuExpression>();

            ///

            foreach (var expr in expressions)
            {
                e.Add(expr);
            }

            ///

            while (!parser.IsEof())
            {
                if (parser.Tokenizer.PeekExprListDelimiter())
                {
                    break;
                }

                var expr = parser.ParseExpression();

                if (expr == null)
                {
                    break;
                }

                e.Add(expr);
            }

            ///

            return e;
        }
    }
}