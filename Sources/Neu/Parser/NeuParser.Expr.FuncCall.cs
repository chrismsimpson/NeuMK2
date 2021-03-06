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
        public static NeuFuncCallExpr ParseFuncCallExpr(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuExpression expr)
        {
            var children = new List<Node>();

            ///

            children.Add(expr);

            ///

            var leftParen = parser.Tokenizer.TokenizeLeftParen();

            children.Add(leftParen);

            ///

            var tupleExprElementList = parser.ParseTupleExprElementList();

            children.Add(tupleExprElementList);

            ///

            var rightParen = parser.Tokenizer.TokenizeRightParen();

            children.Add(rightParen);

            ///

            return new NeuFuncCallExpr(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}