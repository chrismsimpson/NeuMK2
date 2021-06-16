//
//
//

using System;
using System.Collections.Generic;

using static System.Array;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuMemberDeclBlock ParseMemberDeclBlock(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var children = new List<Node>();

            ///

            var leftBrace = parser.Tokenizer.TokenizeLeftBrace();

            children.Add(leftBrace);

            ///

            var list = parser.ParseMemberDeclList();

            children.Add(list);

            ///

            var rightBrace = parser.Tokenizer.TokenizeRightBrace();

            children.Add(rightBrace);

            ///

            return new NeuMemberDeclBlock(
                children: children,
                start: start,
                end: parser.Position());
        }

        public static NeuMemberDeclList ParseMemberDeclList(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var items = parser.ParseMemberDeclListItems();

            ///

            return new NeuMemberDeclList(
                children: items,
                start: start,
                end: parser.Position());
        }

        public static IEnumerable<NeuMemberDeclListItem> ParseMemberDeclListItems(
            this NeuParser parser)
        {
            var items = new List<NeuMemberDeclListItem>();

            ///

            while (!parser.IsEof())
            {
                if (parser.Tokenizer.PeekRightBrace())
                {
                    break;
                }

                ///

                var memberDeclListItem = parser.ParseMemberDeclListItem();

                if (memberDeclListItem == null)
                {
                    break;
                }

                items.Add(memberDeclListItem);
            }

            ///

            return items;
        }

        public static NeuMemberDeclListItem? ParseMemberDeclListItem(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            while (!parser.IsEof())
            {
                if (parser.Tokenizer.PeekRightBrace())
                {
                    return null;
                }

                ///

                var token = parser.Tokenizer.Next();

                if (token == null)
                {
                    return null;
                }

                ///

                if (token is NeuComment)
                {
                    continue;
                }

                ///

                var stmt = parser.ParseStatement(start, token);

                ///

                return new NeuMemberDeclListItem(
                    children: new Node[] { stmt },
                    start: start,
                    end: parser.Position());
            }

            ///

            throw new Exception();
        }
    }
}