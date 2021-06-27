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
            NeuFuncDecl funcDecl)
        {
            var memberName = interpreter.GetScopeName();

            var name = funcDecl.GetDeclName();

            var result = new NeuDeclResult(funcDecl);

            interpreter.AddVTableEntry(memberName, name, funcDecl);

            return result;
        }
    }
}