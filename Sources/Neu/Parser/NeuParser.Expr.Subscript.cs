//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuSubscriptExpr ParseSubscriptExpr(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuExpression expr)
        {
            var children = new List<Node>();

            ///

            children.Add(expr);

            ///

            var leftBracket = parser.Tokenizer.TokenizeLeftBrace();

            children.Add(leftBracket);

            ///

            var tupleExprElementList = parser.ParseTupleExprElementList();

            children.Add(tupleExprElementList);

            ///

            var rightBracket = parser.Tokenizer.TokenizeRightBracket();

            children.Add(rightBracket);

            ///

            return new NeuSubscriptExpr(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
     
}