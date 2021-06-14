//
//
//

using System;

namespace Neu
{
    public static partial class NeuInterpreterHelpers
    {
        public static Operation Execute(
            this NeuFuncDecl funcDecl,
            Interpreter<NeuFrame> interpreter)
        {
            var func = new NeuFunc();

            interpreter.VTable.Add(func);

            return func;
        }
    }
}