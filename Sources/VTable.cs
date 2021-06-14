//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public abstract partial class VTable
    {
        public IList<Operation> Operations { get; init; }

        ///

        public VTable()
        {
            this.Operations = new List<Operation>();
        }
    }

    ///

    public static partial class VTableHelpers
    {
        public static void Add(
            this VTable vtable,
            Operation operation)
        {
            vtable.Operations.Add(operation);
        }
    }
}