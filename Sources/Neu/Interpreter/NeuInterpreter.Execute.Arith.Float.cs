//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static System.String;
using static System.Console;

namespace Neu
{
    public static partial class NeuInterpreterHelpers
    {
        public static Result? Execute(
            this Interpreter<NeuFrame, NeuVTableEntry> interpreter,
            NeuFloatLiteral lhs,
            NeuBinaryOperator binOp,
            NeuFloatLiteral rhs)
        {
            switch (binOp.BinaryOperatorType)
            {
                case NeuBinaryOperatorType.Multiply:

                    return new ValueResult<float>(lhs.ToFloat() * rhs.ToFloat());

                ///

                case NeuBinaryOperatorType.Divide:

                    return new ValueResult<float>(lhs.ToFloat() / rhs.ToFloat());

                ///

                case NeuBinaryOperatorType.Add:

                    return new ValueResult<float>(lhs.ToFloat() + rhs.ToFloat());

                ///

                case NeuBinaryOperatorType.Subtract:

                    return new ValueResult<float>(lhs.ToFloat() - rhs.ToFloat());

                ///

                default:

                    throw new Exception();
            }
        }
    }
}