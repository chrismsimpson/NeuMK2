//
//
//

using System;

namespace Neu
{
    public static partial class NeuTokenizerHelpers
    {
        public static NeuPunctuation TokenizePunctuation(
            this Tokenizer<NeuToken> tokenizer,
            NeuPunctuationType punctuationType)
        {
            var next = tokenizer.Next();

            if (next is NeuPunctuation p && p.PunctuationType == punctuationType)
            {
                return p;
            }

            throw new Exception();
        }

        ///

        public static NeuPunctuation TokenizeLeftBrace(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizePunctuation(NeuPunctuationType.LeftBrace);
        }

        public static NeuPunctuation TokenizeRightBrace(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizePunctuation(NeuPunctuationType.RightBrace);
        }

        public static NeuPunctuation TokenizeLeftParen(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizePunctuation(NeuPunctuationType.LeftParen);
        }

        public static NeuPunctuation TokenizeRightParen(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizePunctuation(NeuPunctuationType.RightParen);
        }

        public static NeuPunctuation TokenizeLeftBracket(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizePunctuation(NeuPunctuationType.LeftBracket);
        }

        public static NeuPunctuation TokenizeRightBracket(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizePunctuation(NeuPunctuationType.RightBracket);
        }

        public static NeuPunctuation TokenizeSemicolon(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizePunctuation(NeuPunctuationType.Semicolon);
        }

        public static NeuPunctuation TokenizeColon(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizePunctuation(NeuPunctuationType.Colon);
        }

        public static NeuPunctuation TokenizeComma(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizePunctuation(NeuPunctuationType.Comma);
        }

        public static NeuPunctuation TokenizeArrow(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizePunctuation(NeuPunctuationType.Arrow);
        }

        public static NeuPunctuation TokenizePeriod(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizePunctuation(NeuPunctuationType.Period);
        }
    }
}