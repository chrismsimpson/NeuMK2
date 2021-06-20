//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuInterpreterHelpers
    {
        public static NeuVTableEntry Find(
            this Interpreter<NeuFrame, NeuVTableEntry> interpreter,
            String? memberName,
            String name)
        {
            return interpreter
                .VTable
                .Entries
                .First(x => x.MemberName == memberName && x.Name == name);
        }
    }
}