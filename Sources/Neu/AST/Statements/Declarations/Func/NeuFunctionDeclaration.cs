//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuFuncDecl : NeuDeclaration
    {
        public NeuFuncDecl(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    ///

    public static partial class NeuFuncDeclHelpers
    {
        // TODO: generalize to NeuDecl?

        public static String Name(
            this NeuFuncDecl funcDecl)
        {
            foreach (var child in funcDecl.Children)
            {
                switch (child)
                {
                    case NeuIdentifier identifier:

                        return identifier.Source;

                    ///

                    default:

                        continue;
                }
            }

            throw new Exception();
        }
    }
}