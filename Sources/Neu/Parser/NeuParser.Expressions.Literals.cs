//
//
//

using System;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuLiteralExpr ParseLiteralExpr(
            this NeuParser parser,
            NeuLiteral literal)
        {
            switch (literal)
            {
                case NeuIntegerLiteral _:

                    return new NeuIntLiteralExpr(
                        children: new Node[] { literal },
                        start: literal.Start,
                        end: literal.End);

                ///

                case NeuFloatLiteral _:

                    return new NeuFloatLiteralExpr(
                        children: new Node[] { literal },
                        start: literal.Start,
                        end: literal.End);

                ///

                default:

                    throw new Exception();
            }
        }

        ///

        public static NeuBooleanLiteralExpr ParseBooleanLiteralExpr(
            this NeuParser parser,
            SourceLocation start,
            NeuKeyword keyword)
        {
            throw new Exception();
        }
    }
}   