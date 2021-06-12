//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuReturnClause ParseReturnClause(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var children = new List<Node>();

            ///

            var arrow = parser.Tokenizer.TokenizeArrow();

            children.Add(arrow);

            ///

            var returnType = parser.ParseReturnType();

            children.Add(returnType);

            ///

            return new NeuReturnClause(
                children: children,
                start: start,
                end: parser.Position());
        }

        public static NeuNode ParseReturnType(
            this NeuParser parser)
        {
            if (parser.PeekLeftParen())
            {
                return parser.ParseTupleType();
            }

            return parser.ParseSimpleTypeIdentifier();
        }
    }
}