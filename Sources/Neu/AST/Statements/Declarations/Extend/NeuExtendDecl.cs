//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuExtendDecl : NeuDeclaration
    {
        public NeuExtendDecl(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    ///

    public static partial class NeuExtendDeclHelpers
    {
        // TODO: generalize to NeuDecl?

        // public static String GetExtendDeclName(
        //     this NeuExtendDecl extendDecl)
        // {
        //     foreach (var child in extendDecl.Children)
        //     {
        //         switch (child)
        //         {
        //             case NeuIdentifier identifier:

        //                 return identifier.Source;

        //             ///

        //             default:

        //                 continue;
        //         }
        //     }

        //     throw new Exception();
        // }

        // public static NeuMemberDeclList GetMemberDeclList(
        //     this NeuExtendDecl extendDecl)
        // {
        //     foreach (var child in extendDecl.Children)
        //     {
        //         if (child is NeuMemberDeclList l)
        //         {
        //             return l;
        //         }
        //     }
            
        //     throw new Exception();
        // }
    }
}