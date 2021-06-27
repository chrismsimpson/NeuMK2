//
//
//

using System;

namespace Neu
{
    public static partial class IRTokenizerHelpers
    {
        public static IRKeyword RawTokenizeKeyword(
            this Tokenizer<IRToken> tokenizer,
            String s,
            IRKeywordType keywordType)
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

            return new IRKeyword(
                source: next,
                start: start,
                end: tokenizer.Scanner.Position(),
                keywordType: keywordType);
        }

        ///

        public static IRKeyword RawTokenizeFunc(
            this Tokenizer<IRToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("func", IRKeywordType.Func);
        }

        public static IRKeyword RawTokenizeReturn(
            this Tokenizer<IRToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("return", IRKeywordType.Return);
        }
    }
}