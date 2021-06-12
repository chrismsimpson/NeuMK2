//
//
//

using System;

namespace Neu
{
    public static partial class NeuTokenizerHelpers
    {
        public static NeuKeyword RawTokenizeKeyword(
            this Tokenizer<NeuToken> tokenizer,
            String s,
            NeuKeywordType keywordType)
        {
            var start = tokenizer.Scanner.Position();

            ///

            var next = tokenizer.Scanner.ConsumeString(length: s.Length);

            if (next != s)
            {
                throw new Exception();
            }

            ///

            tokenizer.Scanner.ConsumeWhitespace();

            ///

            return new NeuKeyword(
                source: next,
                start: start,
                end: tokenizer.Scanner.Position(),
                keywordType: keywordType);
        }

        public static NeuKeyword RawTokenizeFunc(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("func", NeuKeywordType.Func);
        }

        ///
    }
}