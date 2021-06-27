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
            NeuExtendDecl extendDecl)
        {
            interpreter.Enter(extendDecl);

            ///

            var extendDeclBlock = extendDecl.GetFirst<NeuMemberDeclBlock>();

            if (extendDeclBlock == null)
            {
                throw new Exception();
            }

            ///

            var extendDeclList = extendDeclBlock.GetFirst<NeuMemberDeclList>();

            if (extendDeclList == null)
            {
                throw new Exception();
            }

            ///

            var result = interpreter.Execute(extendDeclList);

            ///

            interpreter.Exit(extendDecl);

            ///

            return result;
        }
    }
}