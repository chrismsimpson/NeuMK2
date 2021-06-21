//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuVTableEntry : VTableEntry
    {
        public String? MemberName { get; init; }

        ///

        public NeuVTableEntry(
            String? memberName,
            String? name,
            Node node)
            : base(name, node)
        {
            this.MemberName = memberName;
        }
    }

    // public partial class NeuVTable : VTable<NeuVTableEntry>
    // {
    //     public NeuVTable()
    //         : base() { } 
    // }

    // public static partial class NeuVTableHelpers
    // {
    //     public static void Add(
    //         this VTable<NeuVTableEntry> vtable,
    //         String? memberName,
    //         String? name,
    //         NeuNode node)
    //     {
    //         var entry = new NeuVTableEntry(
    //             memberName: memberName,
    //             name: name,
    //             node: node);

    //         vtable.Add(entry);
    //     }
    // }
}