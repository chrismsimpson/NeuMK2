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

        public static bool PeekModifier(
            this NeuParser parser)
        {
            switch (parser.Tokenizer.Peek())
            {
                case NeuKeyword k
                    when k.KeywordType == NeuKeywordType.Private || 
                        k.KeywordType == NeuKeywordType.Internal ||
                        k.KeywordType == NeuKeywordType.Public:

                    return true;

                ///

                default:

                    return false;
            }
        }


    }
}