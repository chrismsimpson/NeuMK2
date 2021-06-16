//
//
//

using System;
using System.Collections.Generic;

using static System.Array;

using static Neu.NeuTokenizer;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuConditionElementList ParseConditionElementList(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var elements = parser.ParseConditionElements();

            ///

            return new NeuConditionElementList(
                children: elements,
                start: start,
                end: parser.Position());
        }

        public static IEnumerable<NeuConditionElement> ParseConditionElements(
            this NeuParser parser)
        {
            var elements = new List<NeuConditionElement>();

            ///

            while (!parser.IsEof())
            {
                if (parser.Tokenizer.PeekLeftBrace())
                {
                    break;
                }

                ///

                var conditionElement = parser.ParseConditionElement();

                if (conditionElement == null)
                {
                    break;
                }

                ///

                elements.Add(conditionElement);
            }

            ///

            return elements;
        }

        public static NeuConditionElement? ParseConditionElement(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var modifiers = parser.Tokenizer.TokenizeModifiers();

            ///

            var children = new List<Node>();

            ///

            while (!parser.IsEof())
            {
                if (parser.Tokenizer.PeekLeftBrace())
                {
                    return null; // Should this be break?
                }

                ///

                var token = parser.Tokenizer.Next();

                if (token == null)
                {
                    return null; // Likewise, should this be break?
                }

                ///

                if (token is NeuComment)
                {
                    continue;
                }

                ///

                var conditionExpr = parser.ParseConditionExpression(start, modifiers, token);

                children.Add(conditionExpr);

                ///

                if (parser.Tokenizer.PeekComma())
                {
                    var comma = parser.Tokenizer.TokenizeComma();

                    children.Add(comma);
                }

                ///

                break;
            }

            ///

            return new NeuConditionElement(
                children: children,
                start: start,
                end: parser.Position());
        }

        public static NeuExpression ParseConditionExpression(
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

            return parser.ParseConditionExpression(start, Empty<NeuToken>(), token);
        }

        public static NeuExpression ParseConditionExpression(
            this NeuParser parser, 
            SourceLocation start, 
            IEnumerable<NeuToken> modifiers,
            NeuToken token)
        {
            switch (token)
            {
                case NeuKeyword k when IsOptionalBindingKeyword(k):

                    return parser.ParseOptionalBindingCondition(start, token);

                ///

                case NeuKeyword k when k.KeywordType == NeuKeywordType.Case:

                    return parser.ParseMatchingPatternCondition(start, token);

                ///

                case NeuPunctuation p when p.PunctuationType == NeuPunctuationType.LeftParen:

                    return parser.ParseTupleExpr(start, token);

                ///

                case NeuKeyword k when IsBooleanLiteral(k):

                    return parser.ParseBooleanLiteralExpr(start, k);

                ///

                default:

                    throw new Exception();
            }
        }

        public static NeuOptionalBindingCondition ParseOptionalBindingCondition(
            this NeuParser parser,
            SourceLocation start,
            NeuToken token)
        {
            throw new Exception();
        }

        public static NeuMatchingPatternCondition ParseMatchingPatternCondition(
            this NeuParser parser,
            SourceLocation start,
            NeuToken token)
        {
            throw new Exception();
        }
    }
}