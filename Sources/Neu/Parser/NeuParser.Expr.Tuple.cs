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
        public static NeuTupleExpr ParseTupleExpr(
            this NeuParser parser, 
            SourceLocation start, 
            NeuToken token)
        {
            throw new Exception();
        }

        public static NeuTupleExprElementList ParseTupleExprElementList(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var elements = parser.ParseTupleExprElements();

            ///

            return new NeuTupleExprElementList(
                children: elements,
                start: start,
                end: parser.Position());
        }

        public static IEnumerable<NeuTupleExprElement> ParseTupleExprElements(
            this NeuParser parser)
        {
            var elements = new List<NeuTupleExprElement>();

            ///

            while (!parser.IsEof())
            {
                if (parser.Tokenizer.PeekRightParen())
                {
                    break;
                }

                ///

                var element = parser.ParseTupleExprElement();

                if (element == null)
                {
                    throw new Exception();
                }

                elements.Add(element);
            }

            ///

            return elements;
        }

        public static NeuTupleExprElement? ParseTupleExprElement(
            this NeuParser parser)
        {
            if (parser.IsEof())
            {
                return null;
            }

            ///

            if (parser.Tokenizer.PeekTupleExprElementDelimiter())
            {
                return null;
            }

            ///

            var start = parser.Position();

            ///

            var token = parser.Tokenizer.Next();

            if (token == null)
            {
                throw new Exception();
            }

            return parser.ParseTupleExprElement(start, token);
        }

        public static NeuTupleExprElement ParseTupleExprElement(
            this NeuParser parser,
            SourceLocation start,
            NeuToken token)
        {
            var children = new List<Node>();

            ///

            switch (parser.Tokenizer.Peek())
            {
                case NeuPunctuation p when p.PunctuationType == NeuPunctuationType.Colon:

                    var colon = parser.Tokenizer.TokenizeColon();

                    children.Add(colon);

                    ///

                    var expr = parser.ParseExpression();

                    if (expr == null)
                    {
                        throw new Exception();
                    }

                    children.Add(expr);

                    break;

                ///

                case NeuToken t when IsTupleExprElementDelimiter(t):
                    
                    var e = parser.ParseExpression(start, token);

                    if (e == null)
                    {
                        throw new Exception();
                    }

                    children.Add(e);

                    break;

                ///

                default:

                    throw new Exception();
            }

            ///

            return new NeuTupleExprElement(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}