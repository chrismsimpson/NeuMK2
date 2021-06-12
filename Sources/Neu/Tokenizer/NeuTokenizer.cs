//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static System.Char;
using static System.IO.File;

namespace Neu
{
    public partial class NeuTokenizer : Tokenizer<NeuToken>
    {
        public NeuTokenizer(
            Scanner scanner)
            : base(scanner) { }
    }

    ///

    public partial class NeuTokenizer
    {
        public static NeuTokenizer FromFile(
            String file)
        {
            var contents = ReadAllText(file);

            return new NeuTokenizer(
                new Scanner(contents));
        }

        public static bool IsNumberLiteralStart(
            Char c)
        {
            return IsNumber(c) || c == '.' || c == '-';
        }

        public static bool IsIdentifierPart(
            Char c)
        {
            return IsLetter(c) || IsNumber(c) || c == '_';
        }

        public static bool IsIdentifierStart(
            Char c)
        {
            return IsLetter(c) || c == '_';
        }
    }

    ///

    public static partial class NeuTokenizerHelpers
    {
        public static NeuToken? Peek(
            this Tokenizer<NeuToken> tokenizer)
        {
            if (tokenizer.Counter + 1 <= tokenizer.Tokens.Count)
            {
                return tokenizer.Tokens.ElementAt(tokenizer.Counter);
            }

            ///

            if (tokenizer.Scanner.IsEof())
            {
                return null;
            }

            ///

            var next = tokenizer.RawNext();

            tokenizer.Tokens.Add(next);

            ///

            return next;
        }

        public static NeuToken? Next(
            this Tokenizer<NeuToken> tokenizer)
        {
            if (tokenizer.Counter + 1 <= tokenizer.Tokens.Count)
            {
                var token = tokenizer.Tokens.ElementAt(tokenizer.Counter);

                tokenizer.Counter++;

                return token;
            }

            ///

            if (tokenizer.Scanner.IsEof())
            {
                return null;
            }

            ///

            var next = tokenizer.RawNext();

            tokenizer.Tokens.Add(next);

            tokenizer.Counter++;

            return next;
        }

        ///

        private static NeuToken RawNext(
            this Tokenizer<NeuToken> tokenizer)
        {
            var nextChar = tokenizer.Scanner.RawNext();

            ///

            switch (nextChar)
            {
                /// Punctuation

                case '{':
                    return tokenizer.RawTokenizeLeftBrace();

                case '}':
                    return tokenizer.RawTokenizeRightBrace();

                case ':':
                    return tokenizer.RawTokenizeColon();

                case ';':
                    return tokenizer.RawTokenizeSemicolon();

                /// Keywords

                case 'f' when tokenizer.Scanner.PeekThenWhitespace(equals: "unc"):
                    return tokenizer.RawTokenizeFunc();

                ///

                case var _:
                    throw new Exception(); // tokenize string segment?
            }

        }

    }

}