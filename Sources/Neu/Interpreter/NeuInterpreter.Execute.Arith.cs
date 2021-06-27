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
            NeuNumberLiteralExpr lhsExpr,
            NueBinaryOperatorExpr opExpr,
            NeuNumberLiteralExpr rhsExpr)
        {
            var lhsLiteral = lhsExpr.Children.First() as NeuNumberLiteral;

            if (lhsLiteral == null)
            {
                throw new Exception();
            }

            ///

            var binOp = opExpr.Children.First() as NeuBinaryOperator;

            if (binOp == null)
            {
                throw new Exception();
            }

            ///

            var rhsLiteral = rhsExpr.Children.First() as NeuNumberLiteral;

            if (rhsLiteral == null)
            {
                throw new Exception();
            }

            ///

            return interpreter.Execute(lhsLiteral, binOp, rhsLiteral);
        }

        public static Result? Execute(
            this Interpreter<NeuFrame, NeuVTableEntry> interpreter,
            NeuNumberLiteral lhs,
            NeuBinaryOperator binOp,
            NeuNumberLiteral rhs)
        {
            switch (true)
            {
                case var _ when lhs is NeuIntegerLiteral lhsInt &&
                                rhs is NeuIntegerLiteral rhsInt:

                    return interpreter.Execute(lhsInt, binOp, rhsInt);

                ///

                case var _ when lhs is NeuFloatLiteral lhsFloat &&
                                rhs is NeuFloatLiteral rhsFloat:

                    return interpreter.Execute(lhsFloat, binOp, rhsFloat);

                ///
                
                default:

                    throw new Exception();
            }
        }
    }
}