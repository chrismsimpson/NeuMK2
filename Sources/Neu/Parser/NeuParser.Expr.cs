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
                modifiers: Empty<NeuToken>(),
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
                case NeuPunctuationType.Equal:

                    return parser.ParseAssignmentExpr(start, modifiers, punc);

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

                    return parser.ParseNeuFloatLiteralExpr(start, modifiers, floatLiteral);

                ///

                case NeuIntegerLiteral integerLiteral:

                    return parser.ParseNeuIntLiteralExpr(start, modifiers, integerLiteral);

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

                case NeuToken t when IsExprDelimiter(t):

                    return expr;

                ///

                default:

                    return parser.ParseSequenceExpr(start, modifiers, new NeuExpression[] { expr });
            }
        }

        ///

        public static NeuExprList ParseExprList(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            IEnumerable<NeuExpression> expressions)
        {
            var children = new List<Node>();

            ///

            foreach (var expr in expressions)
            {
                children.Add(expr);
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