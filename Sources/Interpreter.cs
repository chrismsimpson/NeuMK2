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
        internal Stack<F> Stack { get; init; }

        // internal VTable<E> VTable { get; init; }
        internal IList<E> VTable { get; init; }

        ///

        public Interpreter(
            Stack<F> stack,
            IList<E> vtable)
            // VTable<E> vtable)
        {
            this.Stack = stack;
            this.VTable = vtable;
        }
    }
}