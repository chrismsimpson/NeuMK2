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

        public Operation Operation { get; init; }

        ///

        public VTableEntry(
            String? name,
            Operation op)
        {
            this.Name = name;
            this.Operation = op;
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

    // public abstract partial class VTable 
    // {
    //     public IDictionary<String, Operation> Operations { get; init; }

    //     // public IList<Operation> Operations { get; init; }

    //     ///

    //     public VTable()
    //     {
    //         this.Operations = new Dictionary<String, Operation>();
    //         // this.Operations = new List<Operation>();
    //     }
    // }

    ///

    public static partial class VTableHelpers
    {
        public static void Add<T>(
            this VTable<T> vtable,
            T entry)
            // String name,
            // Operation operation)
            where T : VTableEntry
        {
            vtable.Entries.Add(entry);
            // vtable.Entries.Add(new )
            // vtable.Operations[name] = operation;
            // vtable.Operations.Add(operation);
        }
    }
}