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
        public static NeuTypeAlignClause ParseTypeAlignClause(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var children = new List<Node>();

            ///

            var colon = parser.Tokenizer.TokenizeColon();

            children.Add(colon);

            ///

            var alignedTypeList = parser.ParseAlignedTypeList();

            children.Add(alignedTypeList);

            ///

            return new NeuTypeAlignClause(
                children: children,
                start: start,
                end: parser.Position());
        }

        public static NeuAlignedTypeList ParseAlignedTypeList(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var children = new List<Node>();

            ///

            while (!parser.IsEof())
            {
                if (parser.Tokenizer.PeekLeftBrace())
                {
                    break;
                }

                ///

                var alignedType = parser.ParseAlignedType();

                children.Add(alignedType);
            }

            ///

            return new NeuAlignedTypeList(
                children: children,
                start: start,
                end: parser.Position());
        }

        public static NeuAlignedType ParseAlignedType(
            this NeuParser parser)
        {
            var start = parser.Position();

            // ///

            var children = new List<Node>();

            ///

            var typeId = parser.ParseTypeIdentifier();

            children.Add(typeId);
            
            ///

            if (parser.Tokenizer.PeekComma())
            {
                var comma = parser.Tokenizer.TokenizeComma();

                children.Add(comma);
            }

            ///

            return new NeuAlignedType(
                children: children,
                start: start,
                end: parser.Position());
        }

        ///

        public static NeuNode ParseTypeIdentifier(
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

            return parser.ParseTypeIdentifier(start, token);
        }

        public static NeuNode ParseTypeIdentifier(
            this NeuParser parser,
            SourceLocation start,
            NeuToken token)
        {
            switch (token)
            {
                case NeuIdentifier identifier:

                    return parser.ParseTypeIdentifier(start, identifier);

                ///

                default: 

                    throw new Exception();
            }
        }

        public static NeuNode ParseTypeIdentifier(
            this NeuParser parser,
            SourceLocation start,
            NeuIdentifier identifier)
        {
            var simpleTypeId = parser.ParseSimpleTypeIdentifier(start, identifier);

            ///

            return parser.ParseTypeIdentifier(start, simpleTypeId);
        }

        public static NeuNode ParseTypeIdentifier(
            this NeuParser parser,
            SourceLocation start,
            NeuNode node)
        {
            switch (parser.Tokenizer.Peek())
            {
                case NeuPunctuation p when p.PunctuationType == NeuPunctuationType.Period:
                    
                    var memberTypeId = parser.ParseMemberTypeId(start, node);

                    return parser.ParseTypeIdentifier(start, memberTypeId);

                ///

                case NeuToken t when IsTypeIdDelimiter(t):

                    return node;

                ///

                default:

                    throw new Exception();
            }
        }

        public static NeuMemberTypeIdentifier ParseMemberTypeId(
            this NeuParser parser,
            SourceLocation start,
            NeuNode node)
        {
            var children = new List<Node>();

            ///

            children.Add(node);

            ///

            var period = parser.Tokenizer.TokenizePeriod();

            children.Add(period);

            ///

            var trailingId = parser.Tokenizer.TokenizeIdentifier();

            children.Add(trailingId);

            ///

            return new NeuMemberTypeIdentifier(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}