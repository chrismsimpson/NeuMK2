//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuInitClause ParseInitClause(
            this NeuParser parser)
        {
            var start = parser.Position();

            /// 

            var children = new List<Node>();

            ///

            var equal = parser.Tokenizer.TokenizeEqual();

            children.Add(equal);

            ///

            var expr = parser.ParseExpression();

            if (expr == null)
            {
                throw new Exception();
            }

            children.Add(expr);

            ///

            return new NeuInitClause(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}