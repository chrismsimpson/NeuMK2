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
            NeuStructDecl structDecl)
        {
            interpreter.Enter(structDecl);

            ///

            var structDeclBlock = structDecl.GetFirst<NeuMemberDeclBlock>();

            if (structDeclBlock == null)
            {
                throw new Exception();
            }

            ///

            var structDeclList = structDeclBlock.GetFirst<NeuMemberDeclList>();

            if (structDeclList == null)
            {
                throw new Exception();
            }

            ///

            var result = interpreter.Execute(structDeclList);

            ///

            interpreter.Exit(structDecl);

            ///

            return result;
        }
    }
}