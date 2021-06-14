//
//
//

using System;

namespace Neu
{
    public abstract class Frame<T>
        where T : Node
    {
        public T Node { get; init; }

        ///

        public Frame(
            T node)
        {
            this.Node = node;
        }
    }
}