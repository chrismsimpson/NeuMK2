//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static Neu.NeuTokenizer;

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
            if (tokenizer.Peek() is NeuToken t)
            {
                return IsModifier(t);
            }

            return false;
        }

        public static bool PeekUsingTypeKeyword(
            this Tokenizer<NeuToken> tokenizer)
        {
            if (tokenizer.Peek() is NeuToken t)
            {
                return IsUsingTypeKeyword(t);
            }

            return false;
        }

        public static bool PeekElse(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.PeekKeyword(NeuKeywordType.Else);
        }

        public static bool PeekIf(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.PeekKeyword(NeuKeywordType.If);
        }

        public static bool PeekWhere(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.PeekKeyword(NeuKeywordType.Where);
        }
    }
}