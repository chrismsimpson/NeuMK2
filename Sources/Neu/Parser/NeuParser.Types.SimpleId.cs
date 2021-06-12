//
//
//

using System;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuSimpleTypeIdentifier ParseSimpleTypeIdentifier(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var identifier = parser.Tokenizer.TokenizeIdentifier();

            ///

            return parser.ParseSimpleTypeIdentifier(start, identifier);
        }

        public static NeuSimpleTypeIdentifier ParseSimpleTypeIdentifier(
            this NeuParser parser,
            SourceLocation start,
            NeuIdentifier identifier)
        {
            return new NeuSimpleTypeIdentifier(
                children: new Node[] { identifier },
                start: start,
                end: parser.Position());
        }
    }
}