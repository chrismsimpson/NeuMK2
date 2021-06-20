//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class VTableEntry
    {
        public String? Name { get; init; }

        public Node Node { get; init; }

        ///

        public VTableEntry(
            String? name,
            Node node)
        {
            this.Name = name;
            this.Node = node;
        }
    }

    public abstract partial class VTable<T> where T : VTableEntry
    {
        internal IList<T> Entries { get; init; }

        ///

        public VTable()
        {
            this.Entries = new List<T>();
        }
    }

    ///

    public static partial class VTableHelpers
    {
        public static void Add<T>(
            this VTable<T> vtable,
            T entry)
            where T : VTableEntry
        {
            vtable.Entries.Add(entry);
        }
    }
}