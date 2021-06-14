//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public abstract class Interpreter<F> where F : Frame<Node>
    {   
        internal VTable VTable { get; init; }

        internal Stack<F> Stack { get; init; }

        ///

        public Interpreter(
            Stack<F> frames,
            VTable vTable)
        {
            this.Stack = frames;
            this.VTable = vTable;
        }
    }
}