//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static System.String;

using static Neu.NeuInterpreter;

namespace Neu
{
    public static partial class NeuInterpreterHelpers
    {
        public static void Enter(
            this Interpreter<NeuFrame, NeuVTableEntry> interpreter,
            NeuNode node)
        {
            interpreter.Stack.Push(new NeuFrame(node));
        }

        ///

        public static void Exit(
            this Interpreter<NeuFrame, NeuVTableEntry> interpreter,
            NeuNode node)
        {
            if (!AreEqual(interpreter.Stack.First().Node, node))
            {
                throw new Exception();
            }

            interpreter.Stack.Pop();
        }
    }
}