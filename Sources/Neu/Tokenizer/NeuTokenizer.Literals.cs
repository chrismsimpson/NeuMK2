//
//
//

using System;

using static System.String;

using static Neu.NeuTokenizer;

namespace Neu
{
    public static partial class NeuTokenizerHelpers
    {
        public static NeuNumberLiteral RawTokenizeBinaryLiteral(
            this Tokenizer<NeuToken> tokenizer)
        {
            throw new Exception();
        }

        public static NeuNumberLiteral RawTokenizeOctalLiteral(
            this Tokenizer<NeuToken> tokenizer)
        {
            throw new Exception();
        }

        public static NeuNumberLiteral RawTokenizeHexLiteral(
            this Tokenizer<NeuToken> tokenizer)
        {
            throw new Exception();
        }

        public static NeuNumberLiteral RawTokenizeNumberLiteral(
            this Tokenizer<NeuToken> tokenizer,
            Char firstChar)
        {
            switch (firstChar)
            {
                case '0' when tokenizer.Scanner.Peek(equals: 'b'):
                    return tokenizer.RawTokenizeBinaryLiteral();

                case '0' when tokenizer.Scanner.Peek(equals: 'o'):
                    return tokenizer.RawTokenizeOctalLiteral();

                case '0' when tokenizer.Scanner.Peek(equals: 'x'):
                    return tokenizer.RawTokenizeHexLiteral();

                default:
                    return tokenizer.RawTokenizeFloatOrIntLiteral();
            }
        }

        private static NeuNumberLiteral RawTokenizeFloatOrIntLiteral(
            this Tokenizer<NeuToken> tokenizer)
        {
            var start = tokenizer.Position();

            ///

            var source = tokenizer.Scanner.Consume(c => IsNumberLiteralPart(c));

            if (IsNullOrWhiteSpace(source))
            {
                throw new Exception();
            }

            ///

            tokenizer.Scanner.ConsumeWhitespace();

            ///

            return tokenizer.RawTokenizeFloatOrIntLiteral(start, source);
        }

        private static NeuNumberLiteral RawTokenizeFloatOrIntLiteral(
            this Tokenizer<NeuToken> tokenizer,
            SourceLocation start,
            String source)
        {
            switch (true)
            {
                case var _ when IsIntegerLiteral(source):

                    return new NeuIntegerLiteral(
                        source: source,
                        start: start,
                        end: tokenizer.Position());

                /// 

                case var _ when IsFloatLiteral(source):

                    return new NeuFloatLiteral(
                        source: source,
                        start: start,
                        end: tokenizer.Position());

                ///

                default:

                    throw new Exception();
            }
        }
    }
}