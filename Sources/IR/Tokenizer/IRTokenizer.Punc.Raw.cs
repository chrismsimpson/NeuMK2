//
//
//

using System;

namespace Neu
{
    public static partial class IRTokenizerHelpers
    {
        private static IRPunc RawTokenizePunc(
            this Tokenizer<IRToken> tokenizer,
            Char c,
            IRPuncType puncType)
        {
            var start = tokenizer.Scanner.Position();

            ///

            var next = tokenizer.Scanner.Consume();

            if (next != c)
            {
                throw new Exception();
            }

            ///

            tokenizer.Scanner.ConsumeWhitespace();

            ///

            return new IRPunc(
                source: next,
                start: start,
                end: tokenizer.Scanner.Position(),
                puncType: puncType);
        }

        private static IRPunc RawTokenizePunc(
            this Tokenizer<IRToken> tokenizer,
            String s,
            IRPuncType puncType)
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

            return new IRPunc(
                source: next,
                start: start,
                end: tokenizer.Scanner.Position(),
                puncType: puncType);
        }

        ///

        private static IRPunc RawTokenizeArrow(
            this Tokenizer<IRToken> tokenizer)
        {
            return tokenizer.RawTokenizePunc("->", IRPuncType.Arrow);
        }

        private static IRPunc RawTokenizeLeftParen(
            this Tokenizer<IRToken> tokenizer)
        {
            return tokenizer.RawTokenizePunc('(', IRPuncType.LeftParen);
        }

        private static IRPunc RawTokenizeRightParen(
            this Tokenizer<IRToken> tokenizer)
        {
            return tokenizer.RawTokenizePunc(')', IRPuncType.RightParen);
        }

        private static IRPunc RawTokenizeLeftBrace(
            this Tokenizer<IRToken> tokenizer)
        {
            return tokenizer.RawTokenizePunc('{', IRPuncType.LeftBrace);
        }

        private static IRPunc RawTokenizeRightBrace(
            this Tokenizer<IRToken> tokenizer)
        {
            return tokenizer.RawTokenizePunc('}', IRPuncType.RightBrace);
        }

        private static IRPunc RawTokenizeLeftBracket(
            this Tokenizer<IRToken> tokenizer)
        {
            return tokenizer.RawTokenizePunc('[', IRPuncType.LeftBracket);
        }

        private static IRPunc RawTokenizeRightBracket(
            this Tokenizer<IRToken> tokenizer)
        {
            return tokenizer.RawTokenizePunc(']', IRPuncType.RightBracket);
        }
    }
}