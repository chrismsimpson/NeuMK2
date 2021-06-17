//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuClosureExpr ParseClosureExpr(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuPunctuation punc)
        {
            var children = new List<Node>();

            ///

            var leftBrace = parser.Tokenizer.TokenizeLeftBrace();

            children.Add(leftBrace);

            ///

            var closureSig = parser.ParseClosureSignature();

            children.Add(closureSig);

            ///

            var codeBlockItemList = parser.ParseCodeBlockItemList();

            children.Add(codeBlockItemList);

            ///

            var rightBrace = parser.Tokenizer.TokenizeRightBrace();

            children.Add(rightBrace);

            ///

            return new NeuClosureExpr(
                children: children,
                start: start,
                end: parser.Position());
        }

        public static NeuClosureSignature ParseClosureSignature(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var children = new List<Node>();

            ///

            var paramClause = parser.ParseParameterClause();

            children.Add(paramClause);

            ///

            var returnClause = parser.ParseReturnClause();

            children.Add(returnClause);

            ///

            var inKeyword = parser.Tokenizer.TokenizeIn();

            children.Add(inKeyword);

            ///

            return new NeuClosureSignature(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}