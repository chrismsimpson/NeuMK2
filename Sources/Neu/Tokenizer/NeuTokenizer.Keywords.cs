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
            this Tokenizer<NeuToken> tokenizer,
            NeuKeywordType keywordType)
        {
            if (tokenizer.Next() is NeuKeyword k && k.KeywordType == keywordType)
            {
                return k;
            }

            throw new Exception();
        }

        public static NeuKeyword TokenizeKeyword(
            this Tokenizer<NeuToken> tokenizer)
        {
            if (tokenizer.Next() is NeuKeyword k)
            {
                return k;
            }

            throw new Exception();
        }

        public static NeuKeyword TokenizeModifier(
            this Tokenizer<NeuToken> tokenizer)
        {
            var keyword = tokenizer.TokenizeKeyword();

            if (IsModifier(keyword))
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

        public static NeuKeyword TokenizeUsingTypeKeyword(
            this Tokenizer<NeuToken> tokenizer)
        {
            var keyword = tokenizer.TokenizeKeyword();

            if (IsUsingTypeKeyword(keyword))
            {
                return keyword;
            }

            throw new Exception();
        }

        public static NeuKeyword TokenizeElse(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizeKeyword(NeuKeywordType.Else);
        }

        public static NeuKeyword TokenizeGuard(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizeKeyword(NeuKeywordType.Guard);
        }

        public static NeuKeyword TokenizeIn(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizeKeyword(NeuKeywordType.In);
        }

        public static NeuKeyword TokenizeInit(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizeKeyword(NeuKeywordType.Init);
        }

        public static NeuKeyword TokenizeCase(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizeKeyword(NeuKeywordType.Case);
        }

        public static NeuKeyword TokenizeVarDeclKeyword(
            this Tokenizer<NeuToken> tokenizer)
        {
            var keyword = tokenizer.TokenizeKeyword();

            if (IsVarDeclKeyword(keyword))
            {
                return keyword;
            }

            throw new Exception();
        }
    }
}