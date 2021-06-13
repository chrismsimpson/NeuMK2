//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuTupleType ParseTupleType(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var children = new List<Node>();

            ///

            var leftParen = parser.Tokenizer.TokenizeLeftParen();

            children.Add(leftParen);

            ///

            var elementList = parser.ParseTupleTypeElementList();

            children.Add(elementList);

            ///

            var rightParen = parser.Tokenizer.TokenizeRightParen();

            children.Add(rightParen);

            ///

            return new NeuTupleType(
                children: children,
                start: start,
                end: parser.Position());
        }

        public static NeuTupleTypeElementList ParseTupleTypeElementList(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var elements = parser.ParseTupleTypeElements();

            ///

            return new NeuTupleTypeElementList(
                children: elements,
                start: start,
                end: parser.Position());
        }

        public static IEnumerable<NeuTupleTypeElement> ParseTupleTypeElements(
            this NeuParser parser)
        {
            var elements = new List<NeuTupleTypeElement>();

            ///

            while (!parser.IsEof())
            {   
                if (parser.Tokenizer.PeekRightParen())
                {
                    break;
                }

                ///

                var element = parser.ParseTupleTypeElement();

                if (element == null)
                {
                    throw new Exception();
                }

                ///

                elements.Add(element);
            }

            ///

            return elements;
        }

        public static NeuTupleTypeElement? ParseTupleTypeElement(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            if (parser.Tokenizer.PeekRightParen())
            {
                return null;
            }

            ///

            var children = new List<Node>();

            ///
             
            var identifier = parser.Tokenizer.TokenizeIdentifier();

            ///

            var peek = parser.Tokenizer.Peek();

            if (peek is NeuPunctuation p && (p.PunctuationType == NeuPunctuationType.Comma || p.PunctuationType == NeuPunctuationType.RightParen))
            {
                var simpleTypeId = parser.ParseSimpleTypeIdentifier(
                    start: start,
                    identifier: identifier);

                children.Add(simpleTypeId);
            
                ///

                if (p.PunctuationType == NeuPunctuationType.Comma)
                {
                    var comma = parser.Tokenizer.TokenizeComma();

                    children.Add(comma);
                }

                ///

                return new NeuTupleTypeElement(
                    children: children,
                    start: start,
                    end: parser.Position());
            }

            ///

            var colon = parser.Tokenizer.TokenizeColon();

            children.Add(colon);

            ///

            var typeId = parser.ParseSimpleTypeIdentifier();

            children.Add(typeId);

            ///

            return new NeuTupleTypeElement(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}