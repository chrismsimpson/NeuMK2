//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuTokenizerHelpers
    {
        public static bool PeekKeyword(
            this Tokenizer<NeuToken> tokenizer,
            NeuKeywordType keywordType)
        {
            if (tokenizer.Peek() is NeuKeyword k && k.KeywordType == keywordType)
            {
                return true;
            }

            return false;
        }

        ///

        public static bool PeekCase(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.PeekKeyword(NeuKeywordType.Case);
        }


        public static bool PeekModifier(
            this Tokenizer<NeuToken> tokenizer)
        {
            switch (tokenizer.Peek())
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