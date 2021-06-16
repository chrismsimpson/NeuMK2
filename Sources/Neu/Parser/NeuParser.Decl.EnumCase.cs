//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuEnumCaseDecl ParseEnumCaseDecl(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuToken token)
        {
            var children = new List<Node>();

            ///

            children.Add(token);

            ///

            var list = parser.ParseEnumCaseElementList();

            children.Add(list);

            ///

            return new NeuEnumCaseDecl(
                children: children,
                start: start,
                end: parser.Position());
        }

        public static NeuEnumCaseElementList ParseEnumCaseElementList(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var items = parser.ParseEnumCaseElements();

            ///

            return new NeuEnumCaseElementList(
                children: items,
                start: start,
                end: parser.Position());
        }

        public static IEnumerable<NeuEnumCaseElement> ParseEnumCaseElements(
            this NeuParser parser)
        {
            var items = new List<NeuEnumCaseElement>();

            ///

            while (!parser.IsEof())
            {
                if (parser.Tokenizer.PeekRightBrace())
                {
                    break;
                }

                ///

                if (parser.Tokenizer.PeekCase())
                {
                    break;
                }

                ///

                var element = parser.ParseEnumCaseElement();

                items.Add(element);
            }

            ///

            return items;
        }

        public static NeuEnumCaseElement ParseEnumCaseElement(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var children = new List<Node>();

            ///

            var identifier = parser.Tokenizer.TokenizeIdentifier();

            children.Add(identifier);

            ///

            if (parser.Tokenizer.PeekComma())
            {
                var comma = parser.Tokenizer.TokenizeComma();

                children.Add(comma);
            }

            ///

            return new NeuEnumCaseElement(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}