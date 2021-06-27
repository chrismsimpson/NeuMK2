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
            NeuReturnStatement returnStmt)
        {
            interpreter.Enter(returnStmt);

            ///

            Result? result = null;

            ///
            
            var expr = returnStmt.GetFirst<NeuExpression>();

            if (expr != null)
            {
                result = interpreter.Execute(expr);
            }

            ///

            interpreter.Exit(returnStmt);

            ///

            return result;
        }
    }
}