//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static Neu.NeuTokenizer;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuExprPattern ParseExpressionPattern(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            /// Possibly migrate to ParseExpression, when it exists?
            // var expression = parser.ParseConditionExpression();

            var expression = parser.ParseExpression();

            if (expression == null)
            {
                throw new Exception();
            }

            ///

            return new NeuExprPattern(
                children: new Node[] { expression },
                start: start,
                end: parser.Position());
        }
    }
}