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
            NeuExprList exprList)
        {
            switch (exprList.Children.Count())
            {
                case 3 when exprList.Children.ElementAt(0) is NeuNumberLiteralExpr lhs &&
                            exprList.Children.ElementAt(1) is NueBinaryOperatorExpr op &&
                            exprList.Children.ElementAt(2) is NeuNumberLiteralExpr rhs:

                    return interpreter.Execute(lhs, op, rhs);

                ///
                
                default:

                    throw new Exception();
            }
        }
    }
}