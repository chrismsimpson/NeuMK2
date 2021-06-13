//
//
//

using System;

namespace Neu
{
    public static partial class NeuTokenizerHelpers
    {   
        public static NeuComment RawTokenizeLineEndComment(
            this Tokenizer<NeuToken> tokenizer)
        {
            var start = tokenizer.Scanner.Position();

            ///

            var source = tokenizer.Scanner.ConsumeUntil(c => c == '\n');

            ///

            return new NeuComment(
                source: source,
                start: start,
                end: tokenizer.Scanner.Position());
        }

        ///

        public static NeuComment RawTokenizeInlineComment(
            this Tokenizer<NeuToken> tokenizer)
        {
            var start = tokenizer.Scanner.Position();

            ///

            var source = tokenizer.Scanner.ConsumeUntilInclusive("*/");

            ///

            return new NeuComment(
                source: source,
                start: start,
                end: tokenizer.Scanner.Position());
        }
    }   
}