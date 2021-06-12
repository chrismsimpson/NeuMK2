//
//
//

using System;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static bool PeekKeyword(
            this NeuParser parser,
            NeuKeywordType keywordType)
        {
            if (parser.Tokenizer.Peek() is NeuKeyword k && k.KeywordType == keywordType)
            {
                return true;
            }

            return false;
        }

        ///

        public static bool PeekCase(
            this NeuParser parser)
        {
            return parser.PeekKeyword(NeuKeywordType.Case);
        }


    }
}