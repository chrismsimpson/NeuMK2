//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public class Tokenizer<T> where T : Token
    {
        internal Scanner Scanner { get; init; }

        internal IList<T> Tokens { get; init; }

        internal int Counter { get; set; }

        ///

        public Tokenizer(
            Scanner scanner)
        {
            this.Scanner = scanner;

            this.Tokens = new List<T>();

            this.Counter = 0;
        }
    }

    ///

    public static partial class TokenizerHelpers
    {
        public static bool IsEof<T>(
            this Tokenizer<T> tokenizer)
            where T : Token
        {
            if (tokenizer.Position() == tokenizer.Scanner.Position())
            {
                return tokenizer.Scanner.IsEof();
            }

            return false;
        }

        public static SourceLocation Position<T>(
            this Tokenizer<T> tokenizer)
            where T : Token
        {
            if (tokenizer.Counter + 1 <= tokenizer.Tokens.Count)
            {
                return tokenizer.Tokens.ElementAt(tokenizer.Counter).Start;
            }

            return tokenizer.Scanner.Position();
        }
    }
}