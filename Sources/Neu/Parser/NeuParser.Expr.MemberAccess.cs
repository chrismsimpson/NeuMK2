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
        public static NeuMemberAccessExpr ParseMemberAccessExpr(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuExpression expr)
        {
            var children = new List<Node>();

            ///

            children.Add(expr);

            ///

            var period = parser.Tokenizer.TokenizePeriod();

            children.Add(period);

            ///

            var trailingIdentifier = parser.Tokenizer.TokenizeIdentifier();

            children.Add(trailingIdentifier);

            ///

            return new NeuMemberAccessExpr(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}