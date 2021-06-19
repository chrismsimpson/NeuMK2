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
        // there's some duplication here (see ParseExpression(... NeuOperator))

        // public static NueOperatorExpr ParseOperatorExpr(
        //     this NeuParser parser,
        //     NeuOperator op)
        // {
        //     switch (op)
        //     {
        //         case NeuBinaryOperator _:

        //             return new NueBinaryOperatorExpr(
        //                 children: new Node[] { op },
        //                 start: op.Start,
        //                 end: op.End);

        //         ///

        //         default:

        //             throw new Exception();
        //     }
        // }

        // public static NueBinaryOperatorExpr ParseBinaryOperatorExpr(
        //     this NeuParser parser,
        //     NeuPunctuation punc)
        // {
        //     var binaryOperatorType = ToBinaryOperatorType(punc);

        //     if (binaryOperatorType == null)
        //     {
        //         throw new Exception();
        //     }

        //     ///

        //     return new NueBinaryOperatorExpr(
        //         children: new Node[]
        //         {
        //             // Cast punc to operator

        //             new NeuBinaryOperator(
        //                 source: punc.Source, 
        //                 start: punc.Start,
        //                 end: punc.End,
        //                 binaryOperatorType: binaryOperatorType.Value)
        //         },
        //         start: punc.Start,
        //         end: punc.End);
        // }

        public static NueBinaryOperatorExpr ParseBinaryOperatorExpr(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuPunctuation punc)
        {
            if (!IsBinaryOperator(punc))
            {
                throw new Exception();
            }

            ///

            var binOpType = ToBinaryOperatorType(punc);

            if (binOpType == null)
            {
                throw new Exception();
            }

            ///

            var binOp = new NeuBinaryOperator(
                source: punc.Source, 
                start: punc.Start, 
                end: punc.End, 
                binaryOperatorType: binOpType.Value);

            ///

            return parser.ParseBinaryOperatorExpr(start, modifiers, binOp);
        }

        public static NueBinaryOperatorExpr ParseBinaryOperatorExpr(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuBinaryOperator binOp)
        {
            return new NueBinaryOperatorExpr(
                children: new Node[] { binOp },
                start: start,
                end: parser.Position());
        }
    }
}