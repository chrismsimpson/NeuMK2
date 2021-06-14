//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuExpression ParseMemberAccess(
            this NeuParser parser,
            NeuIdentifier identifier)
        {
            var memberAccessExpr = parser.ParseMemberAccessExpr(identifier);

            return parser.ParseMemberAccess(memberAccessExpr);
        }

        public static NeuExpression ParseMemberAccess(
            this NeuParser parser,
            NeuMemberAccessExpr memberAccessExpr)
        {
            switch (parser.Tokenizer.Peek())
            {
                case NeuPunctuation p when p.PunctuationType == NeuPunctuationType.LeftParen:

                    return parser.ParseFuncCallExpr(memberAccessExpr);

                ///

                case NeuPunctuation p when p.PunctuationType == NeuPunctuationType.Equal:

                    return parser.ParseAssignmentExpr();
                        
                ///

                default: 

                    throw new Exception();
            }
        }

        public static NeuMemberAccessExpr ParseMemberAccessExpr(
            this NeuParser parser,
            NeuIdentifier identifier)
        {
            throw new Exception();
        }
    }
}