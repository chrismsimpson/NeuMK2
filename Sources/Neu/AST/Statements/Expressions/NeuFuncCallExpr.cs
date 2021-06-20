//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuFuncCallExpr : NeuExpression
    {
        public NeuFuncCallExpr(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    ///

    public static partial class NeuFuncCallExprHelpers
    {
        // public static void GetMemberName(
        //     this NeuFuncCallExpr funcCallExpr)
        // {


        //     var expr = funcCallExpr.GetFirst<NeuExpression>();

        //     ///

        //     switch (expr)
        //     {
        //         case NeuIdentifierExpr idExpr:

        //             break;

        //         ///

        //         case NeuMemberAccessExpr memberAccessExpr:

        //             break;

        //         ///
                
        //         default:

        //             throw new Exception();
        //     }
        // }

        // public static void 
    }
}