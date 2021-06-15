//
//
//

using System;
using System.Collections.Generic;

using static Neu.NeuTokenizer;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuFloatLiteralExpr ParseNeuFloatLiteralExpr(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuFloatLiteral floatLiteral)
        {
            return new NeuFloatLiteralExpr(
                children: new Node[] { floatLiteral },
                start: start,
                end: parser.Position());
        }

        public static NeuIntLiteralExpr ParseNeuIntLiteralExpr(
            this NeuParser parser,
            SourceLocation start,
            IEnumerable<NeuToken> modifiers,
            NeuIntegerLiteral intLiteral)
        {
            return new NeuIntLiteralExpr(
                children: new Node[] { intLiteral },
                start: start,
                end: parser.Position());
        }

        public static NeuBooleanLiteralExpr ParseBooleanLiteralExpr(
            this NeuParser parser,
            SourceLocation start,
            NeuKeyword keyword)
        {
            if (!IsBooleanLiteral(keyword))
            {
                throw new Exception();
            }

            ///

            return new NeuBooleanLiteralExpr(
                children: new Node[] { keyword },
                start: start,
                end: parser.Position());
        }
    }
}   