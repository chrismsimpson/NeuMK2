//
//
//

using System;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuSourceFile ParseSourceFile(
            this NeuParser parser)
        {
            var start = parser.Position();

            ///

            var list = parser.ParseCodeBlockItemList();

            ///

            return new NeuSourceFile(
                children: new Node[] { list },
                start: start,
                end: parser.Position());
        }
    }
}