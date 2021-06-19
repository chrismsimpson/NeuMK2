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

        ///

        public static NeuKeyword RawTokenizeBreak(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("break", NeuKeywordType.Break);
        }

        public static NeuKeyword RawTokenizeCase(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("case", NeuKeywordType.Case);
        }

        public static NeuKeyword RawTokenizeContinue(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("continue", NeuKeywordType.Continue);
        }

        public static NeuKeyword RawTokenizeElse(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("else", NeuKeywordType.Else);
        }

        public static NeuKeyword RawTokenizeEnum(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("enum", NeuKeywordType.Enum);
        }

        public static NeuKeyword RawTokenizeExtend(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("extend", NeuKeywordType.Extend);
        }

        public static NeuKeyword RawTokenizeFalse(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("false", NeuKeywordType.False);
        }

        public static NeuKeyword RawTokenizeFor(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("for", NeuKeywordType.For);
        }

        public static NeuKeyword RawTokenizeFunc(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("func", NeuKeywordType.Func);
        }

        public static NeuKeyword RawTokenizeGuard(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("guard", NeuKeywordType.Guard);
        }

        private static NeuKeyword RawTokenizeIf(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("if", NeuKeywordType.If);
        }

        private static NeuKeyword RawTokenizeIn(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("in", NeuKeywordType.In);
        }

        private static NeuKeyword RawTokenizeInit(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("init", NeuKeywordType.Init);
        }

        private static NeuKeyword RawTokenizeInterface(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("interface", NeuKeywordType.Interface);
        }

        private static NeuKeyword RawTokenizeLet(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("let", NeuKeywordType.Let);
        }

        private static NeuKeyword RawTokenizePrivate(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("private", NeuKeywordType.Private);
        }

        private static NeuKeyword RawTokenizeReturn(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("return", NeuKeywordType.Return);
        }

        private static NeuKeyword RawTokenizeStruct(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("struct", NeuKeywordType.Struct);
        }

        private static NeuKeyword RawTokenizeSwitch(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("switch", NeuKeywordType.Switch);
        }

        private static NeuKeyword RawTokenizeTrue(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("true", NeuKeywordType.True);
        }

        private static NeuKeyword RawTokenizeUsing(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("using", NeuKeywordType.Using);
        }

        private static NeuKeyword RawTokenizeVar(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("var", NeuKeywordType.Var);
        }

        private static NeuKeyword RawTokenizeWhile(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("while", NeuKeywordType.While);
        }

        private static NeuKeyword RawTokenizeWhere(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("where", NeuKeywordType.Where);
        }
    }
}