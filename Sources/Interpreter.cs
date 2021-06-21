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
        internal IList<E> VTable { get; init; }
        // internal VTable<E> VTable { get; init; }

        internal Stack<F> Stack { get; init; }

        ///

        public Interpreter(
            Stack<F> frames,
            IList<E> vtable)
            // VTable<E> vtable)
        {
            this.Stack = frames;
            this.VTable = vtable;
        }
    }
}