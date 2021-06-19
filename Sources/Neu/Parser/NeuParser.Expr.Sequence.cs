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
        public static NeuExpression ParseSequenceExpr(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            IEnumerable<NeuExpression> expressions)
        {
            var exprList = parser.ParseExprList(start, modifiers, expressions);

            ///

            return new NeuSequenceExpr(
                children: new Node[] {exprList },
                start: start,
                end: parser.Position());
        }

        public static NeuExprList ParseExprList(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifers,
            IEnumerable<NeuExpression> expressions)
        {
            return new NeuExprList(
                children: expressions,
                start: start,
                end: parser.Position());
        }
    }
}