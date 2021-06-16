//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuIdentifierPattern ParseIdentifierPattern(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var children = new List<Node>();

            ///

            var id = parser.Tokenizer.TokenizeIdentifier();

            children.Add(id);

            ///

            return new NeuIdentifierPattern(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}