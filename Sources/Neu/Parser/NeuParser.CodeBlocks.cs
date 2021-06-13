//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuCodeBlock ParseCodeBlock(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var children = new List<Node>();

            ///

            var leftBrace = parser.Tokenizer.TokenizeLeftBrace();

            children.Add(leftBrace);

            ///

            var list = parser.ParseCodeBlockList();

            children.Add(list);

            ///

            var rightBrace = parser.Tokenizer.TokenizeRightBrace();

            children.Add(rightBrace);

            ///

            return new NeuCodeBlock(
                children: children,
                start: start,
                end: parser.Position());
        }

        ///

        public static NeuCodeBlockList ParseCodeBlockList(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var items = parser.ParseCodeBlockItems();            

            ///

            return new NeuCodeBlockList(
                children: items,
                start: start,
                end: parser.Position());
        }

        ///

        public static IEnumerable<NeuCodeBlockItem> ParseCodeBlockItems(
            this NeuParser parser)
        {
            var items = new List<NeuCodeBlockItem>();

            ///

            while (!parser.IsEof())
            {
                if (parser.Tokenizer.PeekRightBrace())
                {
                    break;
                }

                ///

                var codeBlockItem = parser.ParseCodeBlockItem();

                if (codeBlockItem == null)
                {
                    break;
                }

                ///

                items.Add(codeBlockItem);

                ///

                if (parser.Tokenizer.PeekCase())
                {
                    break;
                }
            }

            ///

            return items;
        }

        ///

        public static NeuCodeBlockItem? ParseCodeBlockItem(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            while (!parser.IsEof())
            {
                if (parser.Tokenizer.PeekRightBrace())
                {
                    break;
                }

                ///

                var token = parser.Tokenizer.Next();

                if (token == null)
                {
                    break;
                }

                ///

                if (token is NeuComment)
                {
                    continue;
                }

                ///

                return parser.ParseCodeBlockItem(start, token);
            }

            return null;
        }

        ///

        public static NeuCodeBlockItem ParseCodeBlockItem(
            this NeuParser parser,
            SourceLocation start,
            NeuToken token)
        {
            var children = new List<Node>();

            ///

            var stmt = parser.ParseStatement(start, token);

            children.Add(stmt);

            ///

            if (parser.Tokenizer.PeekSemicolon())
            {
                children.Add(parser.Tokenizer.TokenizeSemicolon());
            }

            ///

            return new NeuCodeBlockItem(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}