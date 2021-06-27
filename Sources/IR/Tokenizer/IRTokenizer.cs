//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static System.Char;
using static System.IO.File;
using static System.String;

using static Neu.IRTokenizer;

namespace Neu
{
    public partial class IRTokenizer : Tokenizer<IRToken>
    {
        public IRTokenizer(
            Scanner scanner)
            : base(scanner) { }
    }

    ///

    public partial class IRTokenizer
    {
        public static IRTokenizer FromFile(
            String file)
        {
            var contents = ReadAllText(file);

            return new IRTokenizer(
                new Scanner(contents));
        }
    }

    ///

    public static partial class IRTokenizerHelpers
    {
        public static IRToken? Next(
            this Tokenizer<IRToken> tokenizer)
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

        private static IRToken RawNext(
            this Tokenizer<IRToken> tokenizer)
        {
            var nextChar = tokenizer.Scanner.RawNext();

            ///

            switch (nextChar)
            {
                ///

                case '-' when tokenizer.Scanner.Peek(equals: '>'):
                    return tokenizer.RawTokenizeArrow();

                /// Punc

                case '(':
                    return tokenizer.RawTokenizeLeftParen();

                case ')':
                    return tokenizer.RawTokenizeRightParen();

                case '{':
                    return tokenizer.RawTokenizeLeftBrace();

                case '}':
                    return tokenizer.RawTokenizeRightBrace();

                case '[':
                    return tokenizer.RawTokenizeLeftBracket();

                case ']':
                    return tokenizer.RawTokenizeRightBracket();



                /// Keywords

                case 'f' when tokenizer.Scanner.PeekThenWhitespace(equals: "func"):
                    return tokenizer.RawTokenizeFunc();

                case 'r' when tokenizer.Scanner.PeekThenWhitespace(equals: "eturn"):
                    return tokenizer.RawTokenizeReturn();



                ///

                default:
                    throw new Exception();
            }
        }
    }
     
}