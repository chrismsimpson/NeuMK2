//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static System.String;

namespace Neu
{
    public static partial class NeuInterpreterHelpers
    {
        public static void AddVTableEntry(
            this Interpreter<NeuFrame, NeuVTableEntry> interpreter,
            String? memberName,
            String? name,
            Node node)
        {
            if (interpreter.FindVTableEntry(memberName, name) is NeuVTableEntry)
            {
                throw new Exception();
            }

            ///

            var entry = new NeuVTableEntry(memberName, name, node);

            interpreter.VTable.Add(entry);
        }

        public static NeuVTableEntry? FindVTableEntry(
            this Interpreter<NeuFrame, NeuVTableEntry> interpreter,
            String? memberName,
            String? name)
        {
            return interpreter
                .VTable
                .FirstOrDefault(x =>
                {
                    var a = IsNullOrWhiteSpace(x.MemberName);
                    var b = IsNullOrWhiteSpace(memberName);
                    var c = IsNullOrWhiteSpace(x.Name);
                    var d = IsNullOrWhiteSpace(name);

                    if (a && b && c && d)
                    {
                        return true;
                    }
                    else if (a && b)
                    {
                        return x.Name == name;
                    }
                    else if (c && d)
                    {
                        return x.MemberName == memberName;
                    }
                    else 
                    {
                        return x.MemberName == memberName && x.Name == name;
                    }
                });
        }
    }
}