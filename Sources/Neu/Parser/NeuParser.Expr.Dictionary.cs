//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuDictionaryExpr ParseDictionaryExpr(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuPunctuation punc)
        {
            var children = new List<Node>();

            ///

            if (punc.PunctuationType != NeuPunctuationType.LeftBrace)
            {
                throw new Exception();
            }

            children.Add(punc);

            ///

            var dictElementList = parser.ParseDictionaryElementList();

            children.Add(dictElementList);

            ///

            var rightBrace = parser.Tokenizer.TokenizeRightBrace();

            children.Add(rightBrace);

            ///

            return new NeuDictionaryExpr(
                children: children,
                start: start,
                end: parser.Position());
        }

        public static NeuDictionaryElementList ParseDictionaryElementList(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var elements = parser.ParseDictionaryElements();
            
            ///

            return new NeuDictionaryElementList(
                children: elements,
                start: start,
                end: parser.Position());
        }

        public static IEnumerable<NeuDictionaryElement> ParseDictionaryElements(
            this NeuParser parser)
        {
            var elements = new List<NeuDictionaryElement>();

            ///

            while (!parser.IsEof())
            {
                if (parser.Tokenizer.PeekRightBrace())
                {
                    break;
                }

                ///

                var element = parser.ParseDictionaryElement();

                elements.Add(element);
            }
            
            ///

            return elements;
        }

        public static NeuDictionaryElement ParseDictionaryElement(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var children = new List<Node>();

            ///

            var keyExpr = parser.ParseExpression();

            if (keyExpr == null)
            {
                throw new Exception();
            }

            children.Add(keyExpr);

            ///

            var colon = parser.Tokenizer.TokenizeColon();

            children.Add(colon);

            ///

            var valueExpr = parser.ParseExpression();

            if (valueExpr == null)
            {
                throw new Exception();
            }

            children.Add(valueExpr);

            ///

            if (parser.Tokenizer.PeekComma())
            {
                var comma = parser.Tokenizer.TokenizeComma();

                children.Add(comma);
            }

            ///

            return new NeuDictionaryElement(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}