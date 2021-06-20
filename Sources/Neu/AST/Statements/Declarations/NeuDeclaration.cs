//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuDeclaration : NeuStatement
    {
        public NeuDeclaration(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public static partial class NeuDeclarationHelpers
    {
        public static String GetDeclName(
            this NeuDeclaration decl)
        {
            foreach (var child in decl.Children)
            {
                switch (child)
                {
                    case NeuIdentifier identifier:
                    
                        return identifier.Source;

                    ///

                    case NeuSimpleTypeIdentifier simpleTypeIdentifier:

                        if (simpleTypeIdentifier.Children.First() is NeuIdentifier id)
                        {
                            return id.Source;
                        }

                        continue;

                    ///
                    
                    default:

                        continue;
                }
            }

            throw new Exception();

            // switch (decl)
            // {
            //     case NeuFuncDecl funcDecl:
            //         return funcDecl.GetFuncDeclName();

            //     ///

            //     case NeuStructDecl structDecl:
            //         return structDecl.GetStructDeclName();

            //     ///

            //     case NeuExtendDecl extendDecl:
            //         return extendDecl.GetExtendDeclName();

            //     ///

            //     default:
            //         throw new Exception();
            // }
        }
    }
}