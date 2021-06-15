//
//
//

using System;

using static Neu.NeuTokenizer;

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

        public static NueBinaryOperatorExpr ParseBinaryOperatorExpr(
            this NeuParser parser,
            NeuPunctuation punc)
        {
            var binaryOperatorType = ToBinaryOperatorType(punc);

            if (binaryOperatorType == null)
            {
                throw new Exception();
            }

            ///

            return new NueBinaryOperatorExpr(
                children: new Node[]
                {
                    // Cast punc to operator

                    new NeuBinaryOperator(
                        source: punc.Source, 
                        start: punc.Start,
                        end: punc.End,
                        binaryOperatorType: binaryOperatorType.Value)
                },
                start: punc.Start,
                end: punc.End);
        }
    }
}