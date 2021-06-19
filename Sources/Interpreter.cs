//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public abstract class Interpreter<F, E>
        where F : Frame<Node>
        where E : VTableEntry
    {   
        internal VTable<E> VTable { get; init; }

        internal Stack<F> Stack { get; init; }

        ///

        public Interpreter(
            Stack<F> frames,
            VTable<E> vtable)
        {
            this.Stack = frames;
            this.VTable = vtable;
        }
    }
}