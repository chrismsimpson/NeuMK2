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

        public static Operation Execute(
            this NeuExpression expression,
            Interpreter<NeuFrame> interpreter)
        {
            throw new Exception();
        }
    }
}