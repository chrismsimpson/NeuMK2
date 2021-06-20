//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuVLookup
    {
        public String? Module { get; init; }

        public String? Namespace { get; init; }

        public String? MemberAccess { get; init; }

        public String Name { get; init; }

        ///

        public NeuVLookup(
            String? module,
            String? ns,
            String? memberAccess,
            String name)
        {
            this.Module = module;
            this.Namespace = ns;
            this.MemberAccess = memberAccess;
            this.Name = name;
        }   
    }
}