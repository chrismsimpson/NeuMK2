//
//
//

using System;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NueOperatorExpr ParseOperatorExpr(
            this NeuParser parser,
            NeuOperator op)
        {
            switch (op)
            {
                case NeuBinaryOperator _:

                    return new NueBinaryOperatorExpr(
                        children: new Node[] { op },
                        start: op.Start,
                        end: op.End);

                ///

                default:

                    throw new Exception();
            }
        }
    }
}