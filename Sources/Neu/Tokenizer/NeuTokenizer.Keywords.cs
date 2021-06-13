//
//
//

using System;
using System.Collections.Generic;

using static Neu.NeuTokenizer;

namespace Neu
{
    public static partial class NeuTokenizerHelpers
    {
        public static NeuKeyword TokenizeKeyword(
            this Tokenizer<NeuToken> tokenizer)
        {
            if (tokenizer.Next() is NeuKeyword k)
            {
                return k;
            }

            throw new Exception();
        }

        public static NeuToken TokenizeModifier(
            this Tokenizer<NeuToken> tokenizer)
        {
            var keyword = tokenizer.TokenizeKeyword();

            if (IsStatementModifier(keyword))
            {
                return keyword;
            }

            throw new Exception();
        }

        public static IEnumerable<NeuToken> TokenizeModifiers(
            this Tokenizer<NeuToken> tokenizer)
        {
            var modifiers = new List<NeuToken>();

            while (tokenizer.PeekModifier())
            {
                var modifier = tokenizer.TokenizeModifier();

                modifiers.Add(modifier);
            }

            return modifiers;
        }

    }
}