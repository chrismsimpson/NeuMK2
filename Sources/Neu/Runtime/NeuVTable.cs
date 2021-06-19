//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuVTableEntry : VTableEntry
    {
        public dynamic? MemberAccess { get; init; }

        ///

        public NeuVTableEntry(
            dynamic? memberAccess,
            String? name,
            Operation op)
            : base(name, op)
        {
            this.MemberAccess = memberAccess;
        }
    }

    public partial class NeuVTable : VTable<NeuVTableEntry>
    {
        public NeuVTable()
            : base() { } 
    }

    public static partial class NeuVTableHelpers
    {
        public static void Add(
            this VTable<NeuVTableEntry> vtable,
            dynamic? memberAccess,
            String? name,
            NeuOperation op)
        {
            var entry = new NeuVTableEntry(
                memberAccess: memberAccess,
                name: name,
                op: op);

            vtable.Add(entry);
        }
    }
}