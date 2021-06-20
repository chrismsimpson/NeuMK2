//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuStructDecl : NeuDeclaration
    {
        public NeuStructDecl(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    ///

    public static partial class NeuStructDeclHelpers
    {
        // TODO: generalize to NeuDecl?

        // public static String GetStructDeclName(
        //     this NeuStructDecl structDecl)
        // {
        //     foreach (var child in structDecl.Children)
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



        // public static NeuMemberDeclBlock GetMemberDeclBlock(
        //     this NeuStructDecl structDecl)
        // {
        //     foreach (var child in structDecl.Children)
        //     {
        //         if (child is NeuMemberDeclBlock b)
        //         {
        //             return b;
        //         }
        //     }

        //     throw new Exception();
        // }
    }
}