//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuInterpreter : Interpreter<NeuFrame, NeuVTableEntry>
    {
        public NeuInterpreter()
            : base(new Stack<NeuFrame>(), new NeuVTable()) { }

        public NeuInterpreter(
            Stack<NeuFrame> frames)
            : base(frames, new NeuVTable()) { }

        public NeuInterpreter(
            Stack<NeuFrame> frames,
            NeuVTable vtable)
            : base(frames, vtable) { }
    }

    public static partial class NeuInterpreterHelpers
    {
        public static Operation? Run(
            this Interpreter<NeuFrame, NeuVTableEntry> interpreter,
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

                    case NeuStructDecl structDecl:

                        result = structDecl.Execute(interpreter);

                        break;

                    case NeuExtendDecl extendDecl:

                        result = extendDecl.Execute(interpreter);

                        break;

                    ///

                    case NeuExpression expr:

                        result = expr.Execute(interpreter);

                        break;

                    ///



                    // case NeuCodeBlockItemList codeBlockItemList:

                    //     result = codeBlockItemList.Execute(interpreter);

                    //     break;



                    case NeuNode childNode:

                        result = interpreter.Run(childNode);

                        break;

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

        private static String GetInterpreterHash(
            Node node)
        {
            return $"{node.GetType()}:{node.Start.RawPosition}:{node.End.RawPosition}";
        }

        private static bool AreEqual(
            Node lhs,
            Node rhs)
        {
            var lhsHash = GetInterpreterHash(lhs);
            var rhsHash = GetInterpreterHash(rhs);

            return lhsHash == rhsHash;
        }
    }
}