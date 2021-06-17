//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuTypeAnnotation ParseTypeAnnotation(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var children = new List<Node>();

            ///

            var colon = parser.Tokenizer.TokenizeColon();

            children.Add(colon);

            ///

            var typeId = parser.ParseTypeIdentifier();

            children.Add(typeId);

            ///

            return new NeuTypeAnnotation(
                children: children,
                start: start,
                end: parser.Position());
        }
    }
}