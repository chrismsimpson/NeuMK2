//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuIdentifierExpr ParseIdentifierExpr(
            this NeuParser parser)
        {
            var token = parser.Tokenizer.TokenizeIdentifier();

            ///

            return parser.ParseIdentifierExpr(token);
        }

        public static NeuIdentifierExpr ParseIdentifierExpr(
            this NeuParser parser,
            NeuIdentifier identifier)
        {
            return new NeuIdentifierExpr(
                children: new Node[] { identifier },
                start: identifier.Start,
                end: identifier.End);
        }
    }
}