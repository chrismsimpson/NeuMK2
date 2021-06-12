//
//
//

using System;

namespace Neu
{
    public static partial class NeuTokenizerHelpers
    {
        public static NeuBinaryOperator RawTokenizeBinaryOperator(
            this Tokenizer<NeuToken> tokenizer,
            Char c,
            NeuBinaryOperatorType binaryOperatorType)
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

            return new NeuBinaryOperator(
                source: next,
                start: start,
                end: tokenizer.Scanner.Position(),
                binaryOperatorType: binaryOperatorType);
        }


        private static NeuBinaryOperator RawTokenizeBinaryOperator(
            this Tokenizer<NeuToken> tokenizer,
            String s,
            NeuBinaryOperatorType binaryOperatorType)
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

            return new NeuBinaryOperator(
                source: next,
                start: start,
                end: tokenizer.Scanner.Position(),
                binaryOperatorType: binaryOperatorType);
        }

        ///

        private static NeuBinaryOperator RawTokenizeEqualTo(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeBinaryOperator("==", NeuBinaryOperatorType.EqualTo);
        }

        private static NeuBinaryOperator RawTokenizePlus(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeBinaryOperator('+', NeuBinaryOperatorType.Plus);
        }
    }
}