//
//
//

using System;

namespace Neu
{
    public static partial class NeuTokenizerHelpers
    {
        private static NeuPunctuation RawTokenizePunctuation(
            this Tokenizer<NeuToken> tokenizer,
            Char c,
            NeuPunctuationType punctuationType)
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

            return new NeuPunctuation(
                source: next,
                start: start,
                end: tokenizer.Scanner.Position(),
                punctuationType: punctuationType);
        }

        private static NeuPunctuation RawTokenizePunctuation(
            this Tokenizer<NeuToken> tokenizer,
            String s,
            NeuPunctuationType punctuationType)
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

            return new NeuPunctuation(
                source: next,
                start: start,
                end: tokenizer.Scanner.Position(),
                punctuationType: punctuationType);
        }

        ///

        private static NeuPunctuation RawTokenizeLeftBrace(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizePunctuation('{', NeuPunctuationType.LeftBrace);
        }

        private static NeuPunctuation RawTokenizeRightBrace(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizePunctuation('}', NeuPunctuationType.RightBrace);
        }

        private static NeuPunctuation RawTokenizeSemicolon(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizePunctuation(';', NeuPunctuationType.Semicolon);
        }

        private static NeuPunctuation RawTokenizeColon(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizePunctuation(':', NeuPunctuationType.Colon);
        }

        private static NeuPunctuation RawTokenizeArrow(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizePunctuation("->", NeuPunctuationType.Arrow);
        }
    }
}