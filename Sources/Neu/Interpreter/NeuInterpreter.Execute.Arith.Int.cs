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
            NeuIntegerLiteral lhs,
            NeuBinaryOperator binOp,
            NeuIntegerLiteral rhs)
        {
            switch (binOp.BinaryOperatorType)
            {
                case NeuBinaryOperatorType.Multiply:

                    return new ValueResult<int>(lhs.ToInt() * rhs.ToInt());

                ///

                case NeuBinaryOperatorType.Divide:

                    return new ValueResult<int>(lhs.ToInt() / rhs.ToInt());

                ///

                case NeuBinaryOperatorType.Add:

                    return new ValueResult<int>(lhs.ToInt() + rhs.ToInt());

                ///

                case NeuBinaryOperatorType.Subtract:

                    return new ValueResult<int>(lhs.ToInt() - rhs.ToInt());

                ///

                default:

                    throw new Exception();
            }
        }
    }
}