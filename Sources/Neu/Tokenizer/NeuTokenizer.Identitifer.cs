//
//
//

using System;

using static Neu.NeuTokenizer;

namespace Neu
{
    public static partial class NeuTokenizerHelpers
    {
        public static NeuIdentifier RawTokenizeIdentifier(
            this Tokenizer<NeuToken> tokenizer)
        {
            var start = tokenizer.Scanner.Position();

            ///

            var source = tokenizer.Scanner.Consume(c => IsIdentifierPart(c));

            ///

            tokenizer.Scanner.ConsumeWhitespace();

            ///

            return new NeuIdentifier(
                source: source,
                start: start,
                end: tokenizer.Scanner.Position());
        }

        ///

        public static NeuIdentifier TokenizeIdentifier(
            this Tokenizer<NeuToken> tokenizer)
        {
            if (tokenizer.Next() is NeuIdentifier i)
            {
                return i;
            }

            throw new Exception();
        }
    }
}