//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuInterpreter : Interpreter<NeuFrame>
    {
        public NeuInterpreter()
            : base(new Stack<NeuFrame>(), new NeuVTable()) { }

        public NeuInterpreter(
            Stack<NeuFrame> frames)
            : base(frames, new NeuVTable()) { }

        public NeuInterpreter(
            Stack<NeuFrame> frames,
            NeuVTable vTable)
            : base(frames, vTable) { }
    }

    public static partial class NeuInterpreterHelpers
    {
        public static Operation? Run(
            this Interpreter<NeuFrame> interpreter,
            NeuNode node)
        {
            interpreter.Enter(node);

            Operation? result = null;

            foreach (var child in node.Children)
            {
                switch (child)
                {
                    case NeuFuncDecl funcDecl:

                        result = funcDecl.Execute(interpreter);

                        break;

                    ///

                    case NeuCodeBlockList codeBlockList:

                        throw new Exception();

                    ///

                    default:

                        throw new Exception();
                }
            }

            interpreter.Exit(node);

            return result;
        }

        ///

        public static void Enter(
            this Interpreter<NeuFrame> interpreter,
            NeuNode node)
        {
            interpreter.Stack.Push(new NeuFrame(node));
        }

        ///

        public static void Exit(
            this Interpreter<NeuFrame> interpreter,
            NeuNode node)
        {
            if (interpreter.Stack.Last().Node != node)
            {
                throw new Exception();
            }

            interpreter.Stack.Pop();
        }
    }
}