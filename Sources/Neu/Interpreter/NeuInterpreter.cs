//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static System.String;

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

    public partial class NeuInterpreter
    {
        public static String GetInterpreterHash(
            Node node)
        {
            return $"{node.GetType()}:{node.Start.RawPosition}:{node.End.RawPosition}";
        }

        public static bool AreEqual(
            Node lhs,
            Node rhs)
        {
            var lhsHash = GetInterpreterHash(lhs);
            var rhsHash = GetInterpreterHash(rhs);

            return lhsHash == rhsHash;
        }
    }
}