//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static System.String;

namespace Neu
{
    public partial class NeuExpression : NeuStatement
    {
        public NeuExpression(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    public partial class NeuExprList : NeuNode
    {
        public NeuExprList(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    ///

    public static partial class NeuExpressionHelpers
    {
        public static (String? MemberName, String? IdentifierName) GetMemberAndIdentifierName(
            this NeuExpression expr)
        {
            switch (expr)
            {
                case NeuIdentifierExpr idExpr 
                    when idExpr.Children.First() is NeuIdentifier id:

                    return (null, id.Source);

                ///

                case NeuMemberAccessExpr memberAccessExpr when
                    memberAccessExpr.Children.First() is NeuExpression memberExpr &&
                    memberAccessExpr.Children.Last() is NeuIdentifier id:
                    
                    var member = memberExpr.GetMemberAndIdentifierName();

                    switch (true)
                    {
                        case var _ when !IsNullOrWhiteSpace(member.MemberName) && !IsNullOrWhiteSpace(member.IdentifierName):

                            return ($"{member.MemberName}.{member.IdentifierName}", id.Source);
                        
                        case var _ when !IsNullOrWhiteSpace(member.MemberName):

                            return (member.MemberName, id.Source);

                        case var _ when !IsNullOrWhiteSpace(member.IdentifierName):

                            return (member.IdentifierName, id.Source);

                        default:

                            return (null, id.Source);
                    }

                ///

                case NeuFuncCallExpr funcCallExpr when funcCallExpr.GetFirst<NeuExpression>() is NeuExpression funcCallNameExpr:

                    return funcCallNameExpr.GetMemberAndIdentifierName();


                ///
                
                default:

                    return (null, null);
            }
        }

        // public static void GetMemberName()
        // {

        // }
    }

}