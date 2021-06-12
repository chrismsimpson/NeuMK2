//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static System.Char;
using static System.IO.File;
using static System.String;

using static Neu.NeuTokenizer;

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

        ///

        public static bool IsFloatLiteral(
            String source)
        {
            if (IsNullOrWhiteSpace(source))
            {
                return false;
            }

            ///

            foreach (var c in source)
            {
                if (!IsNumberLiteralPart(c))
                {
                    return false;
                }
            }

            ///

            return true;
        }

        public static bool IsIntegerLiteral(
            String source)
        {
            if (IsNullOrWhiteSpace(source))
            {
                return false;
            }

            ///

            foreach (var c in source)
            {
                if (!IsIntegerLiteralPart(c))
                {
                    return false;
                }
            }
        
            ///

            return true;
        }

        ///

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

        ///

        public static bool IsIntegerLiteralPart(
            Char c)
        {
            return c == '-' || c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9';
        }

        ///

        public static bool IsNumberLiteralPart(
            Char c)
        {
            return c == '-' || c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9' || c == '.';
        }
        
        ///

        public static bool IsBinaryOperator(
            NeuPunctuation punc)
        {
            switch (punc.PunctuationType)
            {
                case NeuPunctuationType.LessThan:
                    return true;

                ///

                case NeuPunctuationType.GreaterThan:
                    return true;

                ///

                default:
                    return false;
            }
        }

        ///

        public static NeuBinaryOperatorType? ToBinaryOperatorType(
            NeuPunctuation punc)
        {
            switch (punc.PunctuationType)
            {
                case NeuPunctuationType.LessThan:
                    return NeuBinaryOperatorType.LessThan;

                ///

                case NeuPunctuationType.GreaterThan:
                    return NeuBinaryOperatorType.GreaterThan;

                ///

                default:
                    return null;
            }
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
                /// Operators

                case '=' when tokenizer.Scanner.Peek(equals: '='):
                    return tokenizer.RawTokenizeEqualTo();

                case '+':
                    return tokenizer.RawTokenizePlus();

                case '-':
                    return tokenizer.RawTokenizeMinus();

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

                /// Identifiers

                case Char c when IsNumberLiteralPart(c):
                    return tokenizer.RawTokenizeNumberLiteral(c);

                

                ///

                case var _:
                    throw new Exception(); // tokenize string segment?
            }
        }

        ///

        public static IEnumerable<NeuToken> TokenizeUntil(
            this Tokenizer<NeuToken> tokenizer,
            bool escapeOnNewline,
            Func<NeuToken, bool> test)
        {
            var tokens = new List<NeuToken>();

            ///

            while (tokenizer.Next() is NeuToken t)
            {
                if (test(t))
                {
                    tokenizer.Rewind();

                    break;
                }

                ///

                tokens.Add(t);
                
                ///

                if (t.Source.Contains('\n') && escapeOnNewline)
                {
                    break;
                }
            }

            ///

            return tokens;
        }

        ///

        public static IEnumerable<NeuToken> TokenizeUntil(
            this Tokenizer<NeuToken> tokenizer,
            bool escapeOnNewline,
            params NeuPunctuationType[] delimiters)
        {
            return tokenizer.TokenizeUntil(escapeOnNewline, t => t is NeuPunctuation p && delimiters.Contains(p.PunctuationType));
        }

        ///

        public static void Rewind(
            this Tokenizer<NeuToken> tokenizer)
        {
            tokenizer.Counter--;
        }

        ///

        public static IEnumerable<NeuToken> Tokenize(
            this Tokenizer<NeuToken> tokenizer,
            NeuToken token,
            IEnumerable<NeuToken> modifiers,
            params NeuPunctuationType[] delimiters)
        {
            var tokens = new List<NeuToken>();

            ///

            foreach (var modifier in modifiers)
            {
                tokens.Add(modifier);
            }

            ///

            tokens.Add(token);

            ///

            foreach (var t in tokenizer.TokenizeUntil(escapeOnNewline: true, delimiters))
            {
                tokens.Add(t);
            }

            ///

            return tokens;
        }
    }
}